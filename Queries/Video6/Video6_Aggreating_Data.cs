using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Queries.Extensions;
using Queries.Files;

namespace Queries.Video6
{
    public class Video6_Aggreating_Data
    {
        public static void Video6_Aggreating_Data_Start()
        {
            Console.WriteLine("");
            Console.WriteLine("Video6_Aggreating_Data");
            Console.WriteLine("----------------------");
            Console.WriteLine("");
            
            var cars = ProcessDataFromFiles.ProcessCar("fuel.csv");
            var manufacturers = ProcessDataFromFiles.ProcessManufacturers("manufacturers.csv");

            // Query Syntax herunder

            var queryQuerySyntax =
                from car in cars
                group car by car.Manufacturer into carGroup
                select new
                {
                    // Vi laver en projektion her.
                    Name = carGroup.Key,
                    Max = carGroup.Max(c => c.Combined),
                    Min = carGroup.Min(c => c.Combined),
                    Avg = carGroup.Average(c => c.Combined),
                    NumberOfCars = carGroup.Count()
                };

            Console.WriteLine("Query Syntax");
            Console.WriteLine("");

            foreach (var result in queryQuerySyntax)
            {
                Console.WriteLine($"{result.Name} : ");
                Console.WriteLine($"\t Antal {result.Name} biler : {result.NumberOfCars}");
                Console.WriteLine($"\t Max : {result.Max}");
                Console.WriteLine($"\t Min : {result.Min}");
                Console.WriteLine($"\t Avg : {result.Avg}");
                Console.WriteLine("");
            }

            var queryQuerySyntaxOrdered =
                from car in cars
                group car by car.Manufacturer into carGroup
                select new
                {
                    // Vi laver en projektion her.
                    Name = carGroup.Key,
                    Max = carGroup.Max(c => c.Combined),
                    Min = carGroup.Min(c => c.Combined),
                    Avg = carGroup.Average(c => c.Combined),
                    NumberOfCars = carGroup.Count()
                } into result
                orderby result.Max descending
                select result;

            Console.WriteLine("");
            Console.WriteLine("Ordered by most fuel efficient car");
            Console.WriteLine("");

            foreach (var result in queryQuerySyntaxOrdered)
            {
                Console.WriteLine($"{result.Name} : ");
                Console.WriteLine($"\t Antal {result.Name} biler : {result.NumberOfCars}");
                Console.WriteLine($"\t Max : {result.Max}");
                Console.WriteLine($"\t Min : {result.Min}");
                Console.WriteLine($"\t Avg : {result.Avg}");
                Console.WriteLine("");
            }
        }
    }
}
