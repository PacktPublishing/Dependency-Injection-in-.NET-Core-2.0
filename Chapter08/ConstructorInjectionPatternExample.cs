using Microsoft.Extensions.DependencyInjection;
using System;

namespace DIPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IDepartment, Engineering>()
                .AddTransient<Employee>()
                .BuildServiceProvider();

            var emp = serviceProvider.GetService<Employee>();
            emp.EmployeeId = 1;
            emp.EmployeeName = "Sasmita Tripathy";

            var emp1 = serviceProvider.GetService<Employee>();
            emp1.EmployeeId = 2;
            emp1.EmployeeName = "Ganeswar Tripathy";

            Console.WriteLine("Emp Name: " + emp.EmployeeName + ", Department: " + emp.GetEmployeeDepartment());
            Console.WriteLine();
            Console.WriteLine("Emp Name: " + emp1.EmployeeName + ", Department: " + emp1.GetEmployeeDepartment());

            Console.ReadLine();
        }

        public interface IDepartment
        {
            int DeptId { get; set; }
            string DeptName { get; set; }
        }

        public class Department : IDepartment
        {
            public int DeptId { get; set; }
            public string DeptName { get; set; }
        }

        public class Employee
        {
            public int EmployeeId;
            public string EmployeeName;
            private readonly IDepartment EmployeeDept;

            public Employee(IDepartment dept)
            {
                EmployeeDept = dept ?? throw new ArgumentNullException();
            }

            public string GetEmployeeDepartment()
            {
                return this.EmployeeDept.DeptName;
            }
        }

        public class Engineering : Department
        {
            public Engineering()
            {
                DeptName = "Engineering";
            }
        }

        public class Marketing : Department
        {
            public Marketing()
            {
                DeptName = "Marketing";
            }
        }
    }
}