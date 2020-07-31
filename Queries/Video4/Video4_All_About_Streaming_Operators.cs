using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Queries.Core.Domain;
using Queries.Extensions;

namespace Queries.Video4
{
    public class Video4_All_About_Streaming_Operators
    {

        public static void Video4_All_About_Streaming_Operators_Start()
        {
            // Deferred Execution Operators => Streaming Operators eller Non Streaming Operators.
            // Where operatoren er en Deferred Execution Operator og en Streaming Operator.
            // OrderByDescending er en Deferred Execution Operator og ikke en Streaming Operator

            // Når man arbejder på data i memory som her, er det vigtigt, at vi udfører en filtrering => 
            // Where operator, før vi laver en sortering => OrderByDescending.
            // Dette skyldes, som nævnt ovenfor at Where er en Streaming Operator og 
            // OrderByDescending ikke er en Streaming Operator

            Console.WriteLine("");
            Console.WriteLine("Video4_All_About_Streaming_Operators");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("");

            var MoviesList = new List<Movie>
            {
                new Movie {Title = "The Dark knight", Rating = 8.9f, Year = 2002},
                new Movie {Title = "The King's Speech", Rating = 9.0f, Year = 2004},
                new Movie {Title = "Casablanca", Rating = 8.5f, Year = 1998},
                new Movie {Title = "Star Wars V", Rating = 8.7f, Year = 1996}
            };

            var queryMethodSyntaxDeferredExecution = MoviesList.FilterYield(m => m.Year > 2000);

            var enumerator = queryMethodSyntaxDeferredExecution.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Title);
            }

            Console.WriteLine("");

            // Den mest effektive måde da vi her filtrerer først og derefter sorterer.
            var queryMethodSyntaxDeferredExecutionOrder = MoviesList.FilterYield(m => m.Year > 2000).
                                                                     OrderByDescending(m => m.Rating);

            var enumeratorOrder = queryMethodSyntaxDeferredExecutionOrder.GetEnumerator();
            while (enumeratorOrder.MoveNext())
            {
                Console.WriteLine(enumeratorOrder.Current.Title);
            }

            Console.WriteLine("");

            // Ikke så effektiv som den forrige LINQ Query da vi her sorterer først og derefter filtrerer.
            var queryMethodSyntaxDeferredExecutionOrderReversed = MoviesList.OrderByDescending(m => m.Rating).FilterYield(m => m.Year > 2000);
            
            var enumeratorOrderReversed = queryMethodSyntaxDeferredExecutionOrderReversed.GetEnumerator();
            while (enumeratorOrderReversed.MoveNext())
            {
                Console.WriteLine(enumeratorOrderReversed.Current.Title);
            }

            Console.WriteLine("");

            var queryQuerySyntaxDeferredExecutionOrder = from movie in MoviesList
                                                         where movie.Year > 2000
                                                         orderby movie.Rating
                                                         select movie; 

            var enumeratorQueryOrder = queryQuerySyntaxDeferredExecutionOrder.GetEnumerator();
            while (enumeratorQueryOrder.MoveNext())
            {
                Console.WriteLine(enumeratorQueryOrder.Current.Title);
            }
        }
    }
}
