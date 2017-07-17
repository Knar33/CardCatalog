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
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Description { get; set; }

        public Book(int number, string title, string lastname, string firstname, string description)
        {
            Number = number;
            Title = title;
            Description = description;
            LastName = lastname;
            FirstName = firstname;
        }

        public Book()
        {

        }
    }
}
