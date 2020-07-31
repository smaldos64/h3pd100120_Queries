using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Queries.Core.Domain;
using Queries.Persistence;
using Queries.Extensions;


namespace Queries.Video3
{
    public class NotUsingLinq
    {
        // Video 3 => The Power of IEnumerable

        protected UnitOfWork unitOfWork;
        public NotUsingLinq()
        {
            unitOfWork = new UnitOfWork(new PlutoContext());
        }
        public void ShowAuthorsNotUsingLinq()
        {
            Console.WriteLine("NOT USING LINQ");
            Console.WriteLine("");

            //Author[] AuthorArray = unitOfWork.Authors.GetAll().ToArray();
            Author[] AuthorArray = unitOfWork.Authors.GetAll().ToMyArray();
            Console.WriteLine("Antal Elementer i AuthorArray : {0}", AuthorArray.MyCount());
            PrintOutItems(AuthorArray, "Gemt i Array");

            List<Author> AuthorList = unitOfWork.Authors.GetAll().ToMyList();
            Console.WriteLine("Antal Elementer i AuthorList : {0}", AuthorList.MyCount());
            PrintOutItems(AuthorArray, "Gemt i List");

            IEnumerable<Author> AuthorIEnumerable = unitOfWork.Authors.GetAll();
            Console.WriteLine("Antal Elementer i AuthorIEnumerable : {0}", AuthorIEnumerable.MyCount());
            PrintOutItems(AuthorIEnumerable, "Gemt i IEnumerable");
        }

        public void PrintOutItems(IEnumerable<Author> Items, string LeadingText)
        {
            Console.WriteLine("");
            Console.WriteLine(LeadingText);
            Console.WriteLine("");

            IEnumerator<Author> authorIEnumerable = Items.GetEnumerator();
            while (authorIEnumerable.MoveNext())
            {
                Console.WriteLine("Author : {0}", authorIEnumerable.Current.Name);
            }
            
            Console.WriteLine("");
        }
    }
}
