using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCatalog

{
    class Program
    {
        static void Main(string[] args)
        {
            CardCatalog catalog = new CardCatalog(Console.ReadLine());

        }

    }
    public class Book
    {
        public string Author { get; set; }

        public string Title { get; set; }

        public int BookNumber { get; set; }
    }
    public class CardCatalog
    {
        private string filename;
        private List<Book> Books = new List<Book>;

        public CardCatalog(string filename)
        {

        }

        public void ListBooks()
        {

        }

        public void AddBook(string bookname, string bookauthor, string bookid)
        {

        }

        public void save()
        {

        }

    }
}