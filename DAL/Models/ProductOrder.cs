using DAL.Interfaces;

namespace DAL.Models
{
    public class ProductOrder
    {
        public int ProductId { get; private set; }
        public Product Product { get; private set; }
        public int OrderId { get; private set; }
        public Order Order { get; private set; }
        public int NumberOfProducts { get; set; }
        private ProductOrder() { }

        public ProductOrder(Order order, Product product) {
	        this.OrderId = order.Id;
	        this.ProductId = product.Id;
	        this.NumberOfProducts = 1;
        }
    }
}