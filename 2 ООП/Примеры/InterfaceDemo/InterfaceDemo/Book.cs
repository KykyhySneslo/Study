using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    internal class Book : ICloneable, IComparable<Book>
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Autor { get; set; }

        public override string ToString()
        {
            return "название книги: " + Title + "\nгод издания: "
                + Year + "\nАвтор: " + Autor;
        }
        public Book (string t, int y, string a)
        {
            Title = t;
            Year = y;
            Autor = a;
        }

        public Object Clone()
        {
            return new Book(Title, Year, Autor);
        }

        public int CompareTo(Book? book)
        {
            if (book is null) throw new ArgumentException("error");
            return Autor.CompareTo(book.Autor);
        }
    }
}
