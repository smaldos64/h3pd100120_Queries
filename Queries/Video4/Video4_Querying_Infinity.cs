using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Queries.Extensions;

namespace Queries.Video4
{
    public class Video4_Querying_Infinity
    {
        public static void Video4_Querying_Infinity_Start()
        {
            Console.WriteLine("");
            Console.WriteLine("Video4_Querying_Infinity");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("");

            var numbers = MyLinq.Random().Where(n => n > 0.5).Take(10);

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
            
        }
    }
}
