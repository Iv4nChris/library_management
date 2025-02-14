using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMgmtConsole
{
    internal class Book
    {
        public int BookId { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public bool IsAvailable { get; set; }
        public List<double> Rating { get; set; }

        //Constructor
        public Book( int bookId, string author = "Unknown", string title = "Unknown", bool isavailable = true) { 
            BookId = bookId;
            Author = author;
            Title = title;
            IsAvailable = isavailable;
            Rating = new List<double>();
        }


        


    }
}
