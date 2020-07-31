using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries
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
    }
}
