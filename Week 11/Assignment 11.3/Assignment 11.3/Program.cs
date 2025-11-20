using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BooksContext>();
var app = builder.Build();

// Make sure database is created
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BooksContext>();
    db.Database.EnsureCreated();
}

// CRUD Endpoints
app.MapGet("/api/books", async (BooksContext db) =>
    await db.Books.ToListAsync());

app.MapGet("/api/books/{id}", async (int id, BooksContext db) =>
    await db.Books.FindAsync(id) is Book book ? Results.Ok(book) : Results.NotFound());

app.MapPost("/api/books", async (Book book, BooksContext db) =>
{
    db.Books.Add(book);
    await db.SaveChangesAsync();
    return Results.Created($"/api/books/{book.Id}", book);
});

app.MapPut("/api/books/{id}", async (int id, Book updatedBook, BooksContext db) =>
{
    var book = await db.Books.FindAsync(id);
    if (book == null) return Results.NotFound();

    book.Title = updatedBook.Title;
    book.Author = updatedBook.Author;
    book.Description = updatedBook.Description;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/api/books/{id}", async (int id, BooksContext db) =>
{
    var book = await db.Books.FindAsync(id);
    if (book == null) return Results.NotFound();
    db.Books.Remove(book);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();

// Models and DbContext
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
}

public class BooksContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=books.db");
}
