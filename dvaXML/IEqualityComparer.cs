using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvaXML
{
    public class BookComparer : IEqualityComparer<Book>
    {
        public bool Equals(Book x, Book y)
        {
            return x != null && y != null && x.BookID == y.BookID;
        }

        public int GetHashCode(Book book)
        {
            return book.BookID.GetHashCode();
        }
    }
}
