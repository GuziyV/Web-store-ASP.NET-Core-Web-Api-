using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.DTOs;
using BL.Services;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebStore_API.Controllers
{
	[Route("api/[controller]")]
	[Authorize]
	public class CategoryController : ControllerBase {
	    private CategoryService categoryService;

		public CategoryController(CategoryService categorySerice) {
			this.categoryService = categorySerice;
		}
		//api/Category
		[HttpGet]
		public async Task<IEnumerable<CategoryDTO>> GetAll() {
			return await categoryService.GetAllAsync();
		}

		// POST: api/Category
		[HttpPost]
		[Authorize(Roles = Role.Admin)]
		public async Task<CategoryDTO> Post([FromBody] CategoryDTO product) {
			return await categoryService.PostAsync(product);
		}
	}
}