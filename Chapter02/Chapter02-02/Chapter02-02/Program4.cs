using System;
using StructureMap;
using StructureMap.Configuration;

namespace Chapter02_02.StructureMap
{
    // UI Layer
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, select reading type (XML, JSON)");
            // we asume a predefault value
            var format = (Console.ReadLine() != "xml") ? "json" : "xml";
            var container = new Container();
            container = new Container(x => {
                x.For<IBookReader>().Add<XMLBookReader>().Named("xml");
                x.For<IBookReader>().Add<JSONBookReader>().Named("json");
            });
            var ibr = container.GetInstance<IBookReader>(format);
            ibr.ReadBooks();
            Console.ReadLine();
            // clean up, application exits
            container.Dispose();
        }
    }
    // Business Logic Layer
    //public class BookManager
    //{
    //    public IBookReader bookReader;
    //    public BookManager(IBookReader reader)
    //    {
    //        bookReader = reader;
    //    }
    //    public void ReadBooks()
    //    {
    //        bookReader.ReadBooks();
    //    }
    //}
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
