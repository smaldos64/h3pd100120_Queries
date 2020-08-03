using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Queries.Extensions;
using Queries.Files;

namespace Queries.Video6
{
    public class Video6_Joining_Data_With_Query_Syntax
    {
        public static void Video6_Joining_Data_With_Query_Syntax_Start()
        {
            Console.WriteLine("");
            Console.WriteLine("Video6_Joining_Data_With_Query_Syntax");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("");

            var cars = ProcessDataFromFiles.ProcessCar("fuel.csv");
            var manufactuers = ProcessDataFromFiles.ProcessManufacturers("manufacturers.csv");

            // Query Syntax herunder

            var queryQuerySyntax =
                from car in cars
                join manufacturer in manufactuers on
                  car.Manufacturer equals manufacturer.Name
                orderby car.Combined descending, car.Name ascending
                select new
                {
                    manufacturer.Headquarters,
                    car.Name,
                    car.Combined
                };

            foreach (var car in queryQuerySyntax.Take(10))
            {
                Console.WriteLine($"{car.Headquarters} : {car.Name} : {car.Combined}");
            }

        }
    }
}
