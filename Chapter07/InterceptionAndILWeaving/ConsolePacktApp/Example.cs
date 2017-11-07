using System;

namespace ConsolePacktApp
{
    // For Interception. If you want to try IL Weaving, then comment this block and uncomment the block after this.
    public class Example : IExample
    {
        public void PrintName(string FirstName, string LastName)
        {
            // Uncomment the below line to throw exception and see the change in output.
            //throw new Exception();
            Console.WriteLine($"Name is {FirstName} {LastName}");
        }
    }

    // For IL Weaving, comment above class and uncomment below class.
    //public class Example : IExample
    //{
    //    [LoggingWeaverAspect]
    //    public void PrintName(string FirstName, string LastName)
    //    {
    //        Console.WriteLine($"Name is {FirstName} {LastName}");
    //    }
    //}
}
