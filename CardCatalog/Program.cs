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
            CardCatalog.Initialize();

            bool Status = false;
            do
                Status = DisplayMenu(Status);
            while (Status == false);
        }

        private static bool DisplayMenu(bool status)
        {
            Console.WriteLine();
            Console.WriteLine("Menu");
            Console.WriteLine("1) List all books");
            Console.WriteLine("2) Add a book");
            Console.WriteLine("3) Save and Exit");
            string Input = Console.ReadLine();

            switch (Input)
            {
                case "1":
                    CardCatalog.ListBooks();
                    break;
                case "2":
                    CardCatalog.AddBook();
                    break;
                case "3":
                    CardCatalog.SaveXML();
                    status = true;
                    break;
                default:
                    break;
            }
            return status;
        }
    }
}