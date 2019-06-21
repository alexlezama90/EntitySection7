using System;
using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PlutoContext();

            ////Restriction
            //var query =
            //    from c in context.Courses
            //    where c.Level == 1 && c.Author.Id == 1 //Restrictions
            //    select c;

            ////Ordering
            //var query =
            //    from c in context.Courses
            //    where c.Author.Id == 1
            //    orderby c.Level descending, c.Name //Ordering
            //    select c;         //descending keyword

            ////Projection        We can return different objects with fewer properties (DTOs), even anonymous objects
            //var query =
            //    from c in context.Courses
            //    where c.Author.Id == 1
            //    orderby c.Level descending, c.Name
            //    select new { Name = c.Name, Author = c.Author.Name };
            //    //select new CourseDTO //Also we could use the constructor new CourseDTO (c.Name, c.Author.Name)
            //    //{
            //    //    Name = c.Name,
            //    //    Author = c.Author.Name
            //    //};

            ////Grouping        //This one breaks our result into different groups
            //var query =
            //    from c in context.Courses
            //    group c by c.Level into g
            //    select g;

            //foreach (var group in query)
            //{
            //    Console.WriteLine(group.Key);

            //    foreach (var course in group)
            //        Console.WriteLine("\t{0}", course.Name);
            //}

            ////Grouping with other functions
            //var query =
            //    from c in context.Courses
            //    group c by c.Level into g
            //    select g;

            //foreach (var group in query)
            //{
            //    Console.WriteLine("{0}, ({1})", group.Key, group.Count()));
            //}

            //////Joins
            ////Inner Joins
            //var query =
            //    from c in context.Courses
            //    join a in context.Authors on c.AuthorId equals a.Id
            //    select new { CourseName = c.Name, AuthorName = a.Name };


            ////Group Joins works like a left join in SQL
            //var query =
            //    from a in context.Authors
            //    join c in context.Courses on a.Id equals c.Author.Id into g
            //    select new { AuthorName = a.Name, Courses = g }; //g for the List of courses per autor; g.Count() for just the quantity of courses per autor

            //foreach (var x in query)
            //{
            //    Console.WriteLine("{0} ({1})", x.AuthorName, x.Courses.Count());

            //    foreach (var course in x.Courses)
            //        Console.WriteLine("{0}", course.Name);
            //}

            //Cross Join cross every author with every course
            var query =
                from a in context.Authors
                from c in context.Courses
                select new { AuthorName = a.Name, CourseName = c.Name };

            foreach (var cross in query)
            {
                Console.WriteLine("{0} {1}", cross.AuthorName, cross.CourseName);
            }

            Console.WriteLine(query.Count());


        }
    }
}
