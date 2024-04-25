using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Models
{
    public class Ingredient
    {
        public Products Product { get; set; }
        public int WeightGrams { get; set; }
        public Ingredient(Products product, int weigthGrams) 
        {
            Product=product;
            WeightGrams=weigthGrams;
        }
    }
}
