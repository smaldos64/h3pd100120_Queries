using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Queries.Core.Domain;
using Queries.Extensions;

namespace Queries.Video4
{
    class Video4_Creating_A_Custom_Filter_Operation
    {
        // Third Execution 
        public static void Video4_Creating_A_Custom_Filter_Operation_start()
        {
            Console.WriteLine("");
            Console.WriteLine("Video4_Creating_A_Custom_Filter_Operation");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("");

            var MoviesList = new List<Movie>
            {
                new Movie {Title = "The Dark knight", Rating = 8.9f, Year = 2002},
                new Movie {Title = "The King's Speech", Rating = 8.0f, Year = 2004},
                new Movie {Title = "Casablanca", Rating = 8.5f, Year = 1998},
                new Movie {Title = "Star Wars V", Rating = 8.7f, Year = 1996}
            };

            // Where er en extension metode til IEnumerable<T>
            var queryMethodSyntax = MoviesList.Where(m => m.Year > 2000);

            foreach (var movie in queryMethodSyntax)
            {
                Console.WriteLine(movie.Title);
            }
            Console.WriteLine("");

            var queryMethodSyntax1 = MoviesList.Filter(m => m.Year > 2000);
           
            foreach (var movie in queryMethodSyntax1)
            {
                Console.WriteLine(movie.Title);
            }

            Console.WriteLine("");

            var queryMethodSyntax2 = MoviesList.Filter(m => m.Year > 2000);
            // Vores Custom Filter operation kører altid, uanset om vi skriver resultatet ud 
            //bagefter eller ej

            Console.WriteLine("");

            var queryMethodSyntax3 = MoviesList.FilterYield(m => m.Year > 2000);

            foreach (var movie in queryMethodSyntax3)
            {
                Console.WriteLine(movie.Title);
            }

        }
    }
}
