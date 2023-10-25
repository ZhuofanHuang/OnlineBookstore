using Humanizer;
using Microsoft.EntityFrameworkCore;
using OnlineBookStore.Data.Base;
using OnlineBookStore.Data.ViewModels;
using OnlineBookStore.Models;
using System.Reflection;

namespace OnlineBookStore.Data.Services
{
    public class BooksService : EntityBaseRepository<Book>, IBooksService
    {
        private readonly AppDbContext _context;
        public BooksService(AppDbContext context):base(context) 
        {
            _context = context;
        }

        public async Task AddNewBookAsync(NewBookVM data)
        {
            var newBook = new Book()
            {
                Title = data.Title,
                Description = data.Description,
                ISBN = data.ISBN,
                PublishDate = data.PublishDate,
                Quantity = data.Quantity,
                Rating = data.Rating,
                Price = data.Price,
                ImageURL = data.ImageURL,
                BookCategory = data.BookCategory,
                AuthorId = data.AuthorId,
                PublisherId = data.PublisherId
            };
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var bookDetails = await _context.Books
                .Include(a => a.Author)
                .Include(p => p.Publisher)
                .FirstOrDefaultAsync(n => n.Id == id);

            return bookDetails;
        }
        public async Task<NewBookDropdownsVM> GetNewBookDropdownsValues()
        {
            var response = new NewBookDropdownsVM()
            {
                Authors = await _context.Authors.OrderBy(n => n.FullName).ToListAsync(),
                Publishers = await _context.Publishers.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }

        public async Task UpdateBookAsync(NewBookVM data)
        {
            var dbBook = await _context.Books.FirstOrDefaultAsync(n => n.Id == data.Id);
            if(dbBook != null)
            {

                dbBook.Title = data.Title;
                dbBook.Description = data.Description;
                dbBook.ISBN = data.ISBN;
                dbBook.PublishDate = data.PublishDate;
                dbBook.Quantity = data.Quantity;
                dbBook.Rating = data.Rating;
                dbBook.Price = data.Price;
                dbBook.ImageURL = data.ImageURL;
                dbBook.BookCategory = data.BookCategory;
                dbBook.AuthorId = data.AuthorId;
                dbBook.PublisherId = data.PublisherId;
            }
            await _context.SaveChangesAsync();
        }
    }
}
