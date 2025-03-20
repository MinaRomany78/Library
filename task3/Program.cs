using static System.Reflection.Metadata.BlobBuilder;

namespace task3
{
    class Book
    {
        public string title { set; get; }
        public string author { set; get; }
        public string ISBN { set; get; }
        public bool available { set; get; }
        public Book(string title, string author, string iSBN)
        {
            this.title = title;
            this.author = author;
            this.ISBN = iSBN;
            this.available = true;
        }
    }
    class Library
    {
        public List<Book> Books { set; get; } = new List<Book>();
        public void AddBook(Book book) { Books.Add(book);
            Console.WriteLine($"Book '{book.title}' added to the library.");
        }
        public Book? SearchBook(string query)
        {
            for (int i = 0; i < Books.Count; i++)
            {
                if (Books[i].title == query || Books[i].author == query)
                {
                    return Books[i];
                }
            }
            return null;
        }
        public bool BorrowBook(string query)
        {
            Book? book = SearchBook(query);
            if (book != null)
            {
                if (book.available)
                {
                    book.available = false;
                    Console.WriteLine($"You have borrowed '{book.title}'.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Sorry, '{book.title}' is already borrowed.");
                    return false;
                }
            }
            Console.WriteLine($"Sorry, no book found with title or author '{query}'.");
            return false;
        }
        public bool ReturnBook(string query)
        {
            Book? book = SearchBook(query);
            if (book != null)
            {
                if (!book.available)
                {
                    book.available = true;
                    Console.WriteLine($"You have returned '{book.title}'.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Sorry, '{book.title}' is not borrowed.");
                    return false;
                }
            }
            Console.WriteLine($"Sorry, no book found with title or author '{query}'.");
            return false;
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                Library library = new Library();

                // Adding books to the library
                library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
                library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
                library.AddBook(new Book("1984", "George Orwell", "9780451524935"));

                // Searching and borrowing books
                Console.WriteLine("Searching and borrowing books...");
                library.BorrowBook("The Great Gatsby");
                library.BorrowBook("1984");
                library.BorrowBook("Harry Potter"); // This book is not in the library

                // Returning books
                Console.WriteLine("\nReturning books...");
                library.ReturnBook("The Great Gatsby");
                library.ReturnBook("Harry Potter"); // This book is not borrowed

                Console.ReadLine();
            }
        }
    }
}
