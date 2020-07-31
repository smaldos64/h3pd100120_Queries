using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Queries.Core.Domain;
using Queries.Extensions;

namespace Queries.Video4
{
    class Video4_Avoiding_Pittfalls_Of_Deferred_Execution
    {
        public static void Video4_Avoiding_Pittfalls_Of_Deferred_Execution_Start()
        {
            Console.WriteLine("");
            Console.WriteLine("Video4_Avoiding_Pittfalls_Of_Deferred_Execution");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("");

            var MoviesList = new List<Movie>
            {
                new Movie {Title = "The Dark knight", Rating = 8.9f, Year = 2002},
                new Movie {Title = "The King's Speech", Rating = 8.0f, Year = 2004},
                new Movie {Title = "Casablanca", Rating = 8.5f, Year = 1998},
                new Movie {Title = "Star Wars V", Rating = 8.7f, Year = 1996}
            };

            // Where er en extension metode til IEnumerable<T>
            var queryMethodSyntaxDeferredExecution = MoviesList.FilterYield(m => m.Year > 2000);

            Console.WriteLine(queryMethodSyntaxDeferredExecution.Count());

            Console.WriteLine("");

            var enumerator = queryMethodSyntaxDeferredExecution.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Title);
            }

            // I situationen herover er Deferred Execution ikke en god ting, da vi går igenenm listen 2 gange.
            // Én gang for at finde antal elementer i listen => Count. Og én gang for at udskrive 
            // titlen i alle listens elementer. 
            
            Console.WriteLine("");
            Console.WriteLine("");

            var queryMethodSyntaxNoDeferredExecutionList = MoviesList.FilterYield(m => m.Year > 2000).ToList();
            // Når man bruger en Toxx operation på et LINQ Query resultat, tager man denne liste og laver 
            // en faktisk repræsentation af dette resultat i memory. I tilfældet her anvender vi ToList.
            // Vi behøver således aldrig udføre en LINQ query igen op imod det sted, hvor vi oprindeligt
            // hentede vores data fra, da vi nu har dem i memory i vores liste => 
            // queryMethodSyntaxNoDeferredExecutionList. 

            Console.WriteLine("");

            Console.WriteLine(queryMethodSyntaxNoDeferredExecutionList.Count());

            Console.WriteLine("");

            var enumerator1 = queryMethodSyntaxNoDeferredExecutionList.GetEnumerator();
            while (enumerator1.MoveNext())
            {
                Console.WriteLine(enumerator1.Current.Title);
            }
        }
    }
}
