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
                { "Anna", true },                           //Lägger till nyckeln "Anna" i dictionaryn med värdet true
                { "John", true },                          //  ---//---
                { "Alice", true },                        //  ---//---
                { "Bob", true },                         //  ---//---
                { "Carol", true }                       //  ---//---
            };

            // Förbättring: Metod för att skriva ut dictionaryns nycklar, vilket skapar renare och mer återanvändbar kod.
            PrintDictionary("Original list", names);                                 //Anropar PrintDictionary-metoden jag skapat för att skriva ut dictionaryns nycklar som i detta fall är namn.

            // Sortera nycklarna i dictionaryn
            // Förbättring: Vi använder en separat lista för att sortera namnen medan vi fortfarande behåller den snabba
            // uppslagningen av dictionaryn. Dictionaryn lagrar elementen osorterade, men vi kan enkelt hämta en sorterad lista.
            List<string> sortedNames = new List<string>(names.Keys);                    //Skapar en lista med nycklarna från dictionaryn för att kunna sortera dem.
            sortedNames.Sort(StringComparer.Create(CultureInfo.CurrentCulture, true)); //Sorterar listan enligt aktuella kultur regler, vilket hanterar lokaliserade tecken.
            PrintList("Sorted list", sortedNames);                                    //Anropar PrintList-metoden för att skriva ut den sorterade listan.

            // Sök efter namn
            Console.WriteLine("Enter name to search:");                              //Uppmanar användaren att skriva in namn.
            // ?.Trim() hanterar null-värden och tar bort mellanslag från inmatningen
            string searchName = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(searchName))                                   //Kontroll som kollar så att användaren inte matar in en tom eller null-sträng.
            {
                // Förbättring: Felhantering för att säkerställa att användaren inte lämnar ett tomt namn.
                Console.WriteLine("Invalid input. Please enter a valid name."); //Throwar felmeddelande om inmatning är felaktig.
                return;                                                         //Sedan avslutas programmet här
            }

            // Kontrollera om namnet finns i dictionaryn
            // Förbättring: Användning av dictionary ger snabbare sökningar med O(1) istället för O(n) som i listan,
            // vilket gör programmet mer effektivt för större datamängder.
            if (names.ContainsKey(searchName))
            {
                Console.WriteLine($"{searchName} is in the list.");                     //meddelar om namnet hittades.
            }
            else
            {
                Console.WriteLine($"{searchName} is not in the list.");                 //meddelar om namnet inte hittades.
            }

            Console.ReadKey();                                                         //Väntar på att användaren ska trycka på en knapp innan programmet avslutas.
        }

        // Metod för att skriva ut dictionary med enbart nycklar(namn)
        // Förbättring: Koden för att skriva ut dictionary har extraherats till en metod, vilket minskar upprepning och gör koden mer läsbar.
        static void PrintDictionary(string title, Dictionary<string, bool> dictionary)
        {
            Console.WriteLine($"{title}:");                                           //Skriver ut titel "Original list:".
            foreach (var pair in dictionary)                                         //itererar igenom dictionaryns nycklar och skriver ut varje namn.
            {
                Console.WriteLine(pair.Key);                                        //skriver ut varje namn
            }
            Console.WriteLine();                                                   //skriver ut en tom rad efter listan för bättre läsbarhet.
        }

        // Metod för att skriva ut en lista med nycklar
        // Förbättring: Separat metod för att skriva ut en lista ger bättre återanvändbarhet och struktur.
        static void PrintList(string title, IEnumerable<string> names)
        {
            Console.WriteLine($"{title}:");                                       //Skriver ut titeln "Sorted list:"
            foreach (var name in names)                                          //Itererar igenom listan och skriver ut varje namn.
            {
                Console.WriteLine(name);                                        //Skriver ut varje namn.
            }
            Console.WriteLine();                                               //Skriver ut en tom rad efter listan för bättre läsbarhet.
        }
    }
}
