using System;

namespace SeparationResp1
{
    class Program
    {
        static void Main(string[] args)
        {
            /* This is version 1 */
            //Console.ResetColor();
            //Console.WriteLine("This is the default configuration for Console");
            //Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.WriteLine("Color changed...");
            //Console.Read();
            /* This is version 2 (with utilities) */
            ConsoleService cs = new ConsoleService();
            cs.ResetConsoleValues();
            Console.WriteLine("This is the default configuration for Console");
            cs.ChangeForegroundColor(ConsoleColor.Cyan);
            Console.WriteLine("Color changed...");
            Console.Read();
        }
    }

    public class ConsoleService
    {
        public void ChangeForegroundColor(ConsoleColor newColor)
        {
            Console.ForegroundColor = newColor;
        }
        public void ResetConsoleValues()
        {
            Console.ResetColor();
        }
    }

}
