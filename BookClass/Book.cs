using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClass
{
    public class Book: IEquatable<Book>, IComparable<Book>, IComparable
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

        int IComparable.CompareTo(object b)
        {
            if (ReferenceEquals(b, null))
                return -1;
            if (ReferenceEquals(this, b))
                return 1;
            return CompareTo((Book)b);
        }

        public int CompareTo(Book b)
        {
            if (ReferenceEquals(b, null))
                return -1;
            if (ReferenceEquals(this, b))
                return 1;
            return Title.CompareTo(b.Title);
        }


        public override string ToString()
        {
            StringBuilder result = new StringBuilder("");
            result.AppendFormat("Title: {0}, Author: {1}, Year: {2}, Pages: {3}.", Title, Author, Pages);
            return string.Format("{0}", result);
        }
    }
}
