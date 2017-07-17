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
        private static string fileName = "";

        public static void Initialize()
        {
            Console.Write("Enter File Path: ");
            fileName = Console.ReadLine();
            if (File.Exists(fileName))
            {
                GetBooksXML();
            }
            else { 
                if (File.Exists("books.xml"))
                {
                    fileName = "books.xml";
                    GetBooksXML();
                    Console.WriteLine("Using default file: books.xml");
                }
                else
                {
                    File.Create("books.xml").Close();
                    fileName = "books.xml";
                    Console.WriteLine("File doesn't exist. Creating new file: books.xml");
                }
            }
        }

        public static void GetBooksCSV()
        {
            string line;
            StreamReader file = new StreamReader(fileName);
            while ((line = file.ReadLine()) != null)
            {
                String[] field = line.Split(',');
                Books.Add(new Book(Convert.ToInt32(field[0]), field[1], field[2], field[3], field[4]));
            }
            file.Close();
        }

        public static void GetBooksXML()
        {
            XmlSerializer reader = new XmlSerializer(typeof(List<Book>));
            using (FileStream stream = File.OpenRead(fileName))
            {
                Books = (List<Book>)reader.Deserialize(stream);
            }
        }

        public static void SaveCSV()
        {
            using (StreamWriter file = new StreamWriter(fileName))
            {
                for (int i = 0; i < Books.Count; i++)
                {
                    file.WriteLine("{0},{1},{2},{3}", Books[i].Number, Books[i].Title, Books[i].LastName, Books[i].FirstName, Books[i].Description);
                }
            }
        }
        
        public static void SaveXML()
        {
            XmlSerializer reader = new XmlSerializer(typeof(List<Book>));
            using (FileStream stream = File.OpenWrite(fileName))
            {
                reader.Serialize(stream, Books);
            }
        }

        public static void ListBooks()
        {
            Console.WriteLine();
            for (int i = 0; i < Books.Count; i++)
            {
                Console.WriteLine("{0} | {1} | {2} | {3} | {4}", Books[i].Number, Books[i].Title, Books[i].LastName, Books[i].FirstName, Books[i].Description);
            }
            Console.WriteLine();
        }

        public static void AddBook()
        {
            Console.WriteLine();
            Console.Write("Book Title: ");
            string bookname = Console.ReadLine();
            Console.Write("Author's Last Name: ");
            string lastname = Console.ReadLine();
            Console.Write("Author's First Name: ");
            string firstname = Console.ReadLine();
            Console.Write("Description: ");
            string description = Console.ReadLine();
            int bookid = (Books.Count + 1);
            Books.Add(new Book(Convert.ToInt32(bookid), bookname, lastname, firstname, description));
            Console.WriteLine();
        }
    }
}
