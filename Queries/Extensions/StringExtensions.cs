using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
