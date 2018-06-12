using System;
using TermUI;
namespace SelectBoxTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select the matching fruit color.");
            string[] Options = new string[] { "Apples", "Pears", "Strawberries", "Oranges" };
            Select control = new Select(Options);
            control.SelectedColor = ConsoleColor.DarkRed;
            control.Read();


            Console.WriteLine("Select the matching fruit color.");
            control.SelectedColor = ConsoleColor.Green;
            control.Read();

            Console.WriteLine("Select the matching fruit color.");
            control.SelectedColor = ConsoleColor.Red;
            control.Read();

            Console.WriteLine("Select the matching fruit color.");
            control.SelectedColor = ConsoleColor.DarkYellow;
            control.Read();
            Console.ReadKey();


        }
    }
}
