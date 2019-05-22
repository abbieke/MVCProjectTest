using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjectTest.Models
{
    public class MixModel
    {
    }
    public class Mix
    {
        public int Id { get; set; }
        public List<Book> Books { get; set; }
        public List<Book> SecBooks { get; set; }
    }
}