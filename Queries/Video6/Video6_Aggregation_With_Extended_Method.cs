using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Queries.Extensions;
using Queries.Files;
using Queries.Statistics;


namespace Queries.Video6
{
    class Video6_Aggregation_With_Extended_Method
    {
        public static void Video6_Aggregation_With_Extended_Method_Start()
        {
            Console.WriteLine("");
            Console.WriteLine("Video6_Aggreating_Data");
            Console.WriteLine("----------------------");
            Console.WriteLine("");

            var cars = ProcessDataFromFiles.ProcessCar("fuel.csv");
            var manufacturers = ProcessDataFromFiles.ProcessManufacturers("manufacturers.csv");

            // Extension Method Syntax herunder.
            
            Console.WriteLine("Extension Method Syntax");
            Console.WriteLine("");

            var queryMethodSyntax1 =
                cars.GroupBy(c => c.Manufacturer)
                .Select(g =>
                {
                    var results = CarStatistics.CalculateCarsStatistics(g);
                    return new
                    {
                        Name = g.Key,
                        Max = results.Max,
                        Min = results.Min,
                        Avg = results.Average,
                        NumberOfCars = results.NumberOfCars
                    };
                })
                .OrderBy(r => r.Name);
                //.OrderByDescending(r => r.Max);

            foreach (var result in queryMethodSyntax1)
            {
                Console.WriteLine($"{result.Name} : ");
                Console.WriteLine($"\t Antal {result.Name} biler : {result.NumberOfCars}");
                Console.WriteLine($"\t Max : {result.Max}");
                Console.WriteLine($"\t Min : {result.Min}");
                Console.WriteLine($"\t Avg : {result.Avg}");
                Console.WriteLine("");
            }

            Console.WriteLine("");
            Console.WriteLine("");

            var queryMethodSyntax2 = 
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

            var queryMethodSyntax =
                cars.GroupBy(c => c.Manufacturer)
                .Select(g =>
                {
                    var results = g.Aggregate(new CarStatistics(),
                                            (acc, c) => acc.Accumulate(c),
                                            acc => acc.Compute());
                    return new
                    {
                        Name = g.Key,
                        Max = results.Max,
                        Min = results.Min,
                        Avg = results.Average,
                        NumberOfCars = results.NumberOfCars
                    };
                })
                .OrderByDescending(r => r.Max);
            // Ved at bruge syntaksen/metoden herover undgår vi at skulle 
            // løbe igennem alle Cars 3 gange for at finde henholdsvis Max, Min
            // og Average værdier.

            //foreach (var result in queryMethodSyntax)
            //{
            //    Console.WriteLine($"{result.Name} : ");
            //    Console.WriteLine($"\t Antal {result.Name} biler : {result.NumberOfCars}");
            //    Console.WriteLine($"\t Max : {result.Max}");
            //    Console.WriteLine($"\t Min : {result.Min}");
            //    Console.WriteLine($"\t Avg : {result.Avg}");
            //    Console.WriteLine("");
            //}
        }
    }
}
