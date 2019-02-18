using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Models
{
    public class Category
    {
        public int Id { get; private set; }
        private HashSet<Product> products;
        public IEnumerable<Product> Products => products?.ToList();
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ImageUrl { get; private set; }

        private Category() { }
    }
}
