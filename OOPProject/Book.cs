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
            new Book("To Kill a Mockingbird", "Harper Lee", false),
            new Book("Pride and Prejudice", "Jane Austen", false),
            new Book("1984", "George Orwell", false),
            new Book("Jane Eyre", "Charlotte Bronte", false),
            new Book("The Great Gatsby", "F. Scott Fitzgerald", false),
            new Book("Animal Farm", "George Orwell", false),
            new Book("The Count of Monte Cristo", "Alexandre Dumas", false),
            new Book("The Lord of the Rings", "J.R.R. Tolkien", false),
            new Book("Little Women", "Louisa May Alcott", false),
            new Book("The Hobbit", "J.R.R. Tolkien", false),
            new Book("The Picture of Dorian Gray", "Oscar Wilde", false),
            new Book("One Hundred Years of Solitude", "Gabriel Garcia Marquez", false),
            new CheckedOutBook("Charlotte's Web", "E.B. White", true, DateTime.Now)
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


