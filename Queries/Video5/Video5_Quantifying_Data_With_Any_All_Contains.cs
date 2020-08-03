using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Queries.Extensions;

namespace Queries.Video5
{
    class Video5_Quantifying_Data_With_Any_All_Contains
    {
        public static void Video5_Quantifying_Data_With_Any_All_Contains_Start()
        {
            Console.WriteLine("");
            Console.WriteLine("Video5_Quantifying_Data_With_Any_All_Contains");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("");

            var cars = ("fuel.csv").ProcessFileStatic();

            var resultMethodSyntaxAny = cars.Any(c => c.Manufacturer == "Ford");

            Console.WriteLine($"resultMethodSyntaxAny : {resultMethodSyntaxAny}");
            Console.WriteLine("");

            var resultMethodSyntaxAll = cars.All(c => c.Manufacturer == "Ford");

            Console.WriteLine($"resultMethodSyntaxAll : {resultMethodSyntaxAll}");
            Console.WriteLine("");

            //var resultMethodSyntaxContains = cars.Contains(c => c.Manufacturer == "Ford");

            //Console.WriteLine($"resultMethodSyntaxContains : {resultMethodSyntaxContains}");
            //Console.WriteLine("");
        }
    }
}
