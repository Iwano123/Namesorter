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
        {
            // Skapa en dictionary med namn som nycklar och bools som värde för att markera om de finns i listan
            // Förbättring: Användning av Dictionary med StringComparer.OrdinalIgnoreCase gör sökningen skiftlägesokänslig,
            // vilket förbättrar användarupplevelsen. 
            Dictionary<string, bool> names = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase)
            {
                { "Anna", true },
                { "John", true },
                { "Alice", true },
                { "Bob", true },
                { "Carol", true }
            };

            // Förbättring: Metod för att skriva ut dictionaryns nycklar, vilket skapar renare och mer återanvändbar kod.
            PrintDictionary("Original list", names);

            // Sortera nycklarna i dictionaryn
            // Förbättring: Vi använder en separat lista för att sortera namnen medan vi fortfarande behåller den snabba
            // uppslagningen av dictionaryn. Dictionaryn lagrar elementen osorterade, men vi kan enkelt hämta en sorterad lista.
            List<string> sortedNames = new List<string>(names.Keys);
            sortedNames.Sort(StringComparer.Create(CultureInfo.CurrentCulture, true));
            PrintList("Sorted list", sortedNames);

            // Sök efter namn
            Console.WriteLine("Enter name to search:");
            // ?.Trim() hanterar null-värden och tar bort mellanslag från inmatningen
            string searchName = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(searchName))
            {
                // Förbättring: Felhantering för att säkerställa att användaren inte lämnar ett tomt namn.
                Console.WriteLine("Invalid input. Please enter a valid name.");
                return;
            }

            // Kontrollera om namnet finns i dictionaryn
            // Förbättring: Användning av dictionary ger snabbare sökningar med O(1) istället för O(n) som i listan,
            // vilket gör programmet mer effektivt för större datamängder.
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

        // Metod för att skriva ut dictionary med enbart nycklar
        // Förbättring: Koden för att skriva ut dictionary har extraherats till en metod, vilket minskar upprepning och gör koden mer läsbar.
        static void PrintDictionary(string title, Dictionary<string, bool> dictionary)
        {
            Console.WriteLine($"{title}:");
            foreach (var pair in dictionary)
            {
                Console.WriteLine(pair.Key);
            }
            Console.WriteLine();
        }

        // Metod för att skriva ut en lista med nycklar
        // Förbättring: Separat metod för att skriva ut en lista ger bättre återanvändbarhet och struktur.
        static void PrintList(string title, IEnumerable<string> names)
        {
            Console.WriteLine($"{title}:");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
        }
    }
}
