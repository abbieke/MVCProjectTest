using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjectTest.Models
{
    public class Book
    {
        public string BookId { get; set; }
        public string BooksName { get; set; }
        public string AuthorName { get; set; }
        public string CategoryEngName { get; set; }
        public string UnitPrice { get; set; }
        public string InStock { get; set; }
        public string Discount { get; set; }
        public string BookImage { get; set; }
    }
    //public string BookId { get; set; }
    //public string BooksName { get; set; }
    //public string PressID { get; set; }
    //public string CategoryID { get; set; }
    //public string AuthorID { get; set; }
    //public string UnitPrice { get; set; }
    //public string InStock { get; set; }
    //public string Discount { get; set; }
    //public string Description { get; set; }
    //public string ISBN { get; set; }
    //public string BookImage { get; set; }
}