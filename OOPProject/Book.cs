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
        public DateTime DueDate { get; set; }


        //constructor
        public Book(string _title, string _author, bool _status, DateTime _dueDate)
        {
            Title = _title;
            Author = _author;
            Status = _status;
            DueDate = _dueDate;
        }

        public override string ToString()
        {
            return string.Format("Title: {0,-10} Author: {1,20}", Title, Author);
        }



        public static List<Book> AllBooks = new List<Book>()
        {
            new Book("To Kill a Mockingbird", "Harper Lee", false, DateTime.Now),
            new Book("Pride and Prejudice", "Jane Austen", false, DateTime.Now),
            new Book("1984", "George Orwell", false, DateTime.Now),
            new Book("Jane Eyre", "Charlotte Bronte", true, DateTime.Now),
            new Book("The Great Gatsby", "F. Scott Fitzgerald", false, DateTime.Now),
            new Book("Animal Farm", "George Orwell", false, DateTime.Now),
            new Book("The Count of Monte Cristo", "Alexandre Dumas", true, DateTime.Now),
            new Book("Te Lord of the Rings", "J.R.R. Tolkien", false, DateTime.Now),
            new Book("Little Women", "Louisa May Alcott", true, DateTime.Now),
            new Book("The Hobbit", "J.R.R. Tolkien", false, DateTime.Now),
            new Book("The Picture of Dorian Gray", "Oscar Wilde", false, DateTime.Now),
            new Book("One Hundred Years of Solitude", "Gabriel Garcia Marquez", true, DateTime.Now),
        };
        public static void ListBooks()
        {
            for(int i = 0; i < AllBooks.Count; i++)
            {
                Console.WriteLine($"{AllBooks[i]}");
            }
        }
    }
}


