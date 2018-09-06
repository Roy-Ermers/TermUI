using System;
using TermUI;
namespace SelectBoxTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //exactly 100 first names.
            string[] persons = {"James","John","Robert","Michael","William","David","Richard","Charles","Joseph","Thomas","Christopher","Daniel","Paul","Mark","Donald","George","Kenneth","Steven","Edward","Brian","Ronald","Anthony","Kevin","Jason","Matthew","Gary","Timothy","Jose","Larry","Jeffrey","Frank","Scott","Eric","Stephen","Andrew","Raymond","Gregory","Joshua","Jerry","Dennis","Walter","Patrick","Peter","Harold","Douglas","Henry","Carl","Arthur","Ryan","Roger","Joe","Juan","Jack","Albert","Jonathan","Justin","Terry","Gerald","Keith","Samuel","Willie","Ralph","Lawrence","Nicholas","Roy","Benjamin","Bruce","Brandon","Adam","Harry","Fred","Wayne","Billy","Steve","Louis","Jeremy","Aaron","Randy","Howard","Eugene","Carlos","Russell","Bobby","Victor","Martin","Ernest","Phillip","Todd","Jesse","Craig","Alan","Shawn", "Clarence", "Sean", "Philip", "Chris", "Johnny", "Earl", "Jimmy", "Antonio" };
            Console.WriteLine("Select the matching fruit color.");
            string[] Options = new string[] { "Apples", "Pears", "Strawberries", "Oranges" };

            Search control = new Search(persons);
            control.SelectedColor = ConsoleColor.DarkRed;
            Console.WriteLine(persons[control.Read()]);
            Console.ReadKey();
        }
    }
}
