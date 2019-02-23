using DAL.Interfaces;

namespace DAL.Models
{
    public class ProductOrder
    {
        public int ProductId { get; private set; }
        public Product Product { get; private set; }
        public int OrderId { get; private set; }
        public Order Order { get; private set; }

        private ProductOrder() { }
    }
}