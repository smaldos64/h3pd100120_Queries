using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Queries.Core.Domain;
using Queries.Persistence;

namespace Queries.Video3
{
    public class Video3_Understanding_Lambda_Expression
    {
        public static void Video3_Understanding_Lambda_Expression_Start()
        {
            using (var unitOfWork = new UnitOfWork(new PlutoContext()))
            {
                IEnumerable<Author> AuthorsList = unitOfWork.Authors.GetAll();

                // Metode 1
                foreach (var authorItem in AuthorsList.Where(NameStartsWithS))
                {
                    Console.WriteLine("Author Name : {0}", authorItem.Name);
                }

                Console.WriteLine("");

                // Metode 2
                foreach (var authorItem in AuthorsList.Where(
                    delegate (Author authorItem)
                    {
                        return authorItem.Name.StartsWith("S");
                    })
                )
                {
                    Console.WriteLine("Author Name : {0}", authorItem.Name);
                }

                Console.WriteLine("");

                // Metode 3
                foreach (var authorItem in AuthorsList.Where(
                    authorItem => authorItem.Name.StartsWith("S")
                    )
                )
                {
                    Console.WriteLine("Author Name : {0}", authorItem.Name);
                }

                Console.WriteLine("");

                // Metode 3 -> Ny
                foreach (var authorItem in AuthorsList.Where(
                    a => a.Name.StartsWith("S")
                    )
                )
                {
                    Console.WriteLine("Author Name : {0}", authorItem.Name);
                }

                Console.WriteLine("");
            }
        }

        private static bool NameStartsWithS(Author author)
        {
            return author.Name.StartsWith("S");
        }
    }
}
