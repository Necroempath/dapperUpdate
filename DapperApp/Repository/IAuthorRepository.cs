using Dapper.Models;

namespace Dapper.Repository;

public interface IAuthorRepository
{
    public Author GetAuthor(int id);
    public IEnumerable<Author> GetAuthors();
    public void DeleteAuthor(int id);
    public void DeleteAuthors(int[] ids);
    public Author AddAuthor(Author author);
    public void AddAuthors(IEnumerable<Author> authors);
    public Author UpdateAuthor(Author author);
    public Author UpdateAuthors(IEnumerable<Author> authors);
}