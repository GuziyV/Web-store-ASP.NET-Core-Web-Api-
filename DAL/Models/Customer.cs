using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public List<Order> Orders { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string IP { get; set; }
        public Role Role { get; set; }
    }
}
