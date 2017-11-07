using System;
using System.IO;
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(" List of Books by PACKT");
        Console.WriteLine(" ----------------------");
        var cadJSON = ReadFile("Data/BookStore.json");
        var bookList = JsonConvert.DeserializeObject<Book[]>(cadJSON);
        foreach (var item in bookList)
        {
            Console.WriteLine($" {item.Title.PadRight(39,' ')} " + 
                $"{item.Author.PadRight(15,' ')} {item.Price}"); 
        }
        Console.Read();
    }

    static string ReadFile(string filename)
    {
        return File.ReadAllText(filename);
    }
}