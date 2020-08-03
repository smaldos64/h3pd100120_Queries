using Queries.Core.Domain;
using Queries.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries.Files
{
    public class ProcessDataFromFiles
    {
        public static List<Car> ProcessCar(string path)
        {
            // File.ReadALlLines returner et Array af strenge. Så da vi arbejder på en IEnumerable, kan vi 
            // anvende LINQ og alle de extensions metoder, som LINQ er i besiddelse af. I tilfældet her er 
            // der tale om en IENumerable af strenge.

            // Projektioner kan være meget effektive, når man ønsker at konverer en sekvens af
            // objekter af en type til en sekvens af objekter af en anden type.
            // Projektioner kan også være effektive, når man ønsker et subset af data.

            var queryMethodSyntax =
                File.ReadAllLines(path)
                    .Skip(1)      // Tag ikke første linje => overskriftslinje med
                    .Where(line => line.Length > 1) // Tag ikke sidste linje => tom linje med
                    .ToCar();

            return (queryMethodSyntax.ToList());
        }

        public static List<Manufacturer> ProcessManufacturers(string path)
        {
            var queryMethodSyntax =
                File.ReadAllLines(path)
                    .Skip(1)      // Tag ikke første linje => overskriftslinje med
                    .Where(line => line.Length > 1) // Tag ikke sidste linje => tom linje med
                    .ToManufacturer();

            return (queryMethodSyntax.ToList());
        }
    }
}
