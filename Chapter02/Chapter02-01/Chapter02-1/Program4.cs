using System;
using System.Collections.Generic;

namespace Chapter02_1.Version4
{
    // In version 4, Dependency Injection is performed via Property Injection
    // Also using tuples to express related values of Console colors.
    class Program4
    {
        static ConsoleDisplayFactory cdf = new ConsoleDisplayFactory();
        static void Main(string[] args)
        {
            // Initial config
            cdf.ConfigureConsole("default");
            Console.BackgroundColor = cdf.BackColor;
            Console.ForegroundColor = cdf.ForeColor;
            Console.WriteLine("Console Information");
            Console.WriteLine("-------------------");
            Console.WriteLine("Initial configuration: \n");
            Console.WriteLine($"Back Color: { cdf.BackColor}");
            Console.WriteLine($"Fore Color: { cdf.ForeColor }");
            // User's config
            Console.WriteLine("New theme ('light', 'dark', 'Enter'=>default):");
            var newTheme = Console.ReadLine();
            cdf.ConfigureConsole(newTheme);
            Console.BackgroundColor = cdf.BackColor;
            Console.ForegroundColor = cdf.ForeColor;
            Console.WriteLine("New configuration: \n");
            Console.WriteLine($"Back Color: { cdf.BackColor}");
            Console.WriteLine($"Fore Color: { cdf.ForeColor }");
            Console.ReadLine();
        }
    }
    public class ConsoleDisplayFactory
    {
        // Both properties asume a default (initial) configuration
        public ConsoleColor ForeColor { get; set; } = ConsoleColor.White;
        public ConsoleColor BackColor { get; set; } = ConsoleColor.Black;
        public ConsoleDisplayFactory ConfigureConsole (string theme)
        {
            switch (theme)
            {
                case "light":
                    BackColor = ConsoleColor.Yellow;
                    ForeColor = ConsoleColor.DarkBlue;
                    break;
                case "dark":
                    BackColor = ConsoleColor.DarkBlue;
                    ForeColor = ConsoleColor.Yellow;
                    break;
                default:
                    break;
            }
            return this;
        }
    }
}

