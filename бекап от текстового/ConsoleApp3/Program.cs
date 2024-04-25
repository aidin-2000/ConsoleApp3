using ConsoleApp3.Controller;
using ConsoleApp3.Models;
using System.Xml.Linq;
using static ConsoleApp3.Models.Products;
using static ConsoleApp3.Models.Restaurant;
using static ConsoleApp3.Controller.EmployeeController;


class Program
{
    static void Main(string[] args)
    {
       
        //Добавление 
       /* while (true)
        {
            int employee_code=0;
            Console.WriteLine("enter Name");
            string Name = Console.ReadLine();
            Console.WriteLine("enter cash Salary");
            decimal Salary = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter Position");
            string Position = Console.ReadLine();
            Console.WriteLine("Enter WorkSchedule");
            string WorkSchedule = Console.ReadLine();
            Employee employee = new Employee(employee_code,Name, Position, Salary, WorkSchedule);
            EmployeeController1 vasyaController = new EmployeeController1(employee);
            vasyaController.Save();
            Console.WriteLine("Client saved!");
        }*/

        //чтение 
        string employeesDirectory = "C:\\Users\\Aidin\\source\\Новая папка\\ConsoleApp3\\entity\\employee\\";
        // string employeesDirectory = @"C:\Path\To\Your\Employee\Files\";

         // Создаем экземпляр класса для чтения данных о сотрудниках
         EmployeeController1 employeeReader = new EmployeeController1(employeesDirectory);

         // Читаем данные о сотрудниках из указанной директории
        List<Employee> employees = employeeReader.GetAllEmployees();

         // Выводим информацию о сотрудниках в консоль
         Console.WriteLine("Список сотрудников:");
         string header = "code".PadRight(20) + "Name".PadRight(20) + "Position".PadRight(20) + "Salary".PadRight(15) + "WorkSchedule";

         // Запись заголовков в файл
         Console.WriteLine(header);
         foreach (Employee employee in employees)
         {



             // Форматирование данных сотрудника для записи
             string employeeData = $"{employee.Employee_Code}".PadRight(20) +
                                    $"{employee.Name}".PadRight(20) +
                                   $"{employee.Position}".PadRight(20) +
                                   $"{employee.Salary}".PadRight(15) +
                                   $"{employee.WorkSchedule}";
             // Запись данных сотрудника в файл
             Console.WriteLine(employeeData);

         }

       /// удаление 
        Console.ReadLine(); // Чтобы консоль не закрылась сразу после вывода информации*/
        EmployeeController1 employeeController = new EmployeeController1(employeesDirectory);
        /*Employee employeeToDelete = new Employee("employee4");
        employeeController.DeleteEmployee(employeeToDelete);*/

        Console.ReadLine();
        
         // Обновление информации о сотруднике
          Employee existingEmployee = new Employee(12, "2000", "Шума", 2500, "8am - 4pm");
          Employee updatedEmployee = new Employee(12,"aidin",  "Шума", 2500m, "8am - 10pm");
          employeeController.UpdateEmployee(existingEmployee, updatedEmployee);
 
    }

}

