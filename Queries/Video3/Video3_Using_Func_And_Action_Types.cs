using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Queries.Core.Domain;
using Queries.Persistence;

namespace Queries.Video3
{
    public class Video3_Using_Func_And_Action_Types
    {
        public static void Video_3_Using_Func_And_Action_Types_Start()
        {
            using (var unitOfWork = new UnitOfWork(new PlutoContext()))
            {
                IEnumerable<Author> AuthorsList = unitOfWork.Authors.GetAll();

                // Video 3 => Using Func and Action Types
                // Named Methods
                Func<int, int> fNamedExpressionSquare = Square;

                Console.WriteLine("(Named Method) Square of {0} is {1}", 3, fNamedExpressionSquare(3));

                Func<int, int> fLambdaExpressionSquare = x => x * x;

                Console.WriteLine("(Lambda Expression) Square of {0} is {1}", 4, fLambdaExpressionSquare(4));

                Func<int, int, int> fLambdaExpressionAdd = (x, y) => x + y;

                Console.WriteLine("(Lambda Expression) Square of {0}+{1} is {2}", 3, 5, fLambdaExpressionSquare(fLambdaExpressionAdd(3, 5)));

                Func<int, int, int> fLambdaExpressionSubtract = (int x, int y) =>
                {
                    int temp = x - y;
                    return temp;
                };

                Action<int> MyLambdaExpressionWrite = x => Console.WriteLine(x);
                // Modsat Func returnerer Action ikke noget.

                MyLambdaExpressionWrite(fLambdaExpressionSquare(fLambdaExpressionAdd(3, 5)));

                Console.WriteLine("");

                foreach (var authorItem in AuthorsList.Where(
                    a => a.Name.Length > 4
                    )
                    .OrderBy(a => a.Name)
                )
                {
                    Console.WriteLine("Author Name : {0}", authorItem.Name);
                }

                Console.WriteLine("");

                
            }
        }

        private static int Square(int arg)
        {
            return arg * arg;
        }
    }
}
