using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject
{
    internal class Book
    {
        //propeties
        public string Title { get; set; }
        public string Author { get; set; }
        public bool Status { get; set; }
        

        //constructor
        public Book(string _title, string _author, bool _status)
        {
            Title = _title;
            Author = _author;
            Status = _status;
            
        }

    }
}
