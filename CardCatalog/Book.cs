using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCatalog
{
    public class Book
    {
        public int Number { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }

        public Book(int number, string title, string author, string description)
        {
            Number = number;
            Title = title;
            Description = description;
            Author = author;
        }
    }
}
