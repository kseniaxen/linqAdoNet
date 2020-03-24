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
            List<object> list =
                new List<object> {
                    new { Id = 1, DeadPercent = 3.1d, RecoveredPercent = 52d },
                    new { Id = 2, DeadPercent = 3.2d, RecoveredPercent = 50d },
                    new { Id = 3, DeadPercent = 2.97d, RecoveredPercent = 54d }
                };
            Type t = list.ElementAt(0).GetType();
            // Console.WriteLine(t.Name);

            /* var result =
                list.Where((o) => (double)t.GetProperty("DeadPercent").GetValue(o) > 3d)
                .Select((o) => (double)t.GetProperty("RecoveredPercent").GetValue(o)); */
            var result =
                list.Skip(1)
                .Take(1)
                .Select((o) => (double)t.GetProperty("RecoveredPercent").GetValue(o));
            Console.WriteLine(result);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            /* var result =
                list.Where((o) => (double)t.GetProperty("DeadPercent").GetValue(o) > 3d)
                .Select((o) => (double)t.GetProperty("RecoveredPercent").GetValue(o)).ToList();
            Console.WriteLine(result);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            } */


            /* LINQ to SQL */
            DiseaseEntities disease = new DiseaseEntities();
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

            XDocument doc1 = new XDocument();
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
            }
        }
    }
}
