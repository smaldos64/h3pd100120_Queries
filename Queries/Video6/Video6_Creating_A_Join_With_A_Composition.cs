using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Queries.Extensions;
using Queries.Files;

namespace Queries.Video6
{
    public class Video6_Creating_A_Join_With_A_Composition
    {
        public static void Video6_Creating_A_Join_With_A_Composition_Start()
        {
            Console.WriteLine("");
            Console.WriteLine("Video6_Creating_A_Join_With_A_Composition");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("");

            var cars = ProcessDataFromFiles.ProcessCar("fuel.csv");
            var manufacturers = ProcessDataFromFiles.ProcessManufacturers("manufacturers.csv");

            // Query Syntax herunder

            // Når vi bruger Query Syntax, er der en "tradition" for, at vi
            // bestræber os på at gøre tingene så læsbare, som vi kan. Det kan
            // ses herunder, hvor vi bruger navnene car og manufacurer. Ví kunne 
            // have valgt at bruge én bogstavs navne som f.eks. c (i stedet for car)
            // og m (i stedet for manufacturer). 

            // Når vi bruger Extension Method Syntax er der omvendt en "´tradition" for,
            // at vi anvender én bogstavs navne, når vi kommer omkring Lambda Expressions
            // og vi skal navngive/specificere indkommende parametre til Lambda
            // Expressions. Dette kan vi se, når vi kommer til Extension Method Syntax
            // i det efterfølgende. 
            // I de foregående eksempler har der været brugt både 
            // én bogstavs navne og mere sigende og længere navne, når vi har brugt
            // navngivning for Lambda Expression indkommende prrametre i forbindelse
            // med Extension Method Syntax.

            var queryQuerySyntax =
                from car in cars
                join manufacturer in manufacturers on
                new { car.Manufacturer, car.Year }
                equals
                new { Manufacturer = manufacturer.Name, manufacturer.Year }
                // Navnet skal være det samme i Car.Manufacturer og manufacturer.name
                // Derfor er det nødvendig med sætningen : Manufacturer = manufacturer.Name !!!
                orderby car.Combined descending, car.Name ascending
                select new
                {
                    manufacturer.Headquarters,
                    car.Name,
                    car.Combined
                };

            Console.WriteLine("Query Syntax");
            Console.WriteLine("");

            foreach (var car in queryQuerySyntax.Take(10))
            {
                Console.WriteLine($"{car.Headquarters} : {car.Name} : {car.Combined}");
            }

            Console.WriteLine("");
            Console.WriteLine("Extension Method Syntax");
            Console.WriteLine("");

            // Extension Method Syntax herunder.

            // Som nævnt tidligere i dette dokument, bruger vi her én bogstavs 
            // navngivning for indkommende Lambda Expression parametre i 
            // forbindelse med Extension Method Syntax. Og i alle efterfølgende 
            // eksmepler vil denne én bogstavs navngivning blive anvendt.
            // I forbindelse med denne én bogstavs navngivning har jeg valgt at 
            // benytte første bogstav i det navn, som vi forkorter efter.
            // Det vil sige c for for car og m for manufacturer og så fremdeles.
            // Denne navgivnings konvention er også den, der gennrelt amvendes,
            // nåt vi snakker om Lambda Expression og indkommende parametre. 
            // efterfølgende Lambda Expressions 

            var queryMethodSyntax =
                cars.Join(manufacturers,
                            c => new { c.Manufacturer, c.Year },
                            m => new { Manufacturer = m.Name, m.Year },
                            // Navnet skal være det samme i C.Manufacturer og m.name
                            // Derfor er det nødvendig med sætningen : Manufacturer = m.Name !!!
                            (c, m) => new
                            {
                                m.Headquarters,
                                c.Name,
                                c.Combined
                            })
                        .OrderByDescending(c => c.Combined)
                        .ThenBy(c => c.Name);

            foreach (var car in queryMethodSyntax.Take(10))
            {
                Console.WriteLine($"{car.Headquarters} : {car.Name} : {car.Combined}");
            }
        }
    }
}
