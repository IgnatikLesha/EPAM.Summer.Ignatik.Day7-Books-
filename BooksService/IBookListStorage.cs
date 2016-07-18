using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookClass;

namespace BooksService
{
    interface IBookListStorage
    {
            
        List<Book> LoadBooks();
        void SaveBooks(IEnumerable<Book> books);
    }
}

