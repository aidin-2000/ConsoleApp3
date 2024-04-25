using ConsoleApp3.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurants.Controllers
{
    public class DishController
    {
        private string _DishDirectory;

        private readonly Dish _dish;
    public DishController(string dishdirectory)
        {
            _DishDirectory = dishdirectory;
        }

        public DishController(Dish dish)
        {   
            _dish = dish;
        }
        public List<Dish> GetAllDish() 
        {
            List<Dish> dish = new List<Dish>();
            try
            {
                string[] filePath = Directory.GetFiles(_DishDirectory);
                foreach (string filePath2 in filePath)
                {
                    using (StreamReader sr=new StreamReader(filePath2))
                    {
                        int id = int.Parse(sr.ReadLine());
                        string name = sr.ReadLine();
                        int restaurant = int.Parse(sr.ReadLine());
                        int Ingredients = int.Parse(sr.ReadLine());
                        decimal Price= decimal.Parse(sr.ReadLine());
                     // Dish dish1=new Dish(id, name, Price, restaurant, Ingredients);
            
                    }
                }

            }
            catch { }
            return dish;
        }
      
    }
}

