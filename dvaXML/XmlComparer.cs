using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace dvaXML
{
    internal class XmlComparer
    {
        public List<string> Compare(string xml1Path, string xml2Path)
        {
            var doc1 = XDocument.Load(xml1Path);
            var doc2 = XDocument.Load(xml2Path);

            var books1 = doc1.Descendants("book")
                .Select(book => new Book
                {
                    BookID = int.Parse((string)book.Attribute("id")),
                    Name = (string)book.Attribute("name"),
                    Price = 0 
                }).ToList();

            var books2 = doc2.Descendants("book")
                .Select(book => new Book
                {
                    BookID = int.Parse((string)book.Attribute("id")),
                    Name = (string)book.Attribute("name"),
                    Price = 0 
                }).ToList();

            var differences = new List<string>();

            var comparer = new BookComparer();

            // Check for differences
            foreach (var book1 in books1)
            {
                var book2 = books2.FirstOrDefault(b => comparer.Equals(b, book1));
                if (book2 == null)
                {
                    differences.Add($"- Razlika: id {book1.BookID} postoji samo u prvom dokumentu");
                }
                else
                {
                    if (book1.Name != book2.Name)
                    {
                        differences.Add($"- Razlika u atributu 'name' za id {book1.BookID}: '{book1.Name}' -> '{book2.Name}'");
                    }
                }
            }

            foreach (var book2 in books2)
            {
                if (!books1.Any(b => comparer.Equals(b, book2)))
                {
                    differences.Add($"- Razlika: id {book2.BookID} postoji samo u drugom dokumentu");
                }
            }

            return differences;
        }
    }
}
