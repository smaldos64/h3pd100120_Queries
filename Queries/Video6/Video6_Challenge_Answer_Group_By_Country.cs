using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Queries.Extensions;
using Queries.Files;

namespace Queries.Video6
{
    class Video6_Challenge_Answer_Group_By_Country
    {
        public static void Video6_Challenge_Answer_Group_By_Country_start()
        {
            Console.WriteLine("");
            Console.WriteLine("Video6_Challenge_Answer_Group_By_Country");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("");


            Console.WriteLine("Nu sorteres efter land og derefter efter 3 mest brændstof økonomiske biler pr land");
            Console.WriteLine("");
            Console.WriteLine("Der anvendes joining - ordering - grouping - flattening => (SelectMany)");
            Console.WriteLine("");

            var cars = ProcessDataFromFiles.ProcessCar("fuel.csv");
            var manufacturers = ProcessDataFromFiles.ProcessManufacturers("manufacturers.csv");

            // Query Syntax herunder

            var queryQuerySyntax =
                from manufacturer in manufacturers
                join car in cars on manufacturer.Name equals car.Manufacturer
                    into carGroup
                select new
                {
                    Manufacturer = manufacturer,
                    Cars = carGroup
                } into result
                orderby result.Manufacturer.Headquarters
                group result by result.Manufacturer.Headquarters;

            foreach (var group in queryQuerySyntax)
            {
                Console.WriteLine($"{group.Key} : ");
                foreach (var car in group.SelectMany(g => g.Cars).
                                          OrderByDescending(c => c.Combined).
                                          Take(3))
                {
                    Console.WriteLine($"\t{car.Manufacturer} : {car.Name} : {car.Combined}");
                }
                Console.WriteLine("");
            }

            // Extension Method Syntax herunder.

            Console.WriteLine("");
            Console.WriteLine("Extension Method Syntax");
            Console.WriteLine("");

            var queryMethodSyntax =
                manufacturers.GroupJoin(cars, m => m.Name, c => c.Manufacturer,
                (m, g) =>
                new
                {
                    Manufacturer = m,
                    Cars = g
                })
                .OrderBy(m => m.Manufacturer.Headquarters)
                .GroupBy(m => m.Manufacturer.Headquarters);
            
            foreach (var group in queryMethodSyntax)
            {
                Console.WriteLine($"{group.Key} : ");
                foreach (var car in group.SelectMany(g => g.Cars).
                                          OrderByDescending(c => c.Combined).
                                          Take(3))
                {
                    Console.WriteLine($"\t{car.Manufacturer} : {car.Name} : {car.Combined}");
                }
                Console.WriteLine("");
            }

        }
    }
}
