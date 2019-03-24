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
                    });
                }))).Entity :
                null;

            foreach (var option in mapper.Map<IEnumerable<OptionDTO>, IEnumerable<Option>>(entity.Options))
            {
                resEntity.AddOption(option.Name, context);
            }
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
       
        public async override Task<ProductDTO> GetOneAsync(int identifier)
        {
            return context != null ?
                mapper.Map<ProductDTO>((await context.Set<Product>()
                .Include(p => p.Options)
                .FirstAsync(p => p.Id == identifier))) :
                null;
        }

        public async Task<IEnumerable<ProductDTO>> GetBySearchResult(string search, int page, int pageSize = 10) {
	        return mapper.Map<IEnumerable<ProductDTO>>(await context.Set<Product>()
		        .Where(p => (p.Producer.Name + " " + p.Model).Contains(search))
		        .Skip((page - 1) * pageSize).Take(pageSize)
				.Include(p => p.Category)
		        .Include(p => p.Producer)
		        .ToListAsync());
        }
    }
}
