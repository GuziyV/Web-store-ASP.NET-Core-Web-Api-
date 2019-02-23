using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class ProductImage : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public Product Product { get; private set; }
        public string ImageUrl { get; private set; }

        private ProductImage() { }

        public ProductImage(Product product, string imageUrl)
        {
            this.ImageUrl = imageUrl;
            this.Product = product;
        }
    }
}
