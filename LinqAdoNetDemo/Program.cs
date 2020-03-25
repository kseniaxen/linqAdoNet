using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqAdoNetDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            /* LINQ to Objects */
            /* List<object> list =
                new List<object> {
                    new { Id = 1, DeadPercent = 3.1d, RecoveredPercent = 52d },
                    new { Id = 2, DeadPercent = 3.2d, RecoveredPercent = 50d },
                    new { Id = 3, DeadPercent = 2.97d, RecoveredPercent = 54d }
                };
            Type t = list.ElementAt(0).GetType(); */
            // Console.WriteLine(t.Name);

            /* var result =
                list.Where((o) => (double)t.GetProperty("DeadPercent").GetValue(o) > 3d)
                .Select((o) => (double)t.GetProperty("RecoveredPercent").GetValue(o)); */
            /*var result =
                list.Skip(1)
                .Take(1)
                .Select((o) => (double)t.GetProperty("RecoveredPercent").GetValue(o));
            Console.WriteLine(result);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }*/

            /* var result =
                list.Where((o) => (double)t.GetProperty("DeadPercent").GetValue(o) > 3d)
                .Select((o) => (double)t.GetProperty("RecoveredPercent").GetValue(o)).ToList();
            Console.WriteLine(result);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            } */


            /* LINQ to SQL */
            // DiseaseEntities1 disease = new DiseaseEntities1();
            /* foreach (var item in disease.TotalStats)
            {
                Console.WriteLine(item.recovered_percent);
            } */
            /* var result2 =
                disease.TotalStats.Where((ts) => ts.dead_percent > 3d)
                .Select((ts) => ts.recovered_percent); */

            /* var result2 =
                disease.TotalStats
                .OrderBy((ts) => ts.)
                .Skip(1)
                .Take(1)
                .Select((ts) => ts.recovered_percent);
            Console.WriteLine(result2);
            foreach (var item in result2)
            {
                Console.WriteLine(item);
            } */

            /* XDocument doc1 = new XDocument();
            XElement root = new XElement("stats");
            foreach (var item in disease.TotalStats)
            {
                root.Add(
                    new XElement(
                        "item",
                        new XAttribute("id", item.id),
                        new XElement("dead_percent", item.dead_percent),
                        new XElement("recovered_percent", item.recovered_percent)
                        )
                    );
                // Console.WriteLine(item);
            }
            doc1.Add(root);
            doc1.Save("disease.xml");

            XDocument doc2 = XDocument.Load("disease.xml");
            IEnumerable<XElement> stats = doc2.Descendants("stats").Elements();
            Console.WriteLine(stats);
            foreach (var item in stats)
            {
                // Console.WriteLine(item);
                Console.WriteLine(item.Element(XName.Get("dead_percent")).Value);
                Console.WriteLine(item.Name); 
            }
            var result3 =
                stats.Where((item) => Double.Parse(item.Element(XName.Get("dead_percent")).Value.Replace(".", ",")) > 3d)
                    .Select((item) => Double.Parse(item.Element(XName.Get("recovered_percent")).Value.Replace(".", ",")));
            Console.WriteLine(result3);
            foreach (var item in result3)
            {
                Console.WriteLine(item);
            }*/

            /* Part 2 */
            // DiseaseEntities1 disease = new DiseaseEntities1();
            /* var result =
                disease.Authors.Where((a) => a.FirstName.StartsWith("L"))
                .Select((a) => a.FirstName + " " + a.LastName); */
            /* var result =
                disease.Authors.Where((a) => a.FirstName.StartsWith("L"))
                .Select((a) => a.FirstName + " " + a.LastName + " " + a.Books.FirstOrDefault().Title);
            Console.WriteLine(result);*/

            /* for (int i = 0; i < 3; i++)
            {
                AddAuthor(new Author() { FirstName = "Name"+i, LastName = "LastName"+i });
            }

            for (int i = 0; i < 3; i++)
            {
                AddPublisher(new Publisher() { PublisherName = "PName" + i, Address = "Address" + i });
            }

            Random random = new Random();
            for (int i = 0; i < 9; i++)
            {
                AddBook(
                    new Book() {
                        Title = "Title" + i,
                        Pages = i,
                        Price = i * i,
                        IdAuthor = random.Next(1, 4),
                        IdPublisher = random.Next(1, 4)
                    }
                    );
            } */

            /* dynamic result;
            using (DiseaseEntities1 db1 = new DiseaseEntities1())
            {
                result = GetAllBooksFullData(db1);
            }

            foreach (var book in result)
            {
                Console.WriteLine(book);
            } */

            foreach (var book in GetAllBooksFullData())
            {
                Console.WriteLine(book);
            }
        }

        private static void AddAuthor(Author author)
        {
            using (DiseaseEntities1 db = new DiseaseEntities1())
            {
                db.Authors.Add(author);
                db.SaveChanges();
            }
        }

        private static IEnumerable<Author> GetAllAuthors()
        {
            IEnumerable<Author> authors;
            using (DiseaseEntities1 db = new DiseaseEntities1())
            {
                authors = db.Authors.ToList();
            }
            return authors;
        }

        private static void AddBook(Book book)
        {
            using (DiseaseEntities1 db = new DiseaseEntities1())
            {
                db.Books.Add(book);
                db.SaveChanges();
            }
        }

        private static IEnumerable<Book> GetAllBooks()
        {
            IEnumerable<Book> books;
            using (DiseaseEntities1 db = new DiseaseEntities1())
            {
                books = db.Books.ToList();
            }
            return books;
        }

        private static IEnumerable<string> GetAllBooksFullData(DiseaseEntities1 db)
        {
            IEnumerable<string> books;
            books =
                db.Books.Select(
                    (b) => b.Author.LastName + " " + b.Author.FirstName + ". " + b.Title + " (" + b.Publisher.PublisherName + ")"
                    ).ToList();
            return books;
        }

        private static IEnumerable<string> GetAllBooksFullData()
        {
            IEnumerable<string> books;
            using (DiseaseEntities1 db = new DiseaseEntities1())
            {
                books =
                db.Books.Select(
                    (b) => $"{b.Author.LastName} {b.Author.FirstName}. {b.Title} ({b.Publisher.PublisherName})"
                    ).ToList();
                // Console.WriteLine(books);
            }
            // return books.ToList();
            return books;
        }

        private static void AddPublisher(Publisher publisher)
        {
            using (DiseaseEntities1 db = new DiseaseEntities1())
            {
                db.Publishers.Add(publisher);
                db.SaveChanges();
            }
        }

        private static IEnumerable<Publisher> GetAllPublishers()
        {
            IEnumerable<Publisher> publishers;
            using (DiseaseEntities1 db = new DiseaseEntities1())
            {
                publishers = db.Publishers.ToList();
            }
            return publishers;
        }
    }
}
