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
		public async Task<List<OrderDTO>> GetAllAsync(int userId) {
			return context != null ?
				mapper.Map<List<OrderDTO>>(await context.Set<Order>()
					.Where(o => o.User.Id == userId && o.OrderStatus != OrderStatus.Basket)
					.ToListAsync()) :
				null;
		}

		public async Task<OrderDTO> AddToCart(ProductDTO product, UserDTO user) {
			var cart = await this.getCart(user.Id);
			if (cart == null) {
				cart = new Order(mapper.Map<User>(user), OrderStatus.Basket);
				await context.AddAsync(cart);
			}

			return mapper.Map<OrderDTO>(await cart.AddProduct(mapper.Map<Product>(product), context));
		}

		private async Task<Order> getCart(int id) { // No DTO
			return await context.Set<Order>()
				.Include(o => o.ProductOrders)
				.ThenInclude(p => p.Product)
				.SingleOrDefaultAsync(o => o.OrderStatus == OrderStatus.Basket && o.User.Id == id);
		}

		public async Task<OrderDTO> GetCart(int id) { //DTO
			return mapper.Map<OrderDTO>(await getCart(id));
		}

		public async Task<OrderDTO> TransferItemsFromCartToOrder(int userId) {
			var cart = await getCart(userId);
			cart.OrderStatus = OrderStatus.Pending;
			await context.SaveChangesAsync();
			return mapper.Map<OrderDTO>(cart);
		}
	}
}
