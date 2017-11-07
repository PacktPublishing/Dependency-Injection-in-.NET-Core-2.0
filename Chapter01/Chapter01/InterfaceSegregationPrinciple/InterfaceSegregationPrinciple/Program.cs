using InterfaceSegregationPrinciple.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using InterfaceSegregationPrinciple.Utilities;

namespace InterfaceSegregationPrinciple
{
    class Program
    {
        static List<Product> productList;
        static void Main(string[] args)
        {
            string id = string.Empty;
            do
            {
                Console.WriteLine("File no. to read: 1/2/3-Enter(exit): ");
                id = Console.ReadLine();
                if ("123".Contains(id) && !String.IsNullOrEmpty(id))
                {
                    productList = Utilities.Utilities.ReadData(id);
                    PrintBooks(productList);
                }
            } while (!String.IsNullOrWhiteSpace(id));
        }

        static void PrintBooks(List<Product> products)
        {
            Console.WriteLine(" List of Products by PACKT");
            Console.WriteLine(" ----------------------");
            foreach (var item in products)
            {
                Console.WriteLine($" {item.Title.PadRight(36, ' ')} " +
                $"{item.Author.PadRight(20, ' ')} {item.Price}" + " " +
                $"{item.Topic?.PadRight(12, ' ') } " +
                $"{item.Duration ?? ""}");
            }
            Console.WriteLine();
        }



    }
}
