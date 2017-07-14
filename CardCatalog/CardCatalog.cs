using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCatalog
{
    public class CardCatalog
    {
        private static List<Book> Books = new List<Book>();

        public static void Initialize()
        {
            Console.Write("Enter File Path: ");
            string filename = Console.ReadLine();
            string line;
            StreamReader file = new StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {
                String[] field = line.Split(',');
                //Create a book for each line in the csv file, and add them to books array.
                Books.Add(new Book(Convert.ToInt32(field[0]), field[1], field[2], field[3]));
            }
            file.Close();
        }

        public static void ListBooks()
        {
            Console.WriteLine();
            for (int i = 0; i < Books.Count; i++)
            {
                Console.WriteLine("{0} {1} {2}", Books[i].Number, Books[i].Title, Books[i].Author);
            }
            Console.WriteLine();
        }

        public static void AddBook()
        {
            Console.WriteLine();
            Console.WriteLine("Book Title: ");
            string bookname = Console.ReadLine();
            Console.WriteLine("Author");
            string bookauthor = Console.ReadLine();
            Console.WriteLine("Description");
            string description = Console.ReadLine();
            int bookid = (Books.Count + 1);
            //get user input
            Books.Add(new Book(Convert.ToInt32(bookid), bookname, bookauthor, description));
            Console.WriteLine();
        }

        public static void Save()
        {
            for (int i = 0; i < Books.Count; i++)
            {
                //write values to csv
            }
        }

    }
}
