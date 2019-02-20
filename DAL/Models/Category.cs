using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DAL.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        private HashSet<Product> products;
        public IEnumerable<Product> Products => products?.ToList();
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ImageUrl { get; private set; }

        private Category() { }

        public Category(string name, string description, string imageUrl)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name can not be null or empty");
            }

            this.Name = name;
            this.Description = description;
            this.ImageUrl = imageUrl;
        }
    }
}
