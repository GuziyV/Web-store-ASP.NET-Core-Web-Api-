using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BL.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public IEnumerable<OrderDTO> Orders;
        public string Login { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string IP { get; set; }
        public Role Role { get; set; }
    }
}
