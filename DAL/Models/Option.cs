using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Option
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
    }
}
