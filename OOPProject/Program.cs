using System.ComponentModel.Design;
using System.IO.Pipes;
using System.Reflection;
using OOPProject;
using static System.Runtime.InteropServices.JavaScript.JSType;

Console.WriteLine("Welcome to the Library Terminal.");
//Book.ListBooks();
//System.Console.WriteLine();
//System.Console.WriteLine("Please select a book you would like to check out, either by name or by author:");

string userInput;
bool runProgram = true;
List<Book> matchedBooks = new List<Book>();

string filepath = "../../../library.txt";

if (File.Exists(filepath) == false)
{
    StreamWriter tempWriter = new StreamWriter(filepath);
    tempWriter.WriteLine("To Kill a Mockingbird|Harper Lee|false");
    tempWriter.WriteLine("Pride and Prejudice|Jane Austen|false");
    tempWriter.WriteLine("1984|George Orwell|false");
    tempWriter.WriteLine("Jane Eyre|Charlotte Bronte|false");
    tempWriter.WriteLine("The Great Gatsby|F. Scott Fitzgerald|false");
    tempWriter.WriteLine("Animal Farm|George Orwell|false");
    tempWriter.WriteLine("The Count of Monte Cristo|Alexandre Dumas|false");
    tempWriter.WriteLine("The Lord of the Rings|J.R.R. Tolkien|false");
    tempWriter.WriteLine("Little Women|Louisa May Alcott|false");
    tempWriter.WriteLine("The Hobbit|J.R.R. Tolkien|false");
    tempWriter.WriteLine("The Picture of Dorian Gray|Oscar Wilde|false");
    tempWriter.WriteLine("One Hundred Years of Solitude|Gabriel Garcia Marquez|false");
    tempWriter.WriteLine("Charlotte's Web|E.B White|true|2024-08-26 10:10");
    tempWriter.Close();
}

StreamReader reader = new StreamReader(filepath);
while (true)
{
    string line = reader.ReadLine();
    if (line == null)
    {
        break;
    }
    else
    {
        string[] parts = line.Split("|");
        if (parts.Length == 3)
        {
            Book book = new Book(parts[0], parts[1], bool.Parse(parts[2]));
            Book.AllBooks.Add(book);
        }
        else if (parts.Length == 4)
        {
           CheckedOutBook checkedOutBook = new CheckedOutBook(parts[0], parts[1], bool.Parse(parts[2]), DateTime.Parse(parts[3]));
           Book.AllBooks.Add(checkedOutBook);
        }
    }
}
reader.Close();




do
{
    if (Book.AllBooks.Count == 0)
    {
        Console.WriteLine("The library has burned down");
    }

    //ask if checking or returning
    Console.WriteLine("Would you like to return a book or check a book out? (return/check)");

    

    //if returning{}
    string choice = Console.ReadLine().Trim().ToLower();
    if (choice == "return" || choice == "r")
    {
        int index = 0;
        foreach (Book b in Book.AllBooks.Where(b => b is CheckedOutBook))
        {
            index++;
        }
        if (index > 0)
        {

            //foreach(Book b in Book.AllBooks.Where(b => b.Status == true))
            foreach (Book b in Book.AllBooks.Where(b => b is CheckedOutBook))
            {
                Console.WriteLine(b.Title);
            }
            Console.WriteLine("Which book are you returning?");
            userInput = Console.ReadLine();
            matchedBooks = Book.AllBooks.Where(b => b is CheckedOutBook
            && b.Title.ToLower().Contains(userInput.ToLower())).ToList();
            while (matchedBooks.Count > 1)
            {
                for (int i = 0; i < matchedBooks.Count; i++)
                {
                    Console.WriteLine(matchedBooks[i]);
                }
                Console.WriteLine("Here are your search results!");

                System.Console.WriteLine();
                //for (int i = 0; i < matchedBooks.Count; i++)
                //{
                //    Console.WriteLine($"{i + 1} {matchedBooks[i]}");
                //}
                System.Console.WriteLine("Which book would like to return?");
                userInput = Console.ReadLine();
                matchedBooks = Book.AllBooks.Where(b => b is CheckedOutBook
                && b.Title.ToLower().Contains(userInput.ToLower())).ToList();
                if (matchedBooks.Count == 1)
                {
                    break;
                }
            }
            if (matchedBooks.Count == 1)
            {
                //if (matchedBooks[0].Status == true)
                //{
                //    System.Console.WriteLine("This book is already checked out. ");
                //    runProgram = QuestionUser(runProgram);
                //}
                System.Console.WriteLine($"Would you like to return {matchedBooks[0].Title}? (y/n)");
                userInput = Console.ReadLine();
                if (userInput.ToLower() == "y" || userInput.ToLower() == "yes")
                {
                    foreach (Book b in Book.AllBooks.ToList())
                    {
                        if (b.Title == matchedBooks[0].Title)
                        {
                            Book.AllBooks.Remove(b);
                        }
                    }
                    Book.AllBooks.Add(new Book(matchedBooks[0].Title, matchedBooks[0].Author, false));


                    System.Console.WriteLine($"Your book {matchedBooks[0].Title} has been returned!");
                    runProgram = QuestionUser(runProgram);
                }
                else if (userInput.ToLower() == "n" || userInput.ToLower() == "no")
                {
                    runProgram = QuestionUser(runProgram);
                }
                else
                {
                    System.Console.WriteLine("Invalid input.");
                    runProgram = QuestionUser(runProgram);
                }

            }
            else if (matchedBooks.Count == 0)
            {
                System.Console.WriteLine("No book was found with that input");
                runProgram = QuestionUser(runProgram);
            }
        }
        else
        {
            Console.WriteLine("There are no books checked out.");
            runProgram = QuestionUser(runProgram);
        }
    }

    //if checking out
    else if (choice == "check" || choice == "c")
    {
        Book.ListBooks();
        System.Console.WriteLine();
        System.Console.WriteLine("Please select a book you would like to check out, either by name or by author:");

        userInput = Console.ReadLine();

        matchedBooks = Book.AllBooks.Where(b => b.Title.ToLower().Contains(userInput.ToLower())
        || b.Author.ToLower().Contains(userInput.ToLower())).ToList();
        while (matchedBooks.Count > 1)
        {
            Console.WriteLine("Here are your search results!");

            System.Console.WriteLine();
            for (int i = 0; i < matchedBooks.Count; i++)
            {
                Console.WriteLine($"{i + 1} {matchedBooks[i]}");
            }
            System.Console.WriteLine("Please continue searching for a book.");
            userInput = Console.ReadLine();
            matchedBooks = Book.AllBooks.Where(b => b.Title.ToLower().Contains(userInput.ToLower())
            || b.Author.ToLower().Contains(userInput.ToLower())).ToList();
            if (matchedBooks.Count == 1)
            {
                break;
            }
        }
        if (matchedBooks.Count == 1)
        {
            if (matchedBooks[0].Status == true)
            {
                System.Console.WriteLine("This book is already checked out. ");
                runProgram = QuestionUser(runProgram);
            }
            else
            {
                System.Console.WriteLine($"Would you like to check out {matchedBooks[0].Title}? (y/n)");
                userInput = Console.ReadLine();
                if (userInput.ToLower() == "y" || userInput.ToLower() == "yes")
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
                else if (userInput.ToLower() == "n" || userInput.ToLower() == "no")
                {
                    runProgram = QuestionUser(runProgram);
                }
                else
                {
                    System.Console.WriteLine("Invalid input.");
                    runProgram = QuestionUser(runProgram);
                }
            }
        }
        else if (matchedBooks.Count == 0)
        {
            System.Console.WriteLine("No book was found with that input");
            runProgram = QuestionUser(runProgram);
        }
        continue;

    }
    else
    {
        Console.WriteLine("Invalid option. Please choose again.");
        continue;
    }
}
while (runProgram);


static bool QuestionUser(bool answer){
    string filepath = "../../../library.txt";
    while(true){
        System.Console.WriteLine("Would you like continue using the library terminal? ");
        string choice = Console.ReadLine();
        if (choice.ToLower().Trim() == "yes" || choice.ToLower().Trim() == "y")
        {
            answer = true;
            break;
        } 
        else if (choice.ToLower().Trim() == "no" || choice.ToLower().Trim() == "n")
        {
            Console.WriteLine("Thank you for using the Library Terminal.");
            if (File.Exists(filepath) == true)
            {
                StreamWriter writer = new StreamWriter(filepath);
                foreach (Book b in Book.AllBooks)
                {
                    if (b is CheckedOutBook checkedOutBook)
                    {
                        writer.WriteLine($"{checkedOutBook.Title}|{checkedOutBook.Author}|{checkedOutBook.Status}|{checkedOutBook.DueDate}");
                    }
                    else
                    {
                        writer.WriteLine($"{b.Title}|{b.Author}|{b.Status}");
                    }


                }
                writer.Close();
                answer = false;
                break;
             }
            else
            {
                answer = false;
                break;
            }
        } 
        else if(choice.ToLower().Trim() == "julius caesar")
        {
            Console.WriteLine("The library is burning");
            StreamWriter writer = new StreamWriter(filepath);
            writer.Close();
            try
            {
                File.Delete(@"../../../library.txt");
            }
            catch(System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
            }
            foreach(Book b in Book.AllBooks.ToList())
            {
                Console.WriteLine($"{b.Title} is burning");
                Book.AllBooks.Remove(b);
            }
        }


        else {
            System.Console.WriteLine("Invalid response");
        }
    }
    return answer;
}
