using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

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

        private Order() { }
    }
}
