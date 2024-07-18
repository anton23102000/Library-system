Library library = new Library();

while (true)
{
    Console.WriteLine("What action you want to do:\n1.Add a new book to the Library\n2.Remove book from the Library\n3.Show the list of books in the Library\n4.Exit");
    string action=Console.ReadLine();
    switch (action)
    {
        case "1":
            Console.Write("Enter title: ");
            string title = Console.ReadLine();
            Console.Write("Enter author: ");
            string author = Console.ReadLine();
            Console.Write("Enter release date (MM/DD/YYYY): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime releaseDate))
            {
                Book newBook = new Book(title, author, releaseDate);
                library.AddBook(newBook);
            }
            else
            {
                Console.WriteLine("Invalid date format.");
            }
            break;
            case "2":

            Console.Write("Please, enter title of the book you want to remove: ");
            string titleToRemove = Console.ReadLine();
            library.RemoveBook(titleToRemove);
            break;

            case "3":

            library.ShowList();
            break;

            case "4":
        
            Environment.Exit(0);
            break;

            default:
            Console.WriteLine("Invalid action. Please enter a number from 1 to 4.");
            break;
    }

}

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime ReleaseDate { get; set; }

    public Book(string title, string author, DateTime releaseDate)
    {
        Title = title;
        Author = author;
        ReleaseDate = releaseDate;
    }

   
}

public class Library
{
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine($"You added '{book.Title}' book to the library.");
    }

    public void RemoveBook(string Title) 
    {
        Book bookToRemove = books.Find(b => b.Title.Equals(Title, StringComparison.OrdinalIgnoreCase));
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            Console.WriteLine($"Book '{Title}' removed from the library.");
        }
        else
        {
            Console.WriteLine($"Book '{Title}' not found in the library.");
        }
    }

    public void ShowList()
    {
        if (books.Count <= 0)
        {
            Console.WriteLine("Library is empty");
        }
        else
        {
            foreach (Book book in books)
            {
                Console.WriteLine (book.Title);
            }
        }
    }
}