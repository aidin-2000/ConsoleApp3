using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public Products Product { get; set; }
        public int WeightGrams { get; set; }
        public string Name { get; set; }
        public List<Dish> Dishs { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Restaurant> Restaurants { get;set;}
        public decimal Price { get; set; }  

        public Ingredient(int ingredientid, Products product, int weigthGrams, string name, List<Dish> dishes,List<Restaurant> restaurants) 
        {
            IngredientId = ingredientid;
            Product=product;
            WeightGrams = weigthGrams;
            Name = name;
            Dishs = dishes;
            Restaurants = restaurants;  


        }
        private void CalculatePrice()
        {
            if (Ingredients != null && Ingredients.Any())
            {
                Price = Ingredients.Sum(i => i.Product.PricePerGram * i.WeightGrams);
            }
            else
            {
                Price = 0;
            }
        }
    }
}
