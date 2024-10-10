using Humanizer;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using OnlineBookStore.Data.Base;
using OnlineBookStore.Models;

namespace OnlineBookStore.Data.Services
{
    public interface IAuthorsService : IEntityBaseRepository<Author>
    {
    }
}
