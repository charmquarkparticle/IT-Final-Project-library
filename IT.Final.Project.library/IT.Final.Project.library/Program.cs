namespace IT.Final.Project.library
{
    using System;
    using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {
            BookManager bookManager = new BookManager();

            while (true)
            {

                Console.WriteLine("press 1. add new book");
                Console.WriteLine("press 2. View all books");
                Console.WriteLine("press 3. Search for a book by title");
                Console.WriteLine("press 4. process completion");

                Console.WriteLine("Select one of the operations  ");
                string Select = Console.ReadLine();

                switch (Select)
                {
                    case "1":
                        Console.Write("Enter the title of the book in Latin letters: ");
                        string titleOfBook = Console.ReadLine();
                        Console.Write("Enter the author of the book: ");
                        string authorOfBook = Console.ReadLine();
                        Console.Write("Enter the year the book was published: ");
                        int yearOfBook;
                        if (!int.TryParse(Console.ReadLine(), out yearOfBook))
                        {
                            Console.WriteLine("Enter the year of publication of the book using correct numbers! ");
                            break;
                        }
                        bookManager.AddBook(titleOfBook, authorOfBook, yearOfBook);
                        break;
                    case "2":
                        Console.WriteLine("A list of all the books in the library:");
                        bookManager.ShowBooks();
                        break;
                    case "3":
                        Console.Write("Enter the title of the search book: ");
                        string searchTitleOfBook = Console.ReadLine();
                        bookManager.SearchByTitle(searchTitleOfBook);
                        break;
                    case "4":
                        Console.WriteLine("End of process");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("The operation is not selected correctly, please enter numbers 1 to 4 inclusive. ");
                        break;
                }
            }
        }
    }


    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }

        public Book(string titleOfBook, string authorOfBook, int publicationYearOfBook)
        {
            Title = titleOfBook;
            Author = authorOfBook;
            PublicationYear = publicationYearOfBook;
        }

        public override string ToString()
        {
            return $" titleOfBook - {Title}, authorOfBook - {Author} ({PublicationYear} publicationYearOfBook)";
        }
    }


    class BookManager
    {
        private List<Book> books = new List<Book>();


        public void AddBook(string titleOfBook, string authorOfBook, int publicationYearOfBook)
        {
            Book book = new Book(titleOfBook, authorOfBook, publicationYearOfBook);
            books.Add(book);
            Console.WriteLine("The book you entered has been successfully added to the library.");
        }


        public void ShowBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("The book could not be found in the library database.");
                return;
            }

            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }


        public void SearchByTitle(string titleOfBook)
        {
            bool search = false;
            foreach (var book in books)
            {
                if (book.Title.ToLower() == titleOfBook.ToLower())
                {
                    Console.WriteLine(book);
                    search = true;
                }
            }
            if (!search)
            {
                Console.WriteLine("The book with the title you entered could not be found in the library database.");
            }
        }
    }
}
