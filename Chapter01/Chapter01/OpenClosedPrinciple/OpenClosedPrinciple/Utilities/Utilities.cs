using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

internal class Utilities
{
    /* This version uses the Book[] approach, instead of List<Book> */
    //internal static Book[] ReadData()
    //{
    //    var cadJSON = ReadFile("Data/BookStore.json");
    //    return JsonConvert.DeserializeObject<Book[]>(cadJSON);
    //}
    //internal static Book[] ReadData(int numEntries)
    //{
    //    Book[] books = new Book[numEntries];
    //    ReadData().CopyTo(books, 0);
    //    if (numEntries == 10)
    //    {
    //        var cadJSON = ReadFile("Data/BookStore2.json");
    //        var books2 = JsonConvert.DeserializeObject<Book[]>(cadJSON);
    //        books2.CopyTo(books, 5);
    //    }
    //    return books;
    //}

    internal static List<Book> ReadData()
    {
        var cadJSON = ReadFile("Data/BookStore.json");
        return JsonConvert.DeserializeObject<List<Book>>(cadJSON);
    }

    internal static List<Book> ReadData(string extra)
    {
        List<Book> books = ReadData();
        var cadJSON = ReadFile("Data/BookStore2.json");
        books.AddRange(JsonConvert.DeserializeObject<List<Book>>(cadJSON));
        return books;
    }

    static string ReadFile(string filename)
    {
        return File.ReadAllText(filename);
    }
}
