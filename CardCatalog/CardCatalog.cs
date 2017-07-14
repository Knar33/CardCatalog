using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CardCatalog
{
    public class CardCatalog
    {
        private static List<Book> Books = new List<Book>();
        private static string filename = "";

        public static void Initialize()
        {
            Console.Write("Enter File Path: ");
            filename = Console.ReadLine();
            if (!File.Exists(filename))
            {
                if (File.Exists("books.xml"))
                {
                    filename = "books.xml";
                }
                else
                {
                    File.Create("books.xml").Close();
                    filename = "books.xml";

                    XmlSerializer reader = new XmlSerializer(typeof(List<Book>));
                    using (FileStream stream = File.OpenWrite(filename))
                    {
                        reader.Serialize(stream, Books);
                    }
                    Console.WriteLine("File doesn't exist. Creating new file books.xml");                    
                }
            }
            GetBooksXML();
        }

        public static void GetBooksCSV()
        {
            string line;
            StreamReader file = new StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {
                String[] field = line.Split(',');
                Books.Add(new Book(Convert.ToInt32(field[0]), field[1], field[2], field[3]));
            }
            file.Close();
        }

        public static void GetBooksXML()
        {
            XmlSerializer reader = new XmlSerializer(typeof(List<Book>));
            using (FileStream stream = File.OpenRead(filename))
            {
                Books = (List<Book>)reader.Deserialize(stream);
            }
        }

        public static void SaveCSV()
        {
            using (StreamWriter file = new StreamWriter(filename))
            {
                for (int i = 0; i < Books.Count; i++)
                {
                    file.WriteLine("{0},{1},{2},{3}", Books[i].Number, Books[i].Title, Books[i].Author, Books[i].Description);
                }
            }
        }
        
        public static void SaveXML()
        {
            XmlSerializer reader = new XmlSerializer(typeof(List<Book>));
            using (FileStream stream = File.OpenWrite(filename))
            {
                reader.Serialize(stream, Books);
            }
        }

        public static void ListBooks()
        {
            Console.WriteLine();
            for (int i = 0; i < Books.Count; i++)
            {
                Console.WriteLine("{0} {1} {2} {3}", Books[i].Number, Books[i].Title, Books[i].Author, Books[i].Description);
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
    }
}
