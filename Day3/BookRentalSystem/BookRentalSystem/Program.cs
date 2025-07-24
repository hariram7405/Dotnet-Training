using System;
using System.Collections.Generic;
using BookRentalSystem.Models;
using BookRentalSystem.Services;

class Program
{
    public static void Main(string[] args)
    {
        // Create book list
        List<Book> books = new List<Book>();

        // Create Fiction and NonFiction books
        Fiction f1 = new Fiction(5001, "The Mystery Case", "Lokesh", "Available", "Drama");
        NonFiction n1 = new NonFiction(4001, "The Universe Explained", "Smith", "Available", "Science");

        // Add books to list
        books.Add(f1);
        books.Add(n1);

        // Use service via interface (DIP)
        IServicable bookService = new BookServices();

        // Display initial book info
        Console.WriteLine("=== Initial Book Display ===");
        Console.WriteLine();
        f1.Display();
        n1.Display();

        // Rent books
        f1.Rent();
        n1.Rent();

        // Service logs
        bookService.RentBook(f1);
        bookService.RentBook(n1);

        // Report status after renting
        Console.WriteLine("\n=== After Renting ===");
        Console.WriteLine();
        f1.ReportStatus();
        n1.ReportStatus();

        // Return books
        f1.Return();
        n1.Return();

        // Service logs
        bookService.ReturnBook(f1);
        bookService.ReturnBook(n1);

        // Report status after return
        Console.WriteLine("\n=== After Returning ===");
        f1.ReportStatus();
        n1.ReportStatus();

        // Search for a specific book
        Console.WriteLine("\n=== Search Book ===");
        bookService.Search(books, "The Mystery Case");

        // Display all books
        Console.WriteLine("\n=== Display All Books ===");
        bookService.DisplayAll(books);
    }
}
