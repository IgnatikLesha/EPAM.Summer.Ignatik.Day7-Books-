using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookClass;
using NLog;

namespace BooksService
{
    class BookListService
    {

        private List<Book> Books { get; }

        public BookListService(List<Book> books)
        {
            Books = books;
        }

        public void AddBook(Book book)
        {
            if(!Books.Contains(book))
                Books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            if (Books.Contains(book))
                Books.Remove(book);
        }

        public void SortBooksByTag(IComparer<Book> comparer)
        {
            Books.Sort(comparer);
        }

        public Book FindBookByTag()
        {

        }
    }
}
