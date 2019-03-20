using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.DTOs;
using BL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebStore_API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase {
	    private AdminService adminService;

	    public AdminController(AdminService adminService) {
		    this.adminService = adminService;
	    }
        // POST: api/Admin
        [HttpPost("addProduct")]
        public async Task<ProducerDTO> Post([FromBody] ProductDTO product) {
	        return await adminService.AddProduct(product: product);
        }
    }
}
