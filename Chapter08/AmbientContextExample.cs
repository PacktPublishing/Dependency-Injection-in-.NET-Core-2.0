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
                .AddTransient<MarketingProvider>()
                .BuildServiceProvider();

            // Set the Current value by resolving with MarketingProvider.
            DepartmentProvider.Current = serviceProvider.GetService<MarketingProvider>();

            Employee emp = serviceProvider.GetService<Employee>();
            emp.EmployeeId = 1;
            emp.EmployeeName = "Sasmita Tripathy";
            emp.EmployeeDept = DepartmentProvider.Current.Department;

            Employee emp1 = serviceProvider.GetService<Employee>();
            emp1.EmployeeId = 2;
            emp1.EmployeeName = "Ganeswar Tripathy";
            emp1.EmployeeDept = DepartmentProvider.Current.Department;

            Console.WriteLine("Emp Name: " + emp.EmployeeName + ", Department: " + emp.EmployeeDept.DeptName); // Marketing
            Console.WriteLine();
            Console.WriteLine("Emp Name: " + emp1.EmployeeName + ", Department: " + emp1.EmployeeDept.DeptName); // Marketing

            Console.ReadLine();
        }

        public class Employee
        {
            public int EmployeeId;
            public string EmployeeName;
            public IDepartment EmployeeDept;

            // Default Constructor added for .NET Core DI.
            // So that it can automatically create the instance.
            public Employee() { }

            public Employee(int id, string name)
            {
                EmployeeId = id;
                EmployeeName = name;
            }
        }

        public abstract class DepartmentProvider
        {
            private static DepartmentProvider current;

            public static DepartmentProvider Current
            {
                get
                {
                    if (current == null)
                        current = new DefaultDepartmentProvider();

                    return current;
                }
                set
                {
                    current = value ?? new DefaultDepartmentProvider();
                }
            }

            public virtual Department Department { get; }
        }


        public class DefaultDepartmentProvider : DepartmentProvider
        {
            public override Department Department
            {
                get { return new Engineering(); }
            }
        }

        class MarketingProvider : DepartmentProvider
        {
            public override Department Department
            {
                get { return new Marketing(); }
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