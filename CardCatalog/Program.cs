using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCatalog

{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter File Path: ");
            CardCatalog catalog = new CardCatalog(Console.ReadLine());
        }

    }
    public class Book
    {
        public int Number { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public Book (int number, string title, string author)
        {
            Number = number;
            Title = title;
            Author = author;
        }
    }
    public class CardCatalog
    {
        private List<Book> Books = new List<Book>();

        public CardCatalog(string filename)
        {           
            string line;
            StreamReader file = new StreamReader(filename);
            while ((line = file.ReadLine()) != null)                                                            
            {
                String[] field = line.Split(',');
                //Create a book for each line in the csv file, and add them to books array.
                Books.Add(new Book(Convert.ToInt32(field[0]), field[1], field[2]));                
            }
            file.Close();

            ListBooks();
            Console.ReadLine();
        }

        public void ListBooks()
        {
            for (int i = 0; i < Books.Count; i++)
            {
                Console.WriteLine("{0} {1} {2}", Books[i].Number, Books[i].Title, Books[i].Author);
            }
        }

        public void AddBook(string bookname, string bookauthor, string bookid)
        {
            //get user input
            Books.Add(new Book(Convert.ToInt32(bookid), bookname, bookauthor));
        }

        public void save()
        {
            for (int i = 0; i < Books.Count; i++)
            {
                //write values to csv
            }
        }

    }
}