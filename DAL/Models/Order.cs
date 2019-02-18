using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Models
{
    public class Order
    {
        public int Id { get; private set; }
        public int CustomerId { get; private set; }
        private HashSet<ProductOrder> productOrders;
        public IEnumerable<ProductOrder> ProductOrders => productOrders?.ToList();
        public string Comment { get; private set; }
        public string PaymentType { get; private set; }

        private Order() { }
    }
}
