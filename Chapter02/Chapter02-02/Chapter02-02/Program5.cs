using System;
using Autofac;
using Autofac.Core;
namespace Chapter02_02.Autofac
{
    // UI Layer
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, select reading type (XML, JSON)");
            // we asume a predefault value
            var builder = new ContainerBuilder();
            if (Console.ReadLine() != "json")
            {
                builder.RegisterType<XMLBookReader>().As<IBookReader>();
            }
            else
            {
                builder.RegisterType<JSONBookReader>().As<IBookReader>();
            }
            var container = builder.Build();
            var ibr = container.Resolve<IBookReader>();
            ibr.ReadBooks();
            Console.ReadLine();
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
