using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BL.DTOs;
using DAL.Contexts;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BL.Services {
	public class OrderService : CRUDService<Order, OrderDTO> {
		public OrderService(DbContext context, IMapper mapper) : base(context, mapper) {
		}

		public async Task<OrderDTO> AddToCart(ProductDTO product, UserDTO user) {
			var cart = await context.Set<Order>()
				.Include(o => o.ProductOrders)
				.ThenInclude(p => p.Product)
				.SingleOrDefaultAsync(o => o.OrderStatus == OrderStatus.Basket);
			if (cart == null) {
				cart = new Order(mapper.Map<User>(user), OrderStatus.Basket);
				await context.AddAsync(cart);
			}

			return mapper.Map<OrderDTO>(await cart.AddProduct(mapper.Map<Product>(product), context));
		}
	}
}
