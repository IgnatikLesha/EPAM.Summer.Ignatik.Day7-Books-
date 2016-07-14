using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClass
{
    class BookOperations
    {
        public static Book[] Sort(Book[] books, IComparer<Book> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException();

            foreach (var book in books)
            {
                if (book == null)
                    throw new ArgumentNullException();
            }

            for (int i = 0; i < books.Length; i++)
            {
                for (int j = i + 1; j < books.Length; j++)
                {
                    if (comparer.Compare(books[i], books[j]) > 0)
                    {
                        Swap(ref books[i], ref books[j]);
                    }
                }
            }
            return books;
        }

        private static void Swap(ref Book lhs, ref Book rhs)
        {
            var temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
    }
}
