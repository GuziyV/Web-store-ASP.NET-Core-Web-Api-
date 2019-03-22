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
    [Authorize(Roles = "User, Admin")]
	public class ProductsController : ControllerBase
    {
        ProductService productService;
        public ProductsController(ProductService productService)
        {
            this.productService = productService;
        }

        //api/Products
        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> Get()
        {
            return await productService.GetAllAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ProductDTO> Get(int id)
        {
            return await productService.GetOneAsync(id);
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ProductDTO> Post([FromBody] ProductDTO product)
        {
            return await productService.PostAsync(product);
        }

        // PUT: api/Products/5
        [HttpPost("{id}")]
        public async Task<bool> SetOption(int id, [FromBody] IEnumerable<OptionDTO> options)
        {
            return await productService.TrySetOptions(id, options);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<bool> Put(int id, [FromBody] double price)
        {
            return await productService.TryChangePrice(id, price);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await productService.TryDeleteAsync(id);
        }
    }
}
