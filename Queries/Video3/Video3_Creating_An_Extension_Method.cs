using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Queries.Extensions;

namespace Queries.Video3
{
    public class Video3_Creating_An_Extension_Method
    {
        public static void Video3_Creating_An_Extension_Method_Start()
        {
            string Test = "1234";
            double TestDouble = Test.ToDouble();
            System.Console.WriteLine("TestDouble : {0}", TestDouble);
        }
    }
}
