using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code_First_MySql_Web_Api.Models
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string  Language { get; set; }
        public int Pages { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
