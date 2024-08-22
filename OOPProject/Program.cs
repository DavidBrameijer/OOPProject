using OOPProject;
using static System.Runtime.InteropServices.JavaScript.JSType;

Console.WriteLine("Welcome to the Library Terminal.");
Book.ListBooks();
System.Console.WriteLine();
System.Console.WriteLine("Please select a book you would like to check out, either by name or by author:");

string userInput = Console.ReadLine();

List<Book> matchedBooks = new List<Book>();

//From there they can select one
matchedBooks = Book.AllBooks.Where(b => b.Title.ToLower().Contains(userInput.ToLower())
|| b.Author.ToLower().Contains(userInput.ToLower())).ToList();

if(matchedBooks.Any())
{
    foreach (Book book in matchedBooks)
    {
        System.Console.WriteLine($"{book.Title}, {book.Author}");
    }
}
else
{
    System.Console.WriteLine("No book was found with that input");
}


