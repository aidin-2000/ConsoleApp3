using ConsoleApp3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Controller
{
    public class EmployeeController
    {
        private readonly Employee _employee;
        public EmployeeController(Employee employee)
        {
            _employee = employee;
        }
        private string employeesDirectory;
        public EmployeeController(string directoryPath)
        {
            employeesDirectory = directoryPath;
        }

        public EmployeeController()
        {
        }

        public void Save()
        {

            string maxIdPath = "C:\\Users\\Aidin\\source\\Новая папка\\ConsoleApp3\\entity\\employee\\max\\max.txt";
            int maxId = 0;
            using (StreamReader sr = new StreamReader(maxIdPath))
            {
                maxId = int.Parse(sr.ReadLine());
            }
            using (StreamWriter sw = new StreamWriter($"C:\\Users\\Aidin\\source\\Новая папка\\ConsoleApp3\\entity\\employee\\employee{maxId + 1}.txt"))
            {

                // Форматирование данных сотрудника для записи
                sw.WriteLine($"{_employee.Employee_Code}");
                sw.WriteLine($"{_employee.Name}");
                sw.WriteLine($"{_employee.Position}");
                sw.WriteLine($"{_employee.Salary}");
                sw.WriteLine($"{_employee.WorkSchedule}");
            
            }   
            using (StreamWriter sw = new StreamWriter(maxIdPath))
            {
                sw.WriteLine($"{maxId + 1}");
            }
        }

        /* public List<Employee> GetAll()
         {
             List<Employee> allClients = new List<Employee>();

             string clientsPath = "C:\\Users\\Aidin\\source\\Новая папка\\ConsoleApp3\\entity\\employee\\";

             string[] filePaths = Directory.GetFiles(clientsPath);

             foreach (string file in filePaths)
             {
                 using StreamReader sr = new StreamReader(file);
                 string name = sr.ReadLine();
                 decimal salaryread = decimal.Parse(sr.ReadLine());
                 string position = sr.ReadLine();
                 string work = sr.ReadLine();
                 Employee client = new Employee(name, salaryread, position, work);
                 allClients.Add(client);
             }

             return allClients;
         }
        */

        public void DeleteEmployee(Employee employee)
        {
            string employeesDirectory = "C:\\Users\\Aidin\\source\\Новая папка\\ConsoleApp3\\entity\\employee\\";
            try
            {
                string filePath = Path.Combine(employeesDirectory, $"{employee.Name}.txt");

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Console.WriteLine($"Данные о сотруднике '{employee.Name}' удалены.");
                }
                else
                {
                    Console.WriteLine($"Файл с данными о сотруднике '{employee.Name}' не найден.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении данных о сотруднике: {ex.Message}");
            }
        }


        //чтение 
        /*
        public List<Employee> ReadEmployeesFromDirectory(string directoryPath)
        {
            List<Employee> employees = new List<Employee>();

            try
            {
                string[] filePaths = Directory.GetFiles(directoryPath);

                foreach (string filePath in filePaths)
                {
                    // Читаем данные из каждого файла
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        Guid employee_code = sr.ReadLine();         
                        string name = sr.ReadLine();         // Читаем имя
                        decimal salary = decimal.Parse(sr.ReadLine());  // Читаем зарплату
                        string position = sr.ReadLine();     // Читаем должность
                        string workSchedule = sr.ReadLine(); // Читаем график работы

                        // Создаем объект Employee на основе считанных данных
                        Employee employee = new Employee(employee_code,name, salary, position, workSchedule);

                        // Добавляем сотрудника в список
                        employees.Add(employee);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении данных о сотрудниках: {ex.Message}");
            }

            return employees;
        }*/


    }
}
