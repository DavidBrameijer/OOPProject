using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public override string ToString()
        {
            return string.Format("Title: {0, -35} Author: {1, -25}", Title, Author);
        }
        public static List<Book> AllBooks = new List<Book>()
        {
        
        };

        public static void ListBooks()
        {
            for (int i = 0; i < AllBooks.Count; i++)
            {
                System.Console.WriteLine($"{AllBooks[i]}");
            }
        }
        

    }
}


