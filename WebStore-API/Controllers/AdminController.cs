using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.DTOs;
using BL.Services;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebStore_API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = Role.Admin)]
	public class AdminController : ControllerBase {
	    private AdminService adminService;

	    public AdminController(AdminService adminService) {
		    this.adminService = adminService;
	    }
        // POST: api/Admin
        [HttpPost("addProduct")]
        public async Task<ProductDTO> Post([FromBody] ProductDTO product) {
	        return await adminService.AddProduct(product: product);
        }
    }
}
