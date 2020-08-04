using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Queries.Extensions;
using Queries.Files;

namespace Queries.Video6
{
    public class Video6_Joining_Data_With_Extension_Method_Syntax
    {
        public static void Video6_Joining_Data_With_Extension_Method_Syntax_Start()
        {
            Console.WriteLine("");
            Console.WriteLine("Video6_Joining_Data_With_Extension_Method_Syntax");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("");

            var cars = ProcessDataFromFiles.ProcessCar("fuel.csv");
            var manufacturers = ProcessDataFromFiles.ProcessManufacturers("manufacturers.csv");

            // Extension Method Syntax herunder

            // Navngivningen i eksemplet herunder er den man tiest støder på, når man 
            // arbejder med Lambda Expression. 
            // Ved alle indkommende parametre til et Lambda Expression benytter man
            // sig af én bogstavs notation. For at gøre det lettere at læse koden
            // benytter man ofte af et bogstav, der er første bogtsva i det, man 
            // arbejder med. F.eks c for car og m for manufacturer.

            var queryMethodSyntaxSingleLetterNaming =
                cars.Join(manufacturers,
                            c => c.Manufacturer,
                            m => m.Name, (c, m) => new
                            {
                                m.Headquarters,
                                c.Name,
                                c.Combined
                            }) // Her bliver de 2 objekter cars og manufacturers samlet i ét objekt
                        .OrderByDescending(c => c.Combined)
                        .ThenBy(c => c.Name);

            foreach (var car in queryMethodSyntaxSingleLetterNaming.Take(10))
            {
                Console.WriteLine($"{car.Headquarters} : {car.Name} : {car.Combined}");
            }

            Console.WriteLine("");

            // Navngivningen i eksemplet herunder støder man ikke på så tit, når man 
            // arbejder med Lambda Expression. Men den er måske lettere at læse
            // end én bogstavs navngivningen fra eksemplet herover.
            // Som altid indefor progtrammeringens verden er det et spørgsmål
            // om smag og behag. Og der er ikke noget, der er mere rigtigt end andet.
            
            var queryMethodSyntaxMoreReadableNaming =
                cars.Join(manufacturers,
                            car => car.Manufacturer,
                            manufacturer => manufacturer.Name, (car, manufacturer) => new
                            {
                                manufacturer.Headquarters,
                                car.Name,
                                car.Combined
                            }) // Her bliver de 2 objekter cars og manufacturers samlet i ét objekt
                        .OrderByDescending(car => car.Combined)
                        .ThenBy(car => car.Name);
                
            foreach (var car in queryMethodSyntaxMoreReadableNaming.Take(10))
            {
                Console.WriteLine($"{car.Headquarters} : {car.Name} : {car.Combined}");
            }

            Console.WriteLine("");

            var queryMethodSyntax1 =
                cars.Join(manufacturers,
                            c => c.Manufacturer,
                            m => m.Name, (c, m) => new
                            {
                                Car = c,
                                Manufacturer = m
                            })
                        .OrderByDescending(c => c.Car.Combined)
                        .ThenBy(c => c.Car.Name);

            foreach (var car in queryMethodSyntax1.Take(10))
            {
                Console.WriteLine($"{car.Manufacturer.Headquarters} : {car.Car.Manufacturer} : {car.Car.Name} : {car.Car.Combined}");
            }

            Console.WriteLine("");

            var queryMethodSyntax2 =
                cars.Join(manufacturers,
                            c => c.Manufacturer,
                            m => m.Name, (c, m) => new
                            {
                                Car = c,
                                Manufacturer = m
                            })
                        .OrderByDescending(c => c.Car.Combined)
                        .ThenBy(c => c.Car.Name)
                        .Select(c => new
                        {
                            c.Manufacturer.Headquarters,
                            c.Car.Name,
                            c.Car.Combined
                        });

            foreach (var car in queryMethodSyntax1.Take(10))
            {
                Console.WriteLine($"{car.Manufacturer.Headquarters} : {car.Car.Name} : {car.Car.Combined}");
            }

            // Der kan ikke bruges Include her, som når vi anvender EntityFramework
            // op imod f.eks. en database.
            // Så Include, ThenInclude o.s.ver altså funktionalitet, som Entity 
            // Framework bygger ovenpå Linq.
        }
    }
}
