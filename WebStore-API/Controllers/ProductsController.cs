using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BL.DTOs;
using BL.Services;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebStore_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
	public class ProductsController : ControllerBase
    {
        ProductService productService;
        public ProductsController(ProductService productService)
        {
            this.productService = productService;
        }

		//api/Products?page=p&search=s
		[HttpGet]
        public async Task<IEnumerable<ProductDTO>> GetBySearch(string search = "", int page = 1) {
	        return await productService.GetBySearchResult(search, page);
        }

		// GET: api/Products/5
		[HttpGet("{id}")]
        public async Task<ProductDTO> Get(int id)
        {
            return await productService.GetOneAsync(id);
        }

        // POST: api/Products
        [HttpPost]
        [Authorize(Roles = Role.Admin)]
		public async Task<ProductDTO> Post([FromBody] ProductDTO product)
        {
            return await productService.PostAsync(product);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        [Authorize(Roles = Role.Admin)]
		public async Task<ProductDTO> Put([FromBody] ProductDTO product) {
			return await productService.UpdateAsync(product);
		}

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
		public async Task<bool> Delete(int id)
        {
            return await productService.TryDeleteAsync(id);
        }
    }
}
