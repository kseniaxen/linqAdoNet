using LinqAdoNetDemo.DAO;
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

            /* foreach (var book in BookDAO.GetAllBooksFullData())
            {
                Console.WriteLine(book);
            } */

            // CRUD
            // Create, Read*, Update, Delete
            // ReadAll(), Read(id)

            var context = new DiseaseEntities1();

            //var author2 = new AuthorDAO(new DiseaseEntities1()).Find(2);
            // Console.WriteLine(author2.FirstName);

            /* var publisherDAO = new PublisherDAO(context);
            var publisher3 = publisherDAO.Find(5);
            Console.WriteLine(publisher3);
            var publisher3Deleted = publisherDAO.Remove(publisher3);
            Console.WriteLine(publisher3Deleted); */

            BookDAO bookDAO = new BookDAO(context);
            var book = bookDAO.Find(10);
            book.Title = "T1001";
            bookDAO.Save(book);
            /*bookDAO.Save(
                new Book() {
                    Title = "t1000",
                    Pages = 1000,
                    Price = 999,
                    IdAuthor = 1,
                    IdPublisher = 3
                });*/
        }
    }
}
