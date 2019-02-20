using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DAL.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public int CategoryId { get; private set; }
        public int ProducerId { get; private set; }
        private HashSet<ProductOrder> productOrders;
        public IEnumerable<ProductOrder> ProductOrders => productOrders?.ToList();
        public string Model { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }
        private HashSet<ProductImage> productImages;
        public IEnumerable<ProductImage> ProductImages => productImages?.ToList();
        public int NumberOfItems { get; private set; }
        private HashSet<Option> options;
        public IEnumerable<Option> Options => options?.ToList();

        private Product() { }

        public Product(Producer producer, Category category, string model, string description, double price, int numberOfItems)
        {
            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentException("Name can not be null or empty");
            }

            this.Model = model;

            if(producer == null)
            {
                throw new ArgumentException("Producer can not be null");
            }

            this.ProducerId = producer.Id;

            if(category == null)
            {
                throw new ArgumentException("Producer can not be null");
            }

            this.CategoryId = category.Id;

            this.Description = description;

            if (price < 0)
            {
                throw new ArgumentException("Price can not be lower than 0");
            }
            this.Price = price;

            if (numberOfItems < 0)
            {
                throw new ArgumentException("Number of items can not be lower than 0");
            }

            this.NumberOfItems = numberOfItems;
        }

        public void AddOption(string name, DbContext context)
        {
            if(options != null)
            {
                options.Add(new Option(this, name));
            }
            else if(context == null)
            {
                throw new ArgumentNullException(nameof(context),"You must provide a context if the Reviews collection isn't valid.");
            }
            else if (context.Entry(this).IsKeySet)
            {
                context.Add(new Option(this, name));
            }
            else
            {
                throw new InvalidOperationException("Could not add a new option.");
            }
        }

        public void AddProductImage(string imageUrl, DbContext context)
        {
            if (string.IsNullOrWhiteSpace(imageUrl))
            {
                throw new ArgumentException("ImageUrl can not be empty or null");
            }
            if (productImages != null)
            {
                productImages.Add(new ProductImage(this, imageUrl));
            }
            else if (context == null)
            {
                throw new ArgumentNullException(nameof(context), "You must provide a context if the Reviews collection isn't valid.");
            }
            else if (context.Entry(this).IsKeySet)
            {
                context.Add(new ProductImage(this, imageUrl));
            }
            else
            {
                throw new InvalidOperationException("Could not add a new productImage.");
            }
        }
    }
}
