using Microsoft.Extensions.DependencyInjection;
using System;

namespace DIConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dependency Injection Demo");
            Console.WriteLine("Basic use of the Microsoft.Extensions.DependencyInjection Library");
            Console.WriteLine("-----------------------------------------------------------------");
            var services = new ServiceCollection();
            services.AddTransient<DependencyClass2>();
            services.AddTransient<DependencyClass1>();
            var provider = services.BuildServiceProvider();
            using (var DC1Instance = provider.GetService<DependencyClass1>())
            {
                // Merely by declaring DependencyClass1 
                // everything gets launched, but we also call
                // CurrentTime() just to check functionality
                DC1Instance.CurrentTime();
                // Notice also how classes are properly disposed
                // after used.

            }
            Console.ReadLine();
        }
    }

    public class DependencyClass1 : IDisposable
    {
        private readonly DependencyClass2 _DC2;
        public DependencyClass1(DependencyClass2 DC2instance)
        {
            _DC2 = DC2instance;
            Console.WriteLine("Constructor of DependencyClass1 finished");
        }
        public void CurrentTime()
        {
            string time = DateTime.Now.Hour.ToString() + ":" +
                          DateTime.Now.Minute.ToString() + ":" +
                          DateTime.Now.Second.ToString();
            Console.WriteLine($"Current time: {time}");
        }
        public void Dispose()
        {
            _DC2.Dispose();
            Console.WriteLine("DependencyClass1 disposed");
        }
    }

    public class DependencyClass2 : IDisposable
    {
        public DependencyClass2()
        {
            Console.WriteLine("Constructor of DependencyClass2 finished");
        }

        public void Dispose()
        {
            Console.WriteLine("DependencyClass2 Disposed");
        }
    }

}