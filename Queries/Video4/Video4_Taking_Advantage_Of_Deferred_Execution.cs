using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Queries.Core.Domain;
using Queries.Extensions;

namespace Queries.Video4
{
    public class Video4_Taking_Advantage_Of_Deferred_Execution
    {
        public static void Video4_Taking_Advantage_Of_Deferred_Execution_Start()
        {
            Console.WriteLine("");
            Console.WriteLine("Video4_Taking_Advantage_Of_Deferred_Execution");
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
            var queryMethodSyntax = MoviesList.FilterYield(m => m.Year > 2000);

            Console.WriteLine("");

            var enumerator = queryMethodSyntax.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Title);
            }

            Console.WriteLine("");

            var queryMethodSyntax1 = MoviesList.FilterYield(m => m.Year > 2000).Take(1);

            var enumerator1 = queryMethodSyntax1.GetEnumerator();
            while (enumerator1.MoveNext())
            {
                Console.WriteLine(enumerator1.Current.Title);
            }
            
            Console.WriteLine("");

            var queryMethodSyntax2 = MoviesList.FilterYield(m => m.Year > 2000);

            var queryMethodSyntax2Later = queryMethodSyntax2.Take(1);

            var enumerator2 = queryMethodSyntax2Later.GetEnumerator();
            while (enumerator2.MoveNext())
            {
                Console.WriteLine(enumerator2.Current.Title);
            }

            Console.WriteLine("");

            var queryMethodSyntax3 = MoviesList.Filter(m => m.Year > 2000);

            var queryMethodSyntax3Later = queryMethodSyntax3.Take(1);

            var enumerator3 = queryMethodSyntax3Later.GetEnumerator();
            while (enumerator3.MoveNext())
            {
                Console.WriteLine(enumerator3.Current.Title);
            }
        }
    }
}
