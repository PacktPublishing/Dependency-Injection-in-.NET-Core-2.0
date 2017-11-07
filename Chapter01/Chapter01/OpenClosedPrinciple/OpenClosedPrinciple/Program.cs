using System;
using System.Collections.Generic;
class Program
{
    static List<Book> bookList;
    static void Main(string[] args)
    {
        Console.WriteLine("Please, press 'yes' to read an extra file, ");
        Console.WriteLine("or any other key for a single file");
        var ans = Console.ReadLine();
        bookList = (ans != "yes") ? Utilities.ReadData() : Utilities.ReadData(ans);
        PrintBooks(bookList);
    }

    static void PrintBooks(List<Book> books)
    {
        Console.WriteLine(" List of Books by PACKT");
        Console.WriteLine(" ----------------------");
        foreach (var item in books)
        {
            Console.WriteLine($" {item.Title.PadRight(39, ' ')} " +
                $"{item.Author.PadRight(20, ' ')} {item.Price}");
        }
        Console.ReadLine();
    }
}