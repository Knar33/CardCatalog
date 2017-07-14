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

        private static string filename;
        public static void Initialize()
        {
            Console.Write("Enter File Path: ");
            string FileName = Console.ReadLine();
            if (File.Exists(FileName))
            {
                filename = FileName;
            }
            else
            {
                Console.WriteLine("File doesn't exist. Creating new file books.csv");
                using (StreamWriter createbook = new StreamWriter("books.csv", true))
                {
                }
                filename = "books.csv";
            }

            string line;
            StreamReader file = new StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {
                String[] field = line.Split(',');
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
            Books.Add(new Book(Convert.ToInt32(bookid), bookname, bookauthor, description));
            Console.WriteLine();
        }

        public static void Save()
        {
            using (StreamWriter file = new StreamWriter(filename))
            {
                for (int i = 0; i < Books.Count; i++)
                {
                    file.WriteLine("{0},{1},{2},{3}", Books[i].Number, Books[i].Title, Books[i].Author, Books[i].Description);
                }
            }
        }

    }
}
