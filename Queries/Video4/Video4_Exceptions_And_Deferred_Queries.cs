using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Queries.Core.Domain;
using Queries.Extensions;

namespace Queries.Video4
{
    public class Video4_Exceptions_And_Deferred_Queries
    {
        public static void Video4_Exceptions_And_Deferred_Queries_Start()
        {
            Console.WriteLine("");
            Console.WriteLine("Video4_Exceptions_And_Deferred_Queries");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("");

            var MoviesList = new List<Movie>
            {
                new Movie {Title = "The Dark knight", Rating = 8.9f, Year = 2002},
                new Movie {Title = "The King's Speech", Rating = 8.0f, Year = 2004},
                new Movie {Title = "Casablanca", Rating = 8.5f, Year = 1998},
                new Movie {Title = "Star Wars V", Rating = 8.7f, Year = 1996}
            };

            Movie.Set_Simulation_Error();

            // Where er en extension metode til IEnumerable<T>
            var queryMethodSyntax = Enumerable.Empty<Movie>();

            try
            {
                queryMethodSyntax = MoviesList.Where(m => m.Year > 2000).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(queryMethodSyntax.Count());

            Console.WriteLine("");

            var enumerator = queryMethodSyntax.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Title);
            }

            Console.WriteLine("");

            try
            {
                queryMethodSyntax = MoviesList.Where(m => m.Year > 2000);
                Console.WriteLine(queryMethodSyntax.Count());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Movie.Reset_Simulation_Error();

        }
    }
}
