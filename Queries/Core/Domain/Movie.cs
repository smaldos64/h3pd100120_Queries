using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries.Core.Domain
{
    public class Movie
    {
        //public int Id { get; set; }

        public string Title { get; set; }

        public double Rating { get; set; }

        private int _year;

        private static int Simulate_Error { get; set; }
        public int Year 
        {
            get 
            {
                if (1 == Simulate_Error)
                {
                    throw new Exception("Error");
                }
                Console.WriteLine($"Returning {_year} for {Title}");
                return (_year);
            } 
            
            set
            {
                _year = value;
            }
        }

        public static void Set_Simulation_Error()
        {
            Simulate_Error = 1;
        }

        public static void Reset_Simulation_Error()
        {
            Simulate_Error = 0;
        }
    }
}
