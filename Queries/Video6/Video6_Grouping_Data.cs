using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Queries.Extensions;
using Queries.Files;

namespace Queries.Video6
{
    public class Video6_Grouping_Data
    {
        public static void Video6_Grouping_Data_Start()
        {
            Console.WriteLine("");
            Console.WriteLine("Video6_Grouping_Data");
            Console.WriteLine("--------------------");
            Console.WriteLine("");

            var cars = ProcessDataFromFiles.ProcessCar("fuel.csv");
            var manufacturers = ProcessDataFromFiles.ProcessManufacturers("manufacturers.csv");

            // Query Syntax herunder

            var queryQuerySyntax =
                from car in cars
                group car by car.Manufacturer;

            Console.WriteLine("Query Syntax");
            Console.WriteLine("");

            foreach (var group in queryQuerySyntax)
            {
                Console.WriteLine($"{group.Key}har {group.Count()} cars");
                // group by giver et Key felt !!!
            }

            Console.WriteLine("");

            foreach (var group in queryQuerySyntax)
            {
                Console.WriteLine(group.Key);
                foreach (var car in group.OrderByDescending(c => c.Combined).Take(2))
                {
                    Console.WriteLine($"\t{car.Name} : {car.Combined}");
                }
                Console.WriteLine("");
            }

            var queryQuerySyntax1 =
                from car in cars
                group car by car.Manufacturer.ToUpper() into manufacturer
                orderby manufacturer.Key
                select manufacturer;

            Console.WriteLine("");

            foreach (var group in queryQuerySyntax1)
            {
                Console.WriteLine(group.Key);
                foreach (var car in group.OrderByDescending(c => c.Combined).Take(2))
                {
                    Console.WriteLine($"\t{car.Name} : {car.Combined}");
                }
                Console.WriteLine("");
            }

            // Extension Method Syntax herunder.

            Console.WriteLine("");
            Console.WriteLine("Extension Method Syntax");
            Console.WriteLine("");

            var queryMethodSyntax =
                cars.GroupBy(c => c.Manufacturer.ToUpper())
                    .OrderBy(g => g.Key)
                    .Select(c => c);
            // Som sædvanlig ikke nødvendig med .Select for et Expresion Method
            // Syntax udtryk. Men man kan tage det med, hvis man synes. 

            foreach (var group in queryMethodSyntax)
            {
                Console.WriteLine(group.Key);
                foreach (var car in group.OrderByDescending(c => c.Combined).Take(2))
                {
                    Console.WriteLine($"\t{car.Name} : {car.Combined}");
                }
                Console.WriteLine("");
            }

        }
    }
}
