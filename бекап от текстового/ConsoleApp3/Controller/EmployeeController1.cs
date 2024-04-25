using ConsoleApp3.Models;
using System;
using System.Collections.Generic;
using System.IO;


public class EmployeeController1
{
    private string _employeesDirectory;  // Путь к директории с файлами сотрудников

    private readonly Employee _employee;
    public EmployeeController1(Employee employee)
    {
       
        _employee = employee;

    }

    public EmployeeController1(string directoryPath)
    {
        _employeesDirectory = directoryPath;
    }

    public EmployeeController1()
    {
    }

    // Метод для создания нового сотрудника
    public void CreateEmployee(Employee employee)
    {
        try
        {
            string filePath = Path.Combine(_employeesDirectory, $"{employee.Name}.txt");

            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine(employee.Name);
                sw.WriteLine(employee.Salary);
                sw.WriteLine(employee.Position);
                sw.WriteLine(employee.WorkSchedule);
            }

            Console.WriteLine($"Сотрудник '{employee.Name}' добавлен.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при добавлении сотрудника: {ex.Message}");
        }
    }

    public void Save()
    {
        string maxIdPath = "C:\\Users\\Aidin\\source\\Новая папка\\ConsoleApp3\\entity\\employee\\max\\EmployeeIdentifier.txt";
        int EmployeeIdentifier = 0;
        using (StreamReader sr = new StreamReader(maxIdPath))
        {
            EmployeeIdentifier = int.Parse(sr.ReadLine());
        }
        int Employee_Code = EmployeeIdentifier++;
       
        int maxId = 0;
        using (StreamReader sr = new StreamReader(maxIdPath))
        {
            maxId = int.Parse(sr.ReadLine());
        }
        using (StreamWriter sw = new StreamWriter($"C:\\Users\\Aidin\\source\\Новая папка\\ConsoleApp3\\entity\\employee\\employee{maxId + 1}.txt"))
        {

            // Форматирование данных сотрудника для записи
            sw.WriteLine(Employee_Code);
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


    // Метод для чтения информации о всех сотрудниках
    public List<Employee> GetAllEmployees()
    {
        List<Employee> employees = new List<Employee>();

        try
        {
            string[] filePaths = Directory.GetFiles(_employeesDirectory);

            foreach (string filePath in filePaths)
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    int id = int.Parse(sr.ReadLine());
                    string name = sr.ReadLine();
                    string position = sr.ReadLine();
                    decimal salary = decimal.Parse(sr.ReadLine());
                    string workSchedule = sr.ReadLine();

                    Employee employee = new Employee(id,name, position, salary, workSchedule);
                    employees.Add(employee);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении данных о сотрудниках: {ex.Message}");
        }

        return employees;
    }

    // Метод для обновления информации о сотруднике
    public void UpdateEmployee(Employee existingEmployee, Employee updatedEmployee)
    {
        
        try
        {
            string filePath = Path.Combine(_employeesDirectory, $"{existingEmployee.Employee_Code}.txt");

            // Создаем временный файл для записи обновленных данных
            string tempFilePath = Path.Combine(_employeesDirectory, $"{existingEmployee.Employee_Code}_temp.txt");

            using (StreamReader sr = new StreamReader(filePath))
            using (StreamWriter sw = new StreamWriter(tempFilePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Equals(existingEmployee.Employee_Code))
                    {
                        sw.WriteLine(updatedEmployee.Employee_Code);
                        sw.WriteLine(updatedEmployee.Name);
                        sw.WriteLine(updatedEmployee.Position);
                        sw.WriteLine(updatedEmployee.Salary);
                        sw.WriteLine(updatedEmployee.WorkSchedule);
                    }
                    else
                    {
                        sw.WriteLine(line);
                    }
                }
            }

            // Закрываем и удаляем исходный файл
            File.Delete(filePath);

            // Переименовываем временный файл в исходный
            File.Move(tempFilePath, filePath);

            Console.WriteLine($"Данные о сотруднике '{existingEmployee.Name}' обновлены.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при обновлении данных о сотруднике: {ex.Message}");
        }
    }

    // Метод для удаления сотрудника
    public void DeleteEmployee(Employee employee)
    {
        try
        {
            string filePath = Path.Combine(_employeesDirectory, $"{employee.Name}.txt");

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
}
