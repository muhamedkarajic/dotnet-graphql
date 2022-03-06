var builder = WebApplication.CreateBuilder();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

var application = builder.Build();

application
    .UseRouting()
    .UseEndpoints(endpoints => endpoints.MapGraphQL());

application.Run();

public record Book(string Title, Author Author);
public record Author(string Name);

public class Query
{
    private readonly List<Book> _books = new()
    {
        new Book("I Love GraphQL", new Author("Brandon Minnick")),
        new Book("GraphQL is the Future", new Author("Brandon Minnick")),
        new Book("I love XML + SOAP", new Author("John 'I Hate New Technology"))
    };

    public List<Book> GetBooks => _books;
    public Book? GetBook(string title) => _books.FirstOrDefault(book => book.Title == title);
    public Author? GetAuthor(string name) => _books.FirstOrDefault(book => book.Author.Name == name)?.Author;
}