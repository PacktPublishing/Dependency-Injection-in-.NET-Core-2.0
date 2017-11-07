using System;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyExamples
{
    class Program
    {
        static void Main(string[] args)
        {
			ConfigureServices(new ServiceCollection());
			
			Console.ReadKey();
		}
		
		public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // Setup container and register dependencies.
            var serviceProvider = serviceCollection
            .AddTransient<IEmployeeService, EmployeeService>()
            .BuildServiceProvider();

            // Get the service instance from the conatiner and do actual operation.
            var emp = serviceProvider.GetService<IEmployeeService>();
            emp.HelloEmployee();
        }
	}
	
	public interface IEmployeeService
    {
        void HelloEmployee();
    }

    public class EmployeeService : IEmployeeService
    {
        public void HelloEmployee()
        {
            Console.WriteLine("Hello Employee");
        }
    }
}