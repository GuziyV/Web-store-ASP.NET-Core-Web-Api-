using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Producer
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public int Name { get; set; }
        public string Description { get; set; }
    }
}
