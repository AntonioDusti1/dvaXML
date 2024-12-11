using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvaXML
{
    public class Book
    {
        public Book() { }

        public int BookID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Book(int bookId, string name, double price)
        {
            this.BookID = bookId;
            this.Name = name;
            this.Price = price;
        }
    }
}
