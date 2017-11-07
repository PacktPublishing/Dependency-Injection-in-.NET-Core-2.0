using System;

namespace Chapter02_02
{
    // UI Layer
    class Program
    {
        static void Main(string[] args)
        {
            BookManager bm;
            Console.WriteLine("Please, select reading type (XML, JSON)");
            var ans = Console.ReadLine();
            if (ans.ToLower() == "xml")
            {
                bm = new BookManager(new XMLBookReader());
            }
            else { bm = new BookManager(new JSONBookReader()); }
            bm.ReadBooks();
            Console.ReadLine();
        }
    }

    // Business Logic Layer
    public class BookManager
    {
        public IBookReader bookReader;
        public BookManager(IBookReader reader)
        {
            bookReader = reader;
        }
        public void ReadBooks()
        {
            bookReader.ReadBooks();
        }
    }

    // Data Access Layer
    public interface IBookReader
    {
        void ReadBooks();
    }
    public class XMLBookReader : IBookReader
    {
        public void ReadBooks()
        {
            Console.WriteLine("Books read in XML Format");
        }
    }
    public class JSONBookReader : IBookReader
    {
        public void ReadBooks()
        {
            Console.WriteLine("Books read in JSON Format");
        }
    }
}
