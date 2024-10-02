using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string> { "Anna", "John", "Alice", "Bob", "Carol" };  //Går att effektivisera sökningen genom att byta till en dictionary där varje namn har en (Key), vi kan ha en bool som utfyllnadsvärde som bara returnerar true då namnen i listan redan är kända i detta fall.
            Console.WriteLine("Original list:");
            foreach (var name in names)                        //Går att skala ner programmet här och skapa en metod istället för att kunna skriva ut listan, vilket gör den återanvändbar.
            {
                Console.WriteLine(name);
            }
                                                                
            names.Sort();                                      //Anpassa sortering för kulturella kontexter genom att använda CultureInfo, eftersom den inte sorterar alfabetiskt
            Console.WriteLine("\nSorted list:");
            foreach (var name in names)                        //Går att skala ner programmet här och skapa en metod istället för att skriva ut sorterade listan, vilket gör den återanvändbar istället för att ha två foreach loopar och skriva ut det.
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("\nEnter name to search:");
            string searchName = Console.ReadLine();             //Implementera felhantering för att undvika fel vid sökning, skiftolägeskänslig sökning för att hantera små och stora bokstäver
            if (names.Contains(searchName))         
            {
                Console.WriteLine($"{searchName} is in the list.");
            }
            else
            {
                Console.WriteLine($"{searchName} is not in the list.");
            }
            Console.ReadKey();
        }
    }
}
