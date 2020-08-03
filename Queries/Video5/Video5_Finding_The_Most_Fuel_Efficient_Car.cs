using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Queries.Extensions;

namespace Queries.Video5
{
    class Video5_Finding_The_Most_Fuel_Efficient_Car
    {
        public static void Video5_Finding_The_Most_Fuel_Efficient_Car_Start()
        {
            Console.WriteLine("");
            Console.WriteLine("Video5_Finding_The_Most_Fuel_Efficient_Car");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("");

            var cars = ("fuel.csv").ProcessFileStatic();

            // Extension Method Syntax herunder

            var queryMethodSyntax = cars.OrderByDescending(c => c.Combined)
                            .ThenBy(c => c.Name);

            foreach (var car in queryMethodSyntax.Take(10))
            {
                Console.WriteLine($"{car.Name} : {car.Combined}");
            }

            // Query Syntax herunder
            var queryQuerySyntax =
                from car in cars
                orderby car.Combined descending, car.Name
                select car;
        }
    }
}
