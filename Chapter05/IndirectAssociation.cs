using System;
using System.Collections.Generic;

namespace DependencyExamples
{
	class Program
	{
		static void Main(string[] args)
		{
			SoftwareEngineer softEng = new SoftwareEngineer("Tworit Dash", 3);
			
			// Get the Laptop object from AvailableLaptops class by id.
			Laptop usedLaptop = AvailableLaptops.GetLaptop(3);

			Console.WriteLine(softEng.Name + " is using " + usedLaptop.LaptopName);
			Console.ReadLine();
		}
	}

	public class SoftwareEngineer
	{
		public string Name { get; set; }
		public int LaptopId { get; set; }

		public SoftwareEngineer(string name, int laptopId)
		{
				Name = name;
				LaptopId = laptopId;
		}
	}

	public class Laptop
	{
		public int LaptopId { get; set; }
		public string LaptopName { get; set; }

		public Laptop(int id, string name)
		{
				LaptopId = id;
				LaptopName = name;
		}
	}

	public class AvailableLaptops
	{
		public static List<Laptop> Laptops { get; set; }

		static AvailableLaptops()
		{
				Laptops = new List<Laptop>
				{
						new Laptop(1, "Laptop1"),
						new Laptop(2, "Laptop2"),
						new Laptop(3, "Laptop3"),
						new Laptop(4, "Laptop4"),
				};
		}

		public static Laptop GetLaptop(int id)
		{
				return Laptops.Find(l => l.LaptopId == id);
		}
	}
}