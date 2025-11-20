using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Linq;

// =========================
//   BOOK CLASS (MODEL)
// =========================
// This class represents the table "Books" in the database.
// Code First will automatically create the table for us.
public class Book
{
    [Key]  // Primary key
    public string ISBN { get; set; }

    public string Name { get; set; }

    public string Author { get; set; }

    public string Description { get; set; }
}


// =========================
//   DATABASE CONTEXT
// =========================
// EF Core uses this class to connect to the database and
// create the Books table based on our Book class.
public class BookContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // SQLite database file
        optionsBuilder.UseSqlite("Data Source=books.db");
    }
}


// =========================
//   MAIN PROGRAM
// =========================
// Very simple console program that shows how to:
// 1. Create database (Code First)
// 2. Insert books
// 3. Display all books
// =========================
class Program
{
    static void Main(string[] args)
    {
        using (var db = new BookContext())
        {
            // This creates the database if it does not exist
            db.Database.EnsureCreated();

            Console.WriteLine("=== BOOKS INVENTORY SYSTEM ===");

            // ADD A SAMPLE BOOK
            Console.WriteLine("Adding a new book...");

            Book b = new Book()
            {
                ISBN = "123-ABC-456",
                Name = "The Beginner's Guide to C#",
                Author = "John Developer",
                Description = "A simple introduction to learning C# programming."
            };

            db.Books.Add(b);
            db.SaveChanges();

            Console.WriteLine("Book inserted successfully!");
            Console.WriteLine();

            // DISPLAY ALL BOOKS
            Console.WriteLine("=== BOOK LIST ===");
            var allBooks = db.Books.ToList();

            foreach (var book in allBooks)
            {
                Console.WriteLine("ISBN: " + book.ISBN);
                Console.WriteLine("Name: " + book.Name);
                Console.WriteLine("Author: " + book.Author);
                Console.WriteLine("Description: " + book.Description);
                Console.WriteLine("----------------------------------");
            }
        }

        Console.WriteLine("Done. Press any key to exit.");
        Console.ReadKey();
    }
}
