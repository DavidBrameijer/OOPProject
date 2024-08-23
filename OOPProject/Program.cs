using OOPProject;
using static System.Runtime.InteropServices.JavaScript.JSType;

Console.WriteLine("Welcome to the Library Terminal.");
//Book.ListBooks();
//System.Console.WriteLine();
//System.Console.WriteLine("Please select a book you would like to check out, either by name or by author:");

string userInput;
bool runProgram = true;
List<Book> matchedBooks = new List<Book>();

//matchedBooks = Book.AllBooks.Where(b => b.Title.ToLower().Contains(userInput.ToLower())
//|| b.Author.ToLower().Contains(userInput.ToLower())).ToList();


do
{
    Book.ListBooks();
    System.Console.WriteLine();
    System.Console.WriteLine("Please select a book you would like to check out, either by name or by author:");

    userInput = Console.ReadLine();

    matchedBooks = Book.AllBooks.Where(b => b.Title.ToLower().Contains(userInput.ToLower())
    || b.Author.ToLower().Contains(userInput.ToLower())).ToList();
    if(matchedBooks.Count > 1)
    {
        Console.WriteLine("Here are your search results!"); 
    
        System.Console.WriteLine();
        for(int i =0; i < matchedBooks.Count; i++)
        {
            Console.WriteLine($"{i + 1} {matchedBooks[i]}");
        }
        System.Console.WriteLine("Please select a book you would like to check out!");
        userInput = Console.ReadLine();
        matchedBooks = Book.AllBooks.Where(b => b.Title.ToLower().Contains(userInput.ToLower())
        || b.Author.ToLower().Contains(userInput.ToLower())).ToList();
    }
    else if (matchedBooks.Count == 1)
    {
        if(matchedBooks[0].Status == true)
        {
            System.Console.WriteLine("This book is already checked out. ");
            runProgram = QuestionUser(runProgram);
        }
        else
        {
            System.Console.WriteLine("Would you like to check this book out? (y/n)");
            userInput = Console.ReadLine();
             if (userInput.ToLower() == "y")
            {
                foreach (Book b in Book.AllBooks.ToList())
                {
                    if (b.Title == matchedBooks[0].Title)
                    {
                        Book.AllBooks.Remove(b);
                    }
                }
                Book.AllBooks.Add(new CheckedOutBook(matchedBooks[0].Title, matchedBooks[0].Author, true, DateTime.Now.AddDays(14)));
            

                System.Console.WriteLine($"Your book {matchedBooks[0].Title} has been checked out and is due {DateTime.Now.AddDays(14)}");
                runProgram = QuestionUser(runProgram);
            }
            else if (userInput.ToLower() == "n")
            {

            }
            else
            {
                System.Console.WriteLine("Invalid input.");
            }
        }  
    }
    else 
    {
        System.Console.WriteLine("No book was found with that input");
    }
    continue;
}
while (runProgram);


static bool QuestionUser(bool answer){
    while(true){
        System.Console.WriteLine("Would you like to search for another book? ");
        string choice = Console.ReadLine();
        if (choice.ToLower().Trim() == "yes"){
            answer = true;
            break;
        } 
        else if (choice.ToLower().Trim() == "no"){
            answer = false;
            break;
        } 
        else {
            System.Console.WriteLine("Invalid response");
        }
    }
    return answer;
}
