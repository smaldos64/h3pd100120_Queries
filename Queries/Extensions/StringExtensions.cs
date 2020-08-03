using Queries.Core.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Queries.Files;

namespace Queries.Extensions
{
    public static class StringExtensions
    {
        // Video 3 => Creating an Extension Method
        public static double ToDouble(this string data)
        {
            double result = double.Parse(data);

            return (result);
        }

        public static List<Car> ProcessFileStatic(this string path)
        {
            // File.ReadALlLines returner et Array af strenge. Så da vi arbejder på en IEnumerable, kan vi 
            // anvende LINQ og alle de extensions metoder, som LINQ er i besiddelse af. I tilfældet her er 
            // der tale om en IENumerable af strenge.
            return
                File.ReadAllLines(path)
                    .Skip(1)      // Tag ikke første linje => overskriftslinje med
                    .Where(line => line.Length > 1) // Tag ikke sidste linje => tom linje med
                                                    // Metode 1
                                                    //.Select(line =>
                                                    //{
                                                    //    Implemeter kode imellem tuborg paranteser
                                                    //});

                    // Metode 2
                    //.Select(TransformToCar);

                    // Metode 3
                    .Select(Car.ParseFromCsv).ToList();
            // Hvis vi havde valgt at retunere en IEmumerable af Cars her, vil vi hver gang, vi udfører
            // en Query på vores returnerede data gå ud og læse hele listen igen !!!

            // Samme funktionalitet som herover ved brug af Query Syntax

            //var query =
            //    from line in File.ReadAllLines(path).Skip(1)
            //    where line.Length > 1
            //    select Car.ParseFromCsv(line);

            //return query.ToList();
        }

        public static IEnumerable<Car> ToCar(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var columns = line.Split(',');

                yield return new Car
                {
                    Year = int.Parse(columns[0]),
                    Manufacturer = columns[1],
                    Name = columns[2],
                    Displacement = double.Parse(columns[3]),
                    Cylinders = int.Parse(columns[4]),
                    City = int.Parse(columns[5]),
                    Highway = int.Parse(columns[6]),
                    Combined = int.Parse(columns[7])
                };
            }
        }

        public static IEnumerable<Manufacturer> ToManufacturer(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var columns = line.Split(',');

                yield return new Manufacturer
                {
                    Name = columns[0],
                    Headquarters = columns[1],
                    Year = int.Parse(columns[2])
                };
            }
        }
    }
}
