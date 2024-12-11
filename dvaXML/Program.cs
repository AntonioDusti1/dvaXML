using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvaXML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string xml1Path = "prvi.xml";
            string xml2Path = "drugi.xml";

            var comparer = new XmlComparer();
            var differences = comparer.Compare(xml1Path, xml2Path);

            Console.WriteLine("Razlike pronađene:");
            foreach (var diff in differences)
            {
                Console.WriteLine(diff);
            }
        }
    }
}
