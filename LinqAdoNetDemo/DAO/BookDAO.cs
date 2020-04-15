using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAdoNetDemo.DAO
{
    public class BookDAO : AbstractDAO<Book>
    {
        public BookDAO(DiseaseEntities1 _db) : base(_db)
        {

        }

        public List<Book> FindListInAuthorAndTitle(string _text, Book[] book)
        {
            List<Book> listBooks = new List<Book>();
            for (int i = 0; i < book.Length; i++)
            {
                if (book[i].Title.Contains(_text) || book[i].Author.FirstName.Contains(_text))
                {
                    listBooks.Add(book[i]);
                }
            }
            return listBooks;
        }

        public List<Book> FindListInAuthorLastName(string _text, Book[] book)
        {
            List<Book> listBooks = new List<Book>();
            for (int i = 0; i < book.Length; i++)
            {
                if (book[i].Author.LastName.Contains(_text))
                {
                    listBooks.Add(book[i]);
                }
            }
            return listBooks;
        }
    }
}
