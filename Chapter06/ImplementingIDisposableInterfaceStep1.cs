using System;
using System.Collections.Generic;

namespace PacktConsoleAppp
{
    class Program
    {
        static void Main(string[] args)
        {
            ExampleIDisposable disposable = new ExampleIDisposable(new Dictionary<int, string> {
                { 5, "Object Composition" },
                { 6, "Object Lifetime" }
			});

            disposable.Dispose();

            Console.ReadLine();
        }
    }

    class ExampleIDisposable : IDisposable
    {
        public Dictionary<int, string> Chapters { get; set; }

        public ExampleIDisposable(Dictionary<int, string> chapters)
        {
            // Managed resources
            Console.WriteLine("Managed Resources acquired");
            Chapters = chapters;

            // Some Unmanaged resources
            Console.WriteLine("Unmanaged Resources acquired");
        }

        public void Dispose()
        {
            Console.WriteLine("Someone called Dispose");

            // Dispose managed resources
            if (Chapters != null)
            {
                Chapters = null;
            }

            // Dispose unmanaged resources
        }
    }
}