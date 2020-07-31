using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Queries.Core.Domain;
using Queries.Persistence;

namespace Queries.Video3
{
    public class UsingLinq
    {
        // Video 3 => The Power of IEnumerable

        protected UnitOfWork unitOfWork;
        public UsingLinq()
        {
            unitOfWork = new UnitOfWork(new PlutoContext());
        }
        public void ShowAuthorsUsingLinq()
        {
            Console.WriteLine("USING LINQ");
            Console.WriteLine("");

            Author[] AuthorArray = unitOfWork.Authors.GetAll().ToArray();
            PrintOutItems(AuthorArray, "Gemt i Array");

            List<Author> AuthorList = unitOfWork.Authors.GetAll().ToList();
            PrintOutItems(AuthorList, "Gemt i List");

            IEnumerable<Author> AuthorIEnumerable = unitOfWork.Authors.GetAll();
            PrintOutItems(AuthorIEnumerable, "Gemt i IEnumerable");
        }

        public void PrintOutItems(IEnumerable<Author> Items, string LeadingText)
        {
            Console.WriteLine("");
            Console.WriteLine(LeadingText);
            Console.WriteLine("");

            foreach (var item in Items)
            {
                Console.WriteLine("Author : {0}", item.Name);
            }

            Console.WriteLine("");
        }
    }
}
