using Castle.Windsor;
using System;

namespace ConsolePacktApp
{
    class Program
    {
        private static IWindsorContainer _container;

        // This is for testing Interception. If you want to test IL Weaving,
        // comment this block and uncomment the other Main method present after this block. 
        static void Main(string[] args)
        {
            _container = new WindsorContainer();
            _container.Register(new ExampleRegistration());

            var example = _container.Resolve<IExample>();

            try
            {
                example.PrintName("Gobinda", "Dash");
            }
            catch
            {
            }

            Console.ReadKey();
        }

        // For IL Weaving, uncomment the below Main block. Comment the above Main.
        //static void Main(string[] args)
        //{
        //    try
        //    {
        //        Example example = new Example();
        //        example.PrintName("Gobinda", "Dash");
        //    }
        //    catch
        //    {
        //    }

        //    Console.ReadKey();
        //}
    }
}
