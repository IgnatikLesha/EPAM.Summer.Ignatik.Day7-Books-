using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookClass;

namespace BooksService
{
    class BinaryBookListStorage : IBookListStorage
    {
        private string filePath;
        public string FilePath {
            get { return filePath; }
            set
            {
                if(ReferenceEquals(value, null))
                    throw new ArgumentException();
                filePath = value;
            }
        }

        public BinaryBookListStorage(string path)
        {
            FilePath = path;
        }

        public List<Book> LoadBooks()
        {
            List<Book> books = new List<Book>();

            using (BinaryReader reader = new BinaryReader(File.Open(FilePath, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    Book book = new Book(reader.ReadString(), reader.ReadString(), 
                                         reader.ReadInt32(), reader.ReadInt32());
                    books.Add(book);
                }
            }
            return books;
        }

        public void SaveBooks(IEnumerable<Book> books)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(FilePath, FileMode.Create)))
            {
                foreach (var book in books)
                {
                    writer.Write(book.Author);
                    writer.Write(book.Title);
                    writer.Write(book.Year);
                    writer.Write(book.Pages);
                }
            }
        }
    }
}
