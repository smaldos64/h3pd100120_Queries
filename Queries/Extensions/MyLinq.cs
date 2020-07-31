using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries.Extensions
{
    public static class MyLinq
    {
        public static int MyCount<T>(this IEnumerable<T> sequence)
        {
            int count = 0;
            foreach (var item in sequence)
            {
                count++;
            }

            return (count);
        }

        public static T[] ToMyArray<T>(this IEnumerable<T> sequence)
        {
            //int NumberOfElementsInSequence = sequence.MyCount();

            ////List<T> buffer = new List<T>(sequence);
            //dynamic[] bufferArray = new object[NumberOfElementsInSequence];

            //int ArrayIndex = 0;
            //IEnumerator<T> sequenceIEnumerable = sequence.GetEnumerator();
            //while (sequenceIEnumerable.MoveNext())
            //{
            //    bufferArray[ArrayIndex] = sequenceIEnumerable.Current;
            //}

            //return bufferArray; 

            return sequence.ToArray();
        }

        public static List<T> ToMyList<T>(this IEnumerable<T> sequence)
        {
            List<T> bufferList = new List<T>();

            IEnumerator<T> sequenceIEnumerable = sequence.GetEnumerator();
            while (sequenceIEnumerable.MoveNext())
            {
                bufferList.Add(sequenceIEnumerable.Current);
            }

            return bufferList;
        }

        // Det er som vist i metoden herunder, hvordan mange af LINQ operatorerne er implementeret. De er en 
        // extension metode til IEnumerable<T> og de returnerer en IENumerable<T>
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source,
                                               Func<T, bool> predicate)
        {
            var result = new List<T>();

            foreach (var item in source)
            {
                if (predicate(item))
                {
                    result.Add(item);
                }
            }
            // Koden herover en én måde at udføre filtreringen på. Det er dog ikke sådan, LINQ gør det.

            return (result);
        }

        public static IEnumerable<T> FilterYield<T>(this IEnumerable<T> source,
                                                 Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
            // Sådan her gør LINQ det ved brug af yield.

            // yield kan bruges, når en metode/funktion returnerer en IEnumerable eller IEnumerable<T> 
            // (IEnumerable<T> arver fra IENumerable). Man kan dog også bruge yield på metoder/funktioner,
            // der returnerer IEnumerator eller IEnumerator<T>

            // Brugen af yield bevirker, at vi nu udfører tingene ved brug af Third Execution 
            // (deferred execution)
            // Ikke alle LINQ operationer understøtter THird Execution !!!
        }
    }
}
