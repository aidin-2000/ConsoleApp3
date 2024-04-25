using ConsoleApp3.Controller;
using ConsoleApp3.Models;
using System.Xml.Linq;
using static ConsoleApp3.Models.Products;
using static ConsoleApp3.Models.Restaurant;
using static ConsoleApp3.Controller.EmployeeController;


public class EmployeeViews
{
    private readonly string _employeesDirectory;

    public EmployeeViews(string employeesDirectory)
    {
        _employeesDirectory = employeesDirectory;
    }

    public void AddEmployee()
    {
        int employee_code = 0;
        Console.WriteLine("Enter Name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter Position:");
        string position = Console.ReadLine();

        Console.WriteLine("Enter Salary:");
        decimal salary = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Enter Work Schedule:");
        string workSchedule = Console.ReadLine();

        Employee employee = new Employee(employee_code, name, position, salary, workSchedule);
        EmployeeController1 vasyaController = new EmployeeController1(employee);
        vasyaController.Save();
        Console.WriteLine("Client saved!");


        Console.WriteLine("Employee saved successfully.");
    }

    public void DisplayEmployees()
    {
        EmployeeController1 employeeController = new EmployeeController1(_employeesDirectory);
        List<Employee> employees = employeeController.GetAllEmployees();

        Console.WriteLine("List of Employees:");
        string header = "Code".PadRight(10) + "Name".PadRight(20) + "Position".PadRight(20) + "Salary".PadRight(15) + "Work Schedule";

        Console.WriteLine(header);
        foreach (Employee employee in employees)
        {
            string employeeData = $"{employee.Employee_Code}".PadRight(10) +
                                  $"{employee.Name}".PadRight(20) +
                                  $"{employee.Position}".PadRight(20) +
                                  $"{employee.Salary}".PadRight(15) +
                                  $"{employee.WorkSchedule}";

            Console.WriteLine(employeeData);
        }
    }

    /*public void DeleteEmployee(int employeeCode)
    {
        EmployeeController1 employeeController = new EmployeeController1(_employeesDirectory);
        employeeController.DeleteEmployee(employeeCode);

        Employee employeeToDelete = new Employee("employee4");
        employeeController.DeleteEmployee(employeeToDelete);

        Console.WriteLine($"Employee with code {employeeCode} deleted successfully.");
    }

    public void EditEmployee(int employeeCode, string name, string position, decimal salary, string workSchedule)
    {
        EmployeeController1 employeeController = new EmployeeController1(_employeesDirectory);
        Employee existingEmployee = employeeController.GetEmployeeByCode(employeeCode);

        if (existingEmployee != null)
        {
            Employee updatedEmployee = new Employee(employeeCode, name, position, salary, workSchedule);
            employeeController.UpdateEmployee(existingEmployee, updatedEmployee);

            Console.WriteLine($"Employee with code {employeeCode} updated successfully.");
        }
        else
        {
            Console.WriteLine($"Employee with code {employeeCode} not found.");
        }*/
    //}
}

