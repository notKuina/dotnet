using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeFilterLINQ
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Thors", Address = "Kathmandu", Salary = 60000 },
                new Employee { Id = 2, Name = "Thorffin", Address = "Pokhara", Salary = 45000 },
                new Employee { Id = 3, Name = "Thorgil", Address = "Kathmandu", Salary = 55000 },
                new Employee { Id = 4, Name = "Ohana", Address = "Lalitpur", Salary = 70000 },
                new Employee { Id = 5, Name = "Shyunsui", Address = "Kathmandu", Salary = 40000 }
            };

            var filteredEmployees = employees
                .Where(emp => emp.Salary > 50000 && emp.Address == "Kathmandu");

            Console.WriteLine("Employees with salary > 50000 and address 'Kathmandu':");
            foreach (var employee in filteredEmployees)
            {
                Console.WriteLine($"Id: {employee.Id}, Name: {employee.Name}, Address: {employee.Address}, Salary: {employee.Salary}");
            }
        }
    }
}
