using System;
using System.Collections.Generic;

namespace DependencyExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Address add = new Address("Nayagarh");
            Student rinu = new Student(1, "Jayashree Satapathy", new DateTime(1995, 11, 14), add);
            Student gudy = new Student(2, "Lipsa Rath", new DateTime(1995, 4, 23), add);

            rinu.PrintStudent();
            gudy.PrintStudent();

            Console.ReadKey();
        }
    }

    public class Student
    {
        private int Id { get; set; }
        private string Name { get; set; }
        private DateTime Dob { get; set; }
        private Address Address { get; set; }
        private ICollection<Book> Books { get; set; }

        public Student(int id, string name, DateTime dob, Address address)
        {
            Id = id;
            Name = name;
            Dob = dob;
			Address = address;
        }

        public void PrintStudent()
        {
            Console.WriteLine("Student: " + Name);
            Console.WriteLine("City: " + Address.City + "");
            Console.WriteLine("-----------------------");
        }
    }
	
	public class Address
    {
        public int AddressId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public Address(string city)
        {
            City = city;
        }
    }
	
	public class Book { }
}