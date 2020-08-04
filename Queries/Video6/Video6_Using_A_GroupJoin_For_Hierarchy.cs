using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Queries.Extensions;
using Queries.Files;


namespace Queries.Video6
{
    public class Video6_Using_A_GroupJoin_For_Hierarchy
    {
        public static void Video6_Using_A_GroupJoin_For_Hierarchy_Start()
        {
            Console.WriteLine("");
            Console.WriteLine("Video6_Using_A_GroupJoin_For_Hierarchy");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("");


            Console.WriteLine("Nu lande informationer med for Headquarters");
            Console.WriteLine("");

            var cars = ProcessDataFromFiles.ProcessCar("fuel.csv");
            var manufacturers = ProcessDataFromFiles.ProcessManufacturers("manufacturers.csv");

            // Query Syntax herunder

            var queryQuerySyntax =
                from manufacturer in manufacturers
                join car in cars on manufacturer.Name equals car.Manufacturer
                    into carGroup
                orderby manufacturer.Name
                select new
                {
                    Manufacturer = manufacturer,
                    Cars = carGroup
                };

            Console.WriteLine("Query Syntax");
            Console.WriteLine("");

            foreach (var group in queryQuerySyntax)
            {
                Console.WriteLine($"{group.Manufacturer.Name} : {group.Manufacturer.Headquarters}");
                foreach (var car in group.Cars.OrderByDescending(c => c.Combined).Take(2))
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
                manufacturers.GroupJoin(cars, m => m.Name, c => c.Manufacturer, 
                (m, g) =>
                new
                {
                    Manufacturer = m,
                    Cars = g
                })
                .OrderBy(m => m.Manufacturer.Name);

            foreach (var group in queryMethodSyntax)
            {
                Console.WriteLine($"{group.Manufacturer.Name} : {group.Manufacturer.Headquarters}");
                foreach (var car in group.Cars.OrderByDescending(c => c.Combined).Take(2))
                {
                    Console.WriteLine($"\t{car.Name} : {car.Combined}");
                }
                Console.WriteLine("");
            }
        }
    }
}
