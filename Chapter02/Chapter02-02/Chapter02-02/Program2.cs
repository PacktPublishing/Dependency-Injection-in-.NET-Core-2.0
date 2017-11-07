using System;
using Microsoft.Practices.Unity;
//using Microsoft.Practices.Unity.Configuration;
//using Microsoft.Practices.Unity.Utility;


namespace Chapter02_02.Unity
{
    // UI Layer
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, select reading type (XML, JSON)");
            // we asume a predefault value
            var format = (Console.ReadLine() != "xml") ? "json" : "xml";
            UnityContainer uc = new UnityContainer();
            uc.RegisterType<IBookReader, XMLBookReader>("xml");
            uc.RegisterType<IBookReader, JSONBookReader>("json");
            IBookReader ibr = uc.Resolve<IBookReader>(format);
            ibr.ReadBooks();
            Console.ReadLine();
        }
    }
    // Business Logic Layer
    public class UnityRegistration
    {
        public void Register(UnityContainer container)
        {
            container.RegisterTypes(
              AllClasses.FromAssemblies(GetType().Assembly),
              WithMappings.FromMatchingInterface,
              //WithMappings.FromAllInterfaces,
              WithName.Default,
              WithLifetime.ContainerControlled);
        }
    }
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
