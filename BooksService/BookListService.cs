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
            if (ReferenceEquals(book, null))
                throw new ArgumentException();
            if (!Books.Contains(book))
                Books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
                throw new ArgumentException();
            if (Books.Contains(book))
                Books.Remove(book);
        }

        public void SortBooksByTag(IComparer<Book> comparer)
        {
            if (ReferenceEquals(comparer, null))
                throw new ArgumentException();
            Books.Sort(comparer);
        }

        public List<Book> FindBookByTag(Predicate<Book> match)
        {
            List<Book> result = new List<Book>();
            foreach (var book in Books.FindAll(match))
            {
                result.Add(book);
            }
            return result;
        }
    }
}
