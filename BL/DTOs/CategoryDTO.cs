using System.Collections.Generic;
using System.Linq;

namespace BL.DTOs
{
    public class CategoryDTO 
    {
        public int Id { get; set; }
        public IEnumerable<ProductDTO> Products { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
