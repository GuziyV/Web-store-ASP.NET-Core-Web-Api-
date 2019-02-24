using AutoMapper;
using BL.DTOs;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class ProductService : CRUDService<Product, ProductDTO>
    {
        public ProductService(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<bool> TryChangePrice(int id, double price)
        {
            var product = await this.GetOneAsync(id);
            product.Price = price;
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<ProductDTO> PostAsync(ProductDTO entity)
        {
            var resEntity = context != null ?
                (await context.AddAsync<Product>(mapper.Map<ProductDTO, Product>(entity, opt =>
                {
                    opt.AfterMap(async (src, dest) =>
                    {
                        dest.SetCategory(await context.Set<Category>().Where(p => p.Name == src.CategoryName)
                            .FirstOrDefaultAsync());
                        dest.SetProducer(await context.Set<Producer>().Where(p => p.Name == src.ProducerName)
                            .FirstOrDefaultAsync());

                        await context.SaveChangesAsync();

                        foreach (var option in src.Options)
                        {
                            dest.AddOption(option.Name, context);
                        }

                        foreach (var image in src.ProductImages)
                        {
                            dest.AddProductImage(image.ImageUrl, context);
                        }
                    });
                }))).Entity :
                null;
            await context.SaveChangesAsync();
            return mapper.Map<ProductDTO>(resEntity);
        }

        public async override Task<List<ProductDTO>> GetAllAsync()
        {
            return context != null ?
                mapper.Map<List<ProductDTO>>(await context.Set<Product>()
                .Include(p => p.Category)
                .Include(p => p.Producer)
                .ToListAsync()) :
                null;
        }

        public async Task<bool> TrySetOptions(int productId, IEnumerable<OptionDTO> options)
        {
            foreach(var option in options)
            {
                mapper.Map<Product>(await this.GetOneAsync(productId)).AddOption(option.Name, context);
            }
            await context.SaveChangesAsync();
            return true;
        }
    }
}
