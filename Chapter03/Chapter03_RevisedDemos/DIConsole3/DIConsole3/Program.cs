using System;
using Microsoft.Extensions.DependencyInjection;

namespace DIConsole3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dependency Injection Demo (3)");
            Console.WriteLine("Alternative implementations and Guids");
            Console.WriteLine("-------------------------------------");
            var services = new ServiceCollection();
            services.AddSingleton<IXMLWriter, XMLWriter>();
            var provider = services.BuildServiceProvider();

            var XMLInstance = provider.GetService<IXMLWriter>();
            XMLInstance.WriteXML();

            var XMLInstance2 = ServiceProviderServiceExtensions.
                              GetService<IXMLWriter>(provider);
            XMLInstance2.WriteXML();

            // Provider via DefaultServiceProviderFactory
            //var factory = new DefaultServiceProviderFactory();
            //IServiceProvider prov = factory.CreateServiceProvider(services);

            // Provider via ServiceCollectionContainerBuilderExtensions
            //IServiceProvider prov = ServiceCollectionContainerBuilderExtensions.
            //                        BuildServiceProvider(services);
            //var XMLInstance = prov.GetService<IXMLWriter>();
            //XMLInstance.WriteXML();

            Console.ReadLine();
        }
    }

    public interface IXMLWriter
    {
        void WriteXML();
    }
    public interface IJSONWriter
    {
        void WriteJSON();
    }
    public class XMLWriter : IXMLWriter
    {
        public readonly Guid id;
        public XMLWriter()
        {
            id = Guid.NewGuid();
        }
        public void WriteXML()
        {
            Console.WriteLine("<message>Writing in XML Format</message>\n" + 
                               $"Guid: {this.id}");
        }
    }
    public class XMLWriter2 : IXMLWriter
    {
        public readonly Guid id;
        public XMLWriter2()
        {
            id = Guid.NewGuid();
        }
        public void WriteXML()
        {
            Console.WriteLine("<message>Writing in XML Format (2)</message>\n" +
                             $"Guid: {this.id}");
        } 
    }

    public class JSONWriter : IJSONWriter
    {
        public readonly Guid id;
        public JSONWriter()
        {
            id = Guid.NewGuid();
        }
        public void WriteJSON()
        {
            Console.WriteLine("{'message': 'Writing in JSON Format'} \n" + 
                              $"Guid: {id}");
        }
    }
    public class JSONWriter2 : IJSONWriter
    {
        public readonly Guid id;
        public JSONWriter2()
        {
            id = Guid.NewGuid();
        }
        public void WriteJSON()
        {
            {
                Console.WriteLine("{'message': 'Writing in JSON Format (2)'} \n" +
                                  $"Guid: {id}");
            }
        }
    }
}