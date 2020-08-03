using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Queries.Extensions;

namespace Queries.Video5
{
    class Video5_Filtering_With_Where_And_First
    {
        public static void Video5_Filtering_With_Where_And_First_Start()
        {
            Console.WriteLine("");
            Console.WriteLine("Video5_Filtering_With_Where_And_First");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("");

            var cars = ("fuel.csv").ProcessFileStatic();

            // Extension Method Syntax herunder
            var queryMethodSyntax = 
                            cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
                                .OrderByDescending(c => c.Combined)
                                .ThenBy(c => c.Name)
                                .Select(c => c);   // Select i linjen her er ikke nødvendig !!!

            var topMethodSyntax =
                cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
                                .OrderByDescending(c => c.Combined)
                                .ThenBy(c => c.Name)
                                .Select(c => c)
                                .First();  
            // First kan også anvendes som en Filter operator se herunder !!!

            Console.WriteLine($"topMethodSyntax.Name : {topMethodSyntax.Name}");
            Console.WriteLine("");

            var topMethodSyntax1 =
                cars.First(c => c.Manufacturer == "BMW" && c.Year == 2016);
                                //.OrderByDescending(c => c.Combined)
                                //.ThenBy(c => c.Name)
                                //.Select(c => c)
                                //.First();
            // Udtrykket herover giver ikke den mest brændstof effektive bil !!! Istedet får
            // vi den første bil, der matcher kriterierne i First udtrykket !!!

            Console.WriteLine($"topMethodSyntax1.Name : {topMethodSyntax1.Name}");
            Console.WriteLine("");

            var topMethodSyntax2 =
                cars.OrderByDescending(c => c.Combined)
                                .ThenBy(c => c.Name)
                                .Select(c => c)
                                .First(c => c.Manufacturer == "BMW" && c.Year == 2016);
            // Konstruktionen her er ikke så effektiv som konstruktionen, hvor vi 
            // finder topMethodSyntax, da vi der filterer, før vi sorterer !!!

            Console.WriteLine($"topMethodSyntax2.Name : {topMethodSyntax2.Name}");
            Console.WriteLine("");

            var topMethodSyntax3 =
                cars.OrderByDescending(c => c.Combined)
                                .ThenBy(c => c.Name)
                                .Select(c => c)
                                .FirstOrDefault(c => c.Manufacturer == "aaa" && c.Year == 2016);

            if (null != topMethodSyntax3)
            {
                Console.WriteLine($"topMethodSyntax3.Name : {topMethodSyntax3.Name}");
            }
            else
            {
                Console.WriteLine("Ingen biler fundet der matcher søge kriterie !!!");
            }

            // Query Syntax herunder
            var queryQuerySyntax =
                from car in cars
                where car.Manufacturer == "BMW" && car.Year == 2016
                orderby car.Combined descending, car.Name
                select car;

            Console.WriteLine("");

            foreach (var car in queryMethodSyntax.Take(10))
            {
                Console.WriteLine($"{car.Name} : {car.Combined}");
            }
        }
    }
}
