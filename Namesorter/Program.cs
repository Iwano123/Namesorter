using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace NameSorter
{
    class Program
    {
        static void Main(string[] args)
        {   //Skapar en dictionary med namn som nycklar och bools som värde för att markera om de finns i listan
            Dictionary<string, bool> names = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase)
            {
                { "Anna", true },
                { "John", true },
                { "Alice", true },
                { "Bob", true },
                { "Carol", true }
            };

            //Sorterar nycklarna i dictionaryn
            List<string> sortedNames = new List<string>(names.Keys);
            sortedNames.Sort(StringComparer.Create(CultureInfo.CurrentCulture, true));
            PrintList("Sorted list", sortedNames);

            // Sök efter namn
            Console.WriteLine("Enter name to search:");
            string searchName = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(searchName))
            {
                Console.WriteLine("Invalid input. Please enter a valid name.");
                return;
            }


            //Kontrollera om namnet finns i dictionaryn
            if (names.ContainsKey(searchName))
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

    //Metod för att skriva ut dictionary med enbart nycklar
    static void PrintDictionary(string title, Dictionary<string, bool> dictionary)
    {
        Console.WriteLine($"{title}:");
        foreach (var pair in dictionary)
        {
            Console.WriteLine(pair.Key);
        }
    }

    //Metod för att skriva ut en lista med nycklar
    static void PrintList(string title, IEnumerable<string> names)
    {
        Console.WriteLine($"{title}:");
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }
}