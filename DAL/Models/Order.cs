using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<ProductOrder> ProductOrders { get; set; }
        public string Comment { get; set; }
        public string PaymentType { get; set; }
    }
}
