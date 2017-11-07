using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Logging.Debug;

namespace LoggerFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            // Enabling logging with the ServiceCollection
            var services = new ServiceCollection()
                .AddSingleton<IXMLWriter, XMLWriter>()
                .AddLogging();
            var serviceProvider = services.BuildServiceProvider();

            // Test the register of AddLoggin()
            //foreach (var svc in services)
            //{
            //    Console.WriteLine($"Type: {svc.ImplementationType} \n" +
            //                      $"Lifetime: {svc.Lifetime} \n" +
            //                      $"Service Type: {svc.ServiceType}");

            //}

            //Obtain service and configure logging
            serviceProvider.GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug);

            // Create a logger class from ILoggerFactory
            // and print an initial message.
            var ILoggerService = serviceProvider.GetService<ILoggerFactory>();
            ILoggerService.AddDebug();
            var logger = ILoggerService.CreateLogger<Program>();

            logger.LogCritical("Critical format message from Program");
            logger.LogDebug("Debug format message from Program");
            logger.LogError("Error format message from Program");
            logger.LogInformation("Information format message from Program");
            logger.LogTrace("Trace format message from Program");
            logger.LogWarning("Warning format message from Program");

            //Instantiation of XMLInstance
            var XMLInstance = serviceProvider.GetService<IXMLWriter>();
            XMLInstance.WriteXML();
            //XMLInstance.WriteXMLWithSeverityLevel();

            logger.LogDebug("Process finished!");
            Console.Read();
        }
    }
    public interface IXMLWriter
    {
        void WriteXML();
        void WriteXMLWithSeverityLevel();
    }
    public class XMLWriter : IXMLWriter
    {
        private readonly ILogger<XMLWriter> logger;
        public XMLWriter(ILoggerFactory loggerFactory)
        {
            loggerFactory.AddDebug().AddConsole(LogLevel.Information);
            logger = loggerFactory.CreateLogger<XMLWriter>();
        }
        public void WriteXML()
        {
            logger.LogDebug(
                "<msg>First Message (LogDebug/SeverityLevel: Information)</msg>");
        }
        public void WriteXMLWithSeverityLevel()
        {
            logger.LogDebug(
                "<msg>Second Message (LogDebug/SeverityLevel: Information</msg>");
        }
    }
}