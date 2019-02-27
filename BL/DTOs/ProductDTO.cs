using System.Collections.Generic;
using System.Linq;

namespace BL.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProducerName { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public IEnumerable<ProductImageDTO> ProductImages;
        public int NumberOfItems { get; set; }
        public IEnumerable<OptionDTO> Options { get; set; }
        public double PriceWithDiscount { get; set; }
    }
}
