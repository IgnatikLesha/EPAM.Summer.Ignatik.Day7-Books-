using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClass
{
    class CompareByYear : IComparer<Book>
    {
        public int Compare(Book first, Book second)
        {
            if (ReferenceEquals(first, second))
                return 0;

            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
                throw new ArgumentNullException();

            if (first.Year - second.Year > 0)
                return 1;
            else if (first.Year - second.Year == 0)
                return 0;
            else return -1;
        }
    }
}
