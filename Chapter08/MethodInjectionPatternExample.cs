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

            Employee emp = serviceProvider.GetService<Employee>();
            emp.EmployeeId = 1;
            emp.EmployeeName = "Sasmita Tripathy";
            emp.AssignDepartment(serviceProvider.GetService<IDepartment>());

            Employee emp1 = serviceProvider.GetService<Employee>();
            emp1.AssignDepartment(serviceProvider.GetService<IDepartment>());
            emp1.EmployeeId = 2;
            emp1.EmployeeName = "Ganeswar Tripathy";

            Console.WriteLine("Emp Name: " + emp.EmployeeName + ", Department: " + emp.EmployeeDept.DeptName);
            Console.WriteLine();
            Console.WriteLine("Emp Name: " + emp1.EmployeeName + ", Department: " + emp1.EmployeeDept.DeptName);

            Console.ReadLine();
        }

        public class Employee
        {
            public int EmployeeId;
            public string EmployeeName;
            public IDepartment EmployeeDept;

            // Default Constructor added for .NET Core 2.0 DI Container.
			// So that it can automatically create the instance.
            public Employee() { }

            public Employee(int id, string name)
            {
                EmployeeId = id;
                EmployeeName = name;
            }

            public void AssignDepartment(IDepartment dept)
            {
                EmployeeDept = dept ?? throw new ArgumentNullException("value");

                // Other business logic if required.
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

    }
}