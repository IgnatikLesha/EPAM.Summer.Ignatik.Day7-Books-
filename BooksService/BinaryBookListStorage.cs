using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookClass;

namespace BooksService
{
    class BinaryBookListStorage : IBookListStorage
    {
        private string filePath;
        public BinaryBookListStorage(string path)
        {
            filePath = path;
        }

        public List<Book> LoadBooks()
        {
            throw new NotImplementedException();
        }

        public void SaveBooks(IEnumerable<Book> books)
        {
            throw new NotImplementedException();
        }
    }
}
