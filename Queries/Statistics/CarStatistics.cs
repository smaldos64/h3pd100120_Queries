using Queries.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries.Statistics
{
    public class CarStatistics
    {
        public int Max { get; set; }
        public int Min { get; set; }
        
        public double Average { get; set; }

        public int Total { get; set; }
        
        public int NumberOfCars { get; set; }

        public CarStatistics()
        {
            Max = Int32.MinValue;
            Min = Int32.MaxValue;
        }

        public CarStatistics Accumulate(Car car)
        {
            NumberOfCars++;
            Total += car.Combined;
            Max = Math.Max(Max, car.Combined);
            Min = Math.Min(Min, car.Combined);

            return (this);
        }

        public CarStatistics Compute()
        {
            Average = Total / NumberOfCars;

            return (this);
        }

        public static CarStatistics CalculateCarsStatistics(IEnumerable<Car> car_List)
        {
            CarStatistics theseCarsStatictics = new CarStatistics();

            theseCarsStatictics.Total = 1;
            theseCarsStatictics.Min = 2;
            theseCarsStatictics.Max = 3;
            theseCarsStatictics.Average = 1.5;
            theseCarsStatictics.NumberOfCars = 4;

            return theseCarsStatictics;
        }

    }
}
