using OnlineBookStore.Data.Base;
using OnlineBookStore.Data.ViewModels;
using OnlineBookStore.Models;

namespace OnlineBookStore.Data.Services
{
    public interface IBooksService : IEntityBaseRepository<Book>
    {
        Task<Book> GetBookByIdAsync(int id);
        Task<NewBookDropdownsVM> GetNewBookDropdownsValues();
        Task AddNewBookAsync(NewBookVM data);
        Task UpdateBookAsync(NewBookVM data);
    }
}
