using Dapper.Models;
using Dapper.Repository;
using Microsoft.Data.SqlClient;

namespace Dapper;

class Program
{
    static string connectionString = "Server=DESKTOP-OMIV6PG\\SQLEXPRESS;DataBase=AuthorDB;Integrated Security=true;TrustServerCertificate=True;";
    static void Main(string[] args)
    {
        SqlAuthorRepository repository = new(new SqlConnection(), connectionString);
        Author author = new(){FirstName = "John", LastName = "Smith"};
        Author authoress = new(){FirstName = "Jane", LastName = "Amoe", Id = 2};
        
        repository.UpdateAuthor(authoress);
    }
}