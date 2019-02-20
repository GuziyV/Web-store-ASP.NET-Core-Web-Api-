using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class ProductImage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public string ImageUrl { get; private set; }

        private ProductImage() { }

        public ProductImage(Product product, string imageUrl)
        {
            this.ImageUrl = imageUrl;
            this.ProductId = product.Id;
        }
    }
}
