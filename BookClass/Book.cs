using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClass
{
    public class Book: IEquatable<Book>, IComparable<Book>
    {
        private int year;
        private int pages;
        public string Author { get; set; }
        public string Title { get; set; }
        public int Pages 
        {
            get
            {
                    return pages;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException();
                pages = value;
            }
        }

        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                if (value < 0 || value > (int)DateTime.Now.Year)
                {
                    throw new ArgumentException();
                }
                year = Year;
            }
        }

        public Book(string title, string author, int year, int pages)
        {
            Title = title;
            Author = author;
            Year = year;
            Pages = pages;
        }

        public bool Equals(Book other)
        {
            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (!Author.Equals(other.Author) || !Title.Equals(other.Title) || Year != other.Year || Pages != other.Pages)
                return false;
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            if (ReferenceEquals(this, obj))
            {
                if (obj.GetType() != this.GetType())
                    return false;
            }
            return Equals((Book)obj);
        }

        public override int GetHashCode() => Author[0] * Year + Title[0] * Pages + 2 * (Year + Pages);


        public int CompareTo(Book book)
        {
            if (ReferenceEquals(book, null))
                return -1;
            if (ReferenceEquals(this, book))
                return 1;

            if (Author.CompareTo(book.Author) != 0)
                return Author.CompareTo(book.Author);

            if (Title.CompareTo(book.Title) != 0)
                return Title.CompareTo(book.Title);

            if (Year > book.Year)
                return 1;
            else if (Year == book.Year)
                return 0;
            else if (Year < book.Year)
                return -1;

            if (Pages > book.Pages)
                return 1;
            else if (Pages == book.Pages)
                return 1;
            else return -1;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("");
            result.AppendFormat("Title: {0}, Author: {1}, Year: {2}, Pages: {3}.", Title, Author, Pages);
            return string.Format("{0}", result);
        }


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
