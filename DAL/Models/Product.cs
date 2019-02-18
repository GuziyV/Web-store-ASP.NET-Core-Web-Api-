using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Models
{
    public class Product
    {
        public int Id { get; private set; }
        public int CategoryId { get; private set; }
        public int ProducerId { get; private set; }
        private HashSet<ProductOrder> productOrders;
        public IEnumerable<ProductOrder> ProductOrders => productOrders?.ToList();
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }
        private HashSet<ProductImage> productImages;
        public IEnumerable<ProductImage> ProductImages => productImages?.ToList();
        public int NumberOfItems { get; private set; }
        private HashSet<Option> options;
        public IEnumerable<Option> Options => options?.ToList();

        private Product() { }
    }
}
