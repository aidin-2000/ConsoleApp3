using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Models
{
    public class Dish
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<Ingredient> Ingredients { get; set;}

        public Dish(string name, List<Ingredient> ingredients)
        {
            Name = name;
            Ingredients = ingredients;
           
        }
        private void CalculatePrice()
        { 
            if(Ingredients!=null && Ingredients.Any())
            {
                Price=Ingredients.Sum(i => i.Product.PricePerGram*i.WeightGrams);
            }
            else
            {
                Price = 0;
            }
        }
    }
}
