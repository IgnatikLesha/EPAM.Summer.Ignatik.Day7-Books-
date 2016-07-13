using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClass
{
    class CompareByPages: IComparer<Book>
    {
        public int Compare(Book first, Book second)
        {
            if (ReferenceEquals(first, second))
                return 0;

            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
                throw new ArgumentNullException();

            if (first.Pages > second.Pages )
                return 1;
            else if (first.Pages == second.Pages)
                return 0;
            else return -1;
        }
    }
}
