using LinqAdoNetDemo.DAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqAdoNetDemo
{
    public class Repo
    {
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
    }
}
