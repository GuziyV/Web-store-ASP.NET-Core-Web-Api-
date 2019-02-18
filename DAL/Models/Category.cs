﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Category
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
