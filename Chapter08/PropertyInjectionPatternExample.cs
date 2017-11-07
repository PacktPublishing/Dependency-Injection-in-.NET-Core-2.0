using Microsoft.Extensions.DependencyInjection;
using System;

namespace DIPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee(1, "Sasmita Tripathy")
            {
                EmployeeDept = new Engineering()
            };

            Employee emp1 = new Employee(2, "Ganeswar Tripathy")
            {
                EmployeeDept = new Marketing()
            };
            Console.WriteLine("Emp Name: " + emp.EmployeeName + ", Department: " + emp.EmployeeDept.DeptName);
            Console.WriteLine();
            Console.WriteLine("Emp Name: " + emp1.EmployeeName + ", Department: " + emp1.EmployeeDept.DeptName);

            Console.ReadLine();
        }

        public class Employee
        {
            public int EmployeeId;
            public string EmployeeName;

            private IDepartment _employeeDept;
            public IDepartment EmployeeDept
            {
                get
                {
                    if (this._employeeDept == null)
                        this.EmployeeDept = new Engineering();

                    return this._employeeDept;
                }
                set
                {
                    if (value == null)
                        throw new ArgumentNullException("value");
                    if (this._employeeDept != null)
                        throw new InvalidOperationException();

                    this._employeeDept = value;
                }
            }

            public Employee(int id, string name)
            {
                EmployeeId = id;
                EmployeeName = name;
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