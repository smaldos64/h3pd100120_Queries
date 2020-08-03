using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Queries.Files;

namespace Queries.Video5
{
    public class Video5_Flattering_Data_With_SelectMany
    {
        public static void Video5_Flattering_Data_With_SelectMany_Start()
        {
            Console.WriteLine("");
            Console.WriteLine("Video5_Flattering_Data_With_SelectMany");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("");

            var cars = ProcessDataFromFiles.ProcessCar("fuel.csv");

            Console.WriteLine("Method Syntax");
            Console.WriteLine("");

            string name = "Lars";
            IEnumerable<char> characters = "Lars";

            var queryMethodSyntax =
                cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
                                .OrderByDescending(c => c.Combined)
                                .ThenBy(c => c.Name)
                                .Select(c => c.Name);

            foreach (var car in queryMethodSyntax.Take(5))
            {
                foreach (var character in car)
                {
                    Console.Write($"{character} ");
                }
                Console.WriteLine("");
            }

            Console.WriteLine("");
            Console.WriteLine("Select Many");
            Console.WriteLine("");

            var queryMethodSyntaxSelectMany =
                cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
                                .OrderByDescending(c => c.Combined)
                                .ThenBy(c => c.Name)
                                .Take(5)
                                .SelectMany(c => c.Name);
            
            foreach (var character in queryMethodSyntaxSelectMany)
            {
                Console.Write($"{character}  ");
            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Select Many - Character");
            Console.WriteLine("");

            var result = queryMethodSyntaxSelectMany.OrderBy(c => c);

            foreach (var character in result)
            {
                Console.Write($"{character}  ");
            }

        }
    }
}
