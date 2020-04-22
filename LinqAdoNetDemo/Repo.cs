using LinqAdoNetDemo.DAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqAdoNetDemo
{
    public class Repo
    {
        public void readFromTxtFile(string name)
        {
            var context = new DiseaseEntities1();
            BookDAO bookDAO = new BookDAO(context);
            Regex regex = new Regex(@"(.+?) (.+?) (.+?) (.+?) (.+?)");

            using (StreamReader fs = new StreamReader(name))
            {
                //for (int i = 0; i < 1000; i++)
                //{
                while (!fs.EndOfStream)
                {
                    List<string> infoTemp = new List<string>();
                    string temp = fs.ReadLine();
                    string[] result = regex.Split(temp);
                    foreach (var item in result)
                    {
                        if (item.Length > 0)
                        {
                            infoTemp.Add(item);
                        }
                    }
                    bookDAO.Save(new Book
                    {
                        Title = infoTemp[0],
                        IdAuthor = Int32.Parse(infoTemp[1]),
                        Pages = Int32.Parse(infoTemp[2]),
                        Price = Int32.Parse(infoTemp[3]),
                        IdPublisher = Int32.Parse(infoTemp[4])
                    });
                }

            }
        }

        public static DataTable getDataTableBooks(string word)
        {
            DataTable dataTable = new DataTable();

            var context = new DiseaseEntities1();

            BookDAO bookDAO = new BookDAO(context);

            Book[] book = context.Books.ToArray();

            List<Book> books = bookDAO.FindListInAuthorLastName(word, book);

            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Title");
            dataTable.Columns.Add("LastName");
            dataTable.Columns.Add("Pages");
            dataTable.Columns.Add("Price");
            dataTable.Columns.Add("Publisher");

            foreach (var item in books)
            {
                DataRow row = dataTable.NewRow();

                row[0] = item.Id;
                row[1] = item.Title;
                row[2] = item.Author.LastName;
                row[3] = item.Pages;
                row[4] = item.Price;
                row[5] = item.Publisher.PublisherName;
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }

        public static DataTable getDataTableBooksLoading(int _h)
        {
            DataTable dataTable = new DataTable();

            var context = new DiseaseEntities1();

            BookDAO bookDAO = new BookDAO(context);

            Book[] book = context.Books.ToArray();

            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Title");
            dataTable.Columns.Add("LastName");
            dataTable.Columns.Add("FirstName");
            dataTable.Columns.Add("Pages");
            dataTable.Columns.Add("Price");
            dataTable.Columns.Add("Publisher");

            for (int i = 0; i < book.Length; i+=_h)
            {
                DataRow row = dataTable.NewRow();

                row[0] = book[i].Id;
                row[1] = book[i].Title;
                row[2] = book[i].Author.LastName;
                row[3] = book[i].Author.FirstName;
                row[4] = book[i].Pages;
                row[5] = book[i].Price;
                row[6] = book[i].Publisher.PublisherName;
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }
    }
}
