using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Option : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public string Name { get; private set; }

        private Option() { }

        public Option(Product product, string name)
        {
            this.ProductId = product.Id;

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name can not be null or empty");
            }
            this.Name = name;
        }
    }
}
