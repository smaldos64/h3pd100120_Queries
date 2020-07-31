using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Queries.Core.Domain;
using Queries.Persistence;

namespace Queries.Video3
{
    public class Video3_Query_Syntax_Versus_Method_Syntax
    {
        public static void Video3_Query_Syntax_Versus_Method_Syntax_Start()
        {
            using (var unitOfWork = new UnitOfWork(new PlutoContext()))
            {
                IEnumerable<Author> AuthorsList = unitOfWork.Authors.GetAll();

                // video 3 => Query Syntax versus Method Syntax
                // De 2 første queries herunder (query og query1) er bygget op omkring Method Syntax.
                // Method Syntax har nogle flere muligheder i forhold til Query Syntax. Så man kan ende ud i,
                // at man skal bruge Method Syntax. Det kan være ved operationer som Count, Take og Skip.
                var queryMethodSyntax = AuthorsList.Where(a => a.Name.Length > 4).OrderBy(a => a.Name);

                var queryMethodSyntax1 = AuthorsList.Where(a => a.Name.Length > 4).OrderBy(a => a.Name).Select(a => a);

                // Den viste query herunder er bugget op omkring Query Syntax.
                var queryQuerySyntax = from Author in AuthorsList
                                       where Author.Name.Length > 4
                                       orderby Author.Name
                                       select Author;

                var queryQuerySyntax1 = from Author in AuthorsList
                                        where Author.Name.Length > 4
                                        orderby Author.Name descending
                                        select Author;

                var queryMethodSyntax2 = AuthorsList.Where(a => a.Name.Length > 4).OrderByDescending(a => a.Name);

                foreach (var Author in queryQuerySyntax)
                {
                    Console.WriteLine("Author Name : {0}", Author.Name);
                }
            }
        }
    }
}
