﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Option
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public string Name { get; private set; }
    }
}
