using Dapper.Models;

namespace Dapper.Repository;

public interface IAuthorRepository
{
    public Author GetAuthor(int id);
    public IEnumerable<Author> GetAuthors();
    public void RemoveAuthor(int id);
    public void RemoveAuthors(int[] ids);
    public Author AddAuthor(Author author);
    public void AddAuthors(IEnumerable<Author> authors);
    public void UpdateAuthor(Author author);
    public void UpdateAuthors(IEnumerable<Author> authors);
}