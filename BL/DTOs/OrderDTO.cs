using System.Collections.Generic;
using System.Linq;
using DAL.Contexts;

namespace BL.DTOs
{
    public class OrderDTO 
    {
        public int Id { get; set; }
        public UserDTO User { get; set; }
        public IEnumerable<ProductDTO> Products { get; set; }
        public string Comment { get; set; }
        public string PaymentType { get; set; }
        public OrderStatus OrderStatus { get; set; }

        private OrderDTO() { }
    }
}
