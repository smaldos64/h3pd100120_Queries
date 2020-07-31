//#define Video3_The_Power_Of_IEnumerable
//#define Video3_Creating_An_Extension_Method
//#define Video3_Understanding_Lambda_Expression
//#define Video_3_Using_Func_And_Action_Types
//#define Video3_Query_Syntax_Versus_Method_Syntax

//#define Video4_Creating_A_Custom_Filter_Operation
//#define Video4_Taking_Advantage_Of_Deferred_Execution
//#define Video4_Avoiding_Pittfalls_Of_Deferred_Execution
//#define Video4_Exceptions_And_Deferred_Queries
#define Video4_All_About_Streaming_Operators

using Queries.Core.Domain;
using Queries.Persistence;
using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Linq;

using Queries.Video3;
using Queries.Video4;

namespace Queries
{
    class Program
    {
        // IEnumerable<T> er den perfekte data type at anvende, når man skal "gemme" den egentlige kilde af data
        // List, Arry etc. 
        // Blandt andet derfor arbejder 99% af alle Linq features op imod IEnumerable.
        // Linq arbejder ved at bruge Extensions metoder !!!
        static void Main(string[] args)
        {
#if (Video3_The_Power_Of_IEnumerable)
            Video3_The_Power_Of_IEnumerable.Video3_The_Power_Of_IEnumerable_Start();
#endif

#if (Video3_Creating_An_Extension_Method)
            Video3_Creating_An_Extension_Method.Video3_Creating_An_Extension_Method_Start();
#endif

#if (Video3_Understanding_Lambda_Expression)
            Video3_Understanding_Lambda_Expression.Video3_Understanding_Lambda_Expression_Start();
#endif

#if Video_3_Using_Func_And_Action_Types
            Video3_Using_Func_And_Action_Types.Video_3_Using_Func_And_Action_Types_Start();
#endif

#if (Video3_Query_Syntax_Versus_Method_Syntax)
            Video3_Query_Syntax_Versus_Method_Syntax.Video3_Query_Syntax_Versus_Method_Syntax_Start();
#endif

#if (Video4_Creating_A_Custom_Filter_Operation)
            Video4_Creating_A_Custom_Filter_Operation.Video4_Creating_A_Custom_Filter_Operation_start();
#endif

#if (Video4_Taking_Advantage_Of_Deferred_Execution)
            Video4_Taking_Advantage_Of_Deferred_Execution.Video4_Taking_Advantage_Of_Deferred_Execution_Start();
#endif

#if (Video4_Avoiding_Pittfalls_Of_Deferred_Execution)
            Video4_Avoiding_Pittfalls_Of_Deferred_Execution.Video4_Avoiding_Pittfalls_Of_Deferred_Execution_Start();
#endif

#if (Video4_Exceptions_And_Deferred_Queries)
            Video4_Exceptions_And_Deferred_Queries.Video4_Exceptions_And_Deferred_Queries_Start();
#endif

#if (Video4_All_About_Streaming_Operators)
            Video4_All_About_Streaming_Operators.Video4_All_About_Streaming_Operators_Start();
#endif
            using (var unitOfWork = new UnitOfWork(new PlutoContext()))
            {
                // Example1
                var course = unitOfWork.Courses.Get(1);

                // Example2
                var courses = unitOfWork.Courses.GetCoursesWithAuthors(1, 4);

                // Example3
                var author = unitOfWork.Authors.GetAuthorWithCourses(4);
                //unitOfWork.Courses.RemoveRange(author.Courses);
                //unitOfWork.Authors.Remove(author);
                //unitOfWork.Complete();

                //Sequence<author> ChosenAuthors = unitOfWork.Authors.GetAll().Where(n => n.Name == "John");
                IEnumerable<Author> ChosenAuthors = unitOfWork.Authors.GetAll().Where(n => n.Name == "Lars");

                List<Author> ChosenAuthorsList = unitOfWork.Authors.GetAll().Where(n => n.Name == "Lars").ToList();

                using (var dbContext = new PlutoContext())
                {
                    var ChosenAuthors1 = dbContext.Authors.Where(n => n.Name == "Lars");
                }

                Console.ReadLine();
            }
        }
    }
}
  