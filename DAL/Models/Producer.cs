using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DAL.Models
{
    public class Producer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        private HashSet<Product> products;
        public IEnumerable<Product> Products => products?.ToList();
        public string Name { get; private set; }
        public string Description { get; private set; }

        private Producer() { }

        public Producer(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name can not be null or empty");
            }

            this.Name = name;
            this.Description = description;
        }

        public void AddProduct(Category category, string model, string description, double price, int numberOfItems, DbContext context)
        {
            if(products != null)
            {
                products.Add(new Product(this, category, model, description, price, numberOfItems));
            }
            else if (context == null)
            {
                throw new ArgumentNullException(nameof(context), "You must provide a context if the Reviews collection isn't valid.");
            }
            else if (context.Entry(this).IsKeySet)
            {
                context.Add(new Product(this, category, model, description, price, numberOfItems));
            }
            else
            {
                throw new InvalidOperationException("Could not add a new option.");
            }
        }
    }
}
