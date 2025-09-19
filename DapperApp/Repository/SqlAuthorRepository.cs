using System.Data;
using Dapper.Models;

namespace Dapper.Repository;

public class SqlAuthorRepository : IAuthorRepository
{
    IDbConnection _connection;

    public SqlAuthorRepository(IDbConnection connection, string connectionString)
    {
        _connection = connection;
        _connection.ConnectionString = connectionString;
    }
    
    public Author GetAuthor(int id)
    {
        string query = @"SELECT * FROM [Author] 
                         WHERE Id = @id";

        return _connection.QueryFirstOrDefault<Author>(query, new { @id = id })!;
    }

    public IEnumerable<Author> GetAuthors()
    {
        string query = @"SELECT * FROM [Author]";

        return _connection.Query<Author>(query);
    }

    public void RemoveAuthor(int id)
    {
        string query = @"DELETE FROM [Author]
                         WHERE Id = @id";

        _connection.Execute(query, new { @id = id });
    }

    public void RemoveAuthors(int[] ids)
    {
        foreach(var id in ids)
        {
            RemoveAuthor(id);
        }
    }

    public Author AddAuthor(Author author)
    {
        string query = @"INSERT INTO [Author] (FirstName, LastName)
                         VALUES (@firstName, @lastName)
                         SELECT CAST(SCOPE_IDENTITY() as int)";
        var id = _connection.QueryFirstOrDefault<int>(query, new { @firstName = author.FirstName, @lastName = author.LastName });

        author.Id = id;
        return author;
    }

    public void AddAuthors(IEnumerable<Author> authors)
    {
        foreach (var author in authors)
        {
            AddAuthor(author);
        }
    }

    public void UpdateAuthor(Author author)
    {
        string query = @"UPDATE [Author]
                         SET FirstName = @firstName, LastName = @lastName
                         WHERE ID = @id";

        _connection.Execute(query, new
        {
            @firstName = author.FirstName,
            @lastName = author.LastName,
            @id = author.Id
        });
    }

    public void UpdateAuthors(IEnumerable<Author> authors)
    {
        foreach (var author in authors)
        {
            UpdateAuthor(author);
        }
    }
}