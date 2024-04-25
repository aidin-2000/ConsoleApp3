using ConsoleApp3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Controller
{
    public class RestaurantController
    {
        private readonly Restaurant restaurant;

        public RestaurantController(Restaurant restaurant)
        {
            this.restaurant = restaurant;
        }

        // Метод для добавления нового блюда в меню ресторана
     


        // Метод для найма нового сотрудника
        //public void HireEmployee(int Employee_code, string name, decimal salary, string position, string workSchedule)
        //{
        //    Employee newEmployee = new Employee(Employee_code, name, salary, position, workSchedule);
        //    restaurant.Employees.Add(newEmployee);
        //    Console.WriteLine($"Сотрудник '{name}' нанят на должность '{position}'.");
        //}

        // Метод для управления балансом кассы (пополнение или списание средств)
        public void ManageCashBalance(decimal amount)
        {
            restaurant.CashBalance += amount;
            string action = amount > 0 ? "пополнение" : "списание";
            Console.WriteLine($"Баланс кассы успешно изменен ({action} на {Math.Abs(amount)}).");
        }

        // Метод для вывода информации о ресторане
        public void PrintRestaurantInfo()
        {
            Console.WriteLine($"Название ресторана: {restaurant.Name}");
            Console.WriteLine($"Шеф-повар: {restaurant.HeadChef}");
            Console.WriteLine($"Количество блюд в меню: {restaurant.Menu.Count}");
            Console.WriteLine($"Количество сотрудников: {restaurant.Employees.Count}");
            Console.WriteLine($"Баланс кассы: {restaurant.CashBalance}");
        }
    }
}
