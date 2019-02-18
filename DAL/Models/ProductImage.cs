using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class ProductImage
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public string ImageUrl { get; private set; }

        private ProductImage() { }
    }
}
