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
	public class ProducerController : ControllerBase {
	    private ProducerService producerService;

		public ProducerController(ProducerService producerService) {
			this.producerService = producerService;
		}
		//api/Category
		[HttpGet]
		public async Task<IEnumerable<ProducerDTO>> GetAll() {
			return await producerService.GetAllAsync();
		}

		// POST: api/Category
		[HttpPost]
		[Authorize(Roles = Role.Admin)]
		public async Task<ProducerDTO> Post([FromBody] ProducerDTO product) {
			return await producerService.PostAsync(product);
		}
	}
}