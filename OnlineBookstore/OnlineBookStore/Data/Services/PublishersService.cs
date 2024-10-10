using OnlineBookStore.Data.Base;
using OnlineBookStore.Models;

namespace OnlineBookStore.Data.Services
{
    public class PublishersService: EntityBaseRepository<Publisher>, IPublishersService
    {
        public PublishersService(AppDbContext context) : base(context){ }
    }
}
