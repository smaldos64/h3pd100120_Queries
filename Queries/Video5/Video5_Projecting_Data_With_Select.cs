using Queries.Core.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Queries.Extensions;
using Queries.Files;

namespace Queries.Video5
{
    class Video5_Projecting_Data_With_Select
    {
        public static void Video5_Projecting_Data_With_Select_Start()
        {
            Console.WriteLine("");
            Console.WriteLine("Video5_Projecting_Data_With_Select");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("");

            var cars = ProcessDataFromFiles.ProcessCar("fuel.csv");

            Console.WriteLine("Method Syntax");
            Console.WriteLine("");
            Console.WriteLine("Metode 1");

            var queryMethodSyntax =
                cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
                                .OrderByDescending(c => c.Combined)
                                .ThenBy(c => c.Name)
                                .Select(c => c);

            foreach (var car in queryMethodSyntax.Take(10))
            {
                Console.WriteLine($"{car.Manufacturer} : {car.Name} : {car.Combined}");
            }

            var queryMethodSyntax1 =
                cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
                                .OrderByDescending(c => c.Combined)
                                .ThenBy(c => c.Name)
                                .Select(c => new { c.Manufacturer, SpecificName = c.Name, c.Combined });
            Console.WriteLine("");
            Console.WriteLine("Metode 1");

            foreach (var car in queryMethodSyntax1.Take(10))
            {
                Console.WriteLine($"{car.Manufacturer} : {car.SpecificName} : {car.Combined}");
            }

            Console.WriteLine("");

            var anonymousObject = new
            {
                Name = "Lars",
                Age = 55
            };
            Console.WriteLine($"anonymousObject.Name {anonymousObject.Name} : anonymousObject.Age {anonymousObject.Age}");
            // anonymousObject.Name = "Hans"; Felter i anonyme objekter er read only !!!

            
            // Query Syntax herunder
            var queryQuerySyntax =
                from car in cars
                where car.Manufacturer == "BMW" && car.Year == 2016
                orderby car.Combined descending, car.Name
                select new
                {
                    Manufacturer = car.Manufacturer,
                    SpecificName = car.Name,
                    Combined = car.Combined

                };

            Console.WriteLine("");
            Console.WriteLine("Query Syntax");
            Console.WriteLine("");

            foreach (var car in queryQuerySyntax.Take(10))
            {
                Console.WriteLine($"{car.Manufacturer} : {car.SpecificName} : {car.Combined}");
            }
            // Kun de 3 felter der bliver udskrevet herover er nu tilgængelige på vores
            // car objekter. 

        }

        //private static List<Car> ProcessFile(string path)
        //{
        //    // File.ReadALlLines returner et Array af strenge. Så da vi arbejder på en IEnumerable, kan vi 
        //    // anvende LINQ og alle de extensions metoder, som LINQ er i besiddelse af. I tilfældet her er 
        //    // der tale om en IENumerable af strenge.

        //    // Projektioner kan være meget effektive, når man ønsker at konverer en sekvens af
        //    // objekter af en type til en sekvens af objekter af en anden type.
        //    // Projektioner kan også være effektive, når man ønsker et subset af data.

        //    var queryMethodSyntax = 
        //        File.ReadAllLines(path)
        //            .Skip(1)      // Tag ikke første linje => overskriftslinje med
        //            .Where(line => line.Length > 1) // Tag ikke sidste linje => tom linje med
        //            .ToCar();

        //    return (queryMethodSyntax.ToList());
        //}
    }
}
