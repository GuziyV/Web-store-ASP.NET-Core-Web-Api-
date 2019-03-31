using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models
{
    public class Order : IEntity 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public User User { get; private set; }
        private HashSet<ProductOrder> productOrders;
        public IEnumerable<ProductOrder> ProductOrders => productOrders?.ToList();
        public string Comment { get; private set; }
        public string PaymentType { get; private set; }
        public OrderStatus OrderStatus { get; set; }
		private Order() { }

		public Order(User user, OrderStatus orderStatus) {
			this.User = user;
			this.OrderStatus = orderStatus;
		}

		public async Task<Order> AddProduct(Product product, DbContext context) {
			if (productOrders == null) {
				productOrders = new HashSet<ProductOrder>();
			}
			var productOrder = productOrders.FirstOrDefault(p => p.Product.Id == product.Id);
			if (productOrder == null) {
				this.productOrders.Add(new ProductOrder(this, product));
			}
			else {
				productOrder.NumberOfProducts++;
			}

			await context.SaveChangesAsync();
			return this;
		}
    }
}
