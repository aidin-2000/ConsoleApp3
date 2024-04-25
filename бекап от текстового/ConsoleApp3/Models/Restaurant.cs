using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Models
{
    public class Restaurant
    {
        public string Name { get; set; }
        public  string HeadChef { get; set; }
        public List<Dish> Menu { get; set; }
        public List<Employee> Employees { get; set; }
        public decimal CashBalance { get; set; }

        public Restaurant(string name, string headChef)
        {
            Name = name;
            HeadChef = headChef;
            Menu = new List<Dish>();
            Employees = new List<Employee>();
            CashBalance = 0m;
        }
    }
}
