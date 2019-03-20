using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BL.DTOs;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BL.Services {
	public class AdminService { 
		protected readonly DbContext context;
		protected readonly IMapper mapper;

		public AdminService(DbContext context, IMapper mapper) {
			this.mapper = mapper;
			this.context = context;
		}

		public async Task<ProducerDTO> AddProduct(ProductDTO product) {
			var resEntity = context != null ?
				(await context.AddAsync<Producer>(mapper.Map<Producer>(product))).Entity :
				null;
			await context.SaveChangesAsync();
			return mapper.Map<ProducerDTO>(resEntity);
		}
	}
}
