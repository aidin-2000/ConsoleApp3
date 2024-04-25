using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Models
{
    public class Dish

    {
        public int DishId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<Restaurant> Restaurant { get; set;}
        public List<Ingredient> Ingredients { get; set; }
       

        public Dish(int dishId, string name, decimal price, List<Restaurant> restaurant, List<Ingredient> ingredients)
        {
        DishId = dishId;
            Name = name;
            Restaurant = restaurant;
            Ingredients = ingredients;
            Price = price;
           
        }
        
    }
}
