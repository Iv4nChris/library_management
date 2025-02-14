using System.Transactions;

namespace LibraryMgmtConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the Library Book Manager");
            Library library = new Library();
            bool run = true;
            while (run) 
            {
                Console.WriteLine("=====================================================================");
                Console.WriteLine("1. Add new Book");
                Console.WriteLine("2. Add a rating to the book");
                Console.WriteLine("3. Borrow Book");
                Console.WriteLine("4. Return Book");
                Console.WriteLine("5. Remove Book");
                Console.WriteLine("6. Display all books");
                Console.WriteLine("7. Exit");

                Console.Write("Please select an option(1-6):");
                string userEntry = Console.ReadLine();

                switch (userEntry)
                {
                    case "1":
                        //Add Books
                        Console.Write("Enter ID\t:");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Title\t:");
                        string? title = Console.ReadLine();
                        Console.Write("Enter Author\t:");
                        string? author = Console.ReadLine();

                        bool addresult = library.Addbook(id, title, author);
                        if(addresult)
                        {
                            Console.WriteLine($"\"{title}\" Added Successfully! Enter to continue.\n");
                        }
                        else
                        {
                            Console.WriteLine($"\"{title}\" Book Denied!\n");
                        }
                        break;

                    case "2":

                        // Add Rating
                        Console.Write("Enter ID of the Book to Rate\t:");
                        int bookId = int.Parse(Console.ReadLine());
                        Console.Write("Enter rating (1-5)\t:");
                        double bookRate = double.Parse(Console.ReadLine());
                        string rateResult = library.AddRating(bookId, bookRate)? "Rate Add Successfully" : "Book Not Found!";
                        Console.WriteLine("rateResult\n");
                        continue;
                    case "3":
                        Console.Write("Enter the Book Id to Borrow\t:");
                        int bookid = int.Parse(Console.ReadLine());
                        string result = library.BorrowBook(bookid)? "Borrowed Successfully!" : "Book No Found!";

                        Console.WriteLine(result + "\n");
                        continue;
                    case "4":
                        Console.Write("Enter the Book Id to Return\t:");
                        int bookidReturn = int.Parse(Console.ReadLine());
                        string resultReturn = library.ReturnBook(bookidReturn) ? "Return Book Successfully" : "Book Not Found!";
                        Console.WriteLine(resultReturn + "\n");
                        continue;
                    case "5":
                        Console.Write("Enter the Book id to Remove\t:");
                        int removeId = int.Parse(Console.ReadLine());
                        string removeResult = library.RemoveBook(removeId) ? "Removed Successfully!" : "Book Not Found!" ;
                        Console.WriteLine(removeResult + "\n");
                        continue;
                    case "6":
                        //Display Books
                        library.GetBooks(true);
                        Console.WriteLine("Enter to Continue!");
                        break;
                    case "7":
                        //Exit Program
                        run = false;
                        Console.WriteLine("\n------ End of the Program! ------\n");
                        continue;
                    default:
                        Console.WriteLine("Invalid Entry \nPlease Try Again(press ENTER).");
                        break;
                }
                
                Console.ReadKey();
            }
        }
    }
}
