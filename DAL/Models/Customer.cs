using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Models
{
    public class Customer
    {
        public int Id { get; private set; }
        private HashSet<Order> orders;
        public IEnumerable<Order> Orders => orders?.ToList();
        public string Login { get; private set; }
        public string Email { get; private set; }
        public string Telephone { get; private set; }
        public string IP { get; private set; }
        public Role Role { get; private set; }

        private Customer() { }
    }
}
