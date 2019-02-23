using AutoMapper;
using BL.DTOs;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    }
}
