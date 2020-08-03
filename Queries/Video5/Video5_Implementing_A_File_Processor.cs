using Queries.Core.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Queries.Extensions;

namespace Queries.Video5
{
    public class Video5_Implementing_A_File_Processor
    {
        public static void Video5_Implementing_A_File_Processor_Start()
        {
            Console.WriteLine("");
            Console.WriteLine("Video5_Implementing_A_File_Processor");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("");

            //var cars = ProcessFile("fuel.csv");
            
            var cars = ("fuel.csv").ProcessFileStatic();

            foreach (var car in cars)
            {
                Console.WriteLine(car.Name);
            }

            Console.WriteLine("");
            Console.WriteLine("cars1");
            Console.WriteLine("");
            
            var cars1 = cars.Where(c => c.Highway > 40);

            foreach (var car in cars1)
            {
                Console.WriteLine(car.Name);
            }

            var carsIEnumerable = ProcessFileIEnumerable("fuel.csv");

            var cars1IEnumerable = carsIEnumerable.Where(c => c.Highway > 40);
        }

        // Metoden herunder er flyttet til StringExtension.cs filen i Extensions direktoriet,
        // da den skal bruges af flere forskellige klasse filer !!!
        //private static List<Car> ProcessFile(string path)
        //{
        //    // File.ReadALlLines returner et Array af strenge. Så da vi arbejder på en IEnumerable, kan vi 
        //    // anvende LINQ og alle de extensions metoder, som LINQ er i besiddelse af. I tilfældet her er 
        //    // der tale om en IENumerable af strenge.
        //    return 
        //        File.ReadAllLines(path)
        //            .Skip(1)      // Tag ikke første linje => overskriftslinje med
        //            .Where(line => line.Length > 1) // Tag ikke sidste linje => tom linje med
        //            // Metode 1
        //            //.Select(line =>
        //            //{
        //            //    Implemeter kode imellem tuborg paranteser
        //            //});

        //            // Metode 2
        //            //.Select(TransformToCar);

        //            // Metode 3
        //            .Select(Car.ParseFromCsv).ToList();
        //    // Hvis vi havde valgt at retunere en IEmumerable af Cars her, vil vi hver gang, vi udfører
        //    // en Query på vores returnerede data gå ud og læse hele listen igen !!!

        //    // Samme funktionalitet som herover ved brug af Query Syntax

        //    //var query =
        //    //    from line in File.ReadAllLines(path).Skip(1)
        //    //    where line.Length > 1
        //    //    select Car.ParseFromCsv(line);

        //    //return query.ToList();
        //}

        private static IEnumerable<Car> ProcessFileIEnumerable(string path)
        {
           return
                File.ReadAllLines(path)
                    .Skip(1)      // Tag ikke første linje => overskriftslinje med
                    .Where(line => line.Length > 1) // Tag ikke sidste linje => tom linje med
                    .Select(Car.ParseFromCsv);
        }

        private static Car TransformToCar(string arg)
        {
            throw new NotImplementedException();
        }
    }
}
