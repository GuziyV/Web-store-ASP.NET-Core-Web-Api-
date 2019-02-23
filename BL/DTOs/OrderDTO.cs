using System.Collections.Generic;
using System.Linq;

namespace BL.DTOs
{
    public class OrderDTO 
    {
        public int Id { get; set; }
        public UserDTO User { get; set; }
        public IEnumerable<ProductDTO> Products { get; set; }
        public string Comment { get; set; }
        public string PaymentType { get; set; }

        private OrderDTO() { }
    }
}
