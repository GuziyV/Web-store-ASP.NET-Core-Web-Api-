using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BL.DTOs;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BL.Services {
	public class CategoryService : CRUDService<Category, CategoryDTO> {
		public CategoryService(DbContext context, IMapper mapper) : base(context, mapper) {
		}
	}
}
