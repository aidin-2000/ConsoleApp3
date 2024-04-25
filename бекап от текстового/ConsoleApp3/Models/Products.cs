using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Models
{
    public class Products
    {
        public string Name { get; set; }
        public decimal PricePerGram { get; set; }
        public ProductType Type { get; set; }
        public Products(string name, decimal pricePerGram, ProductType type)
        {
            Name = name;
            PricePerGram = pricePerGram;
            Type = type;
        }
        public enum ProductType
        {
            Vegetable,
            Fruit,
            Meat,
            Spice
        }
    }
}
