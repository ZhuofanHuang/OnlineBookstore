using Humanizer;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using OnlineBookStore.Models;

namespace OnlineBookStore.Data.Services
{
    public interface IAuthorsService
    {
        Task<IEnumerable<Author>> GetAll();
        Author GetById(int id);
        void Add(Author author);
        Author Update(int id, Author newAuthor);
        void delete(int id);
    }
}
