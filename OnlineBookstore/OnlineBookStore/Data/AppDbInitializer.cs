using OnlineBookStore.Data.Enum;
using OnlineBookStore.Models;
using static System.Net.WebRequestMethods;

namespace OnlineBookStore.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                if (!context.Authors.Any())
                {
                    context.Authors.AddRange(new List<Author>() { 
                        new Author()
                        {
                            FullName = "Mark P. O. Morford",
                            Bio = "This is the description of the author",
                        },
                        new Author()
                        {
                            FullName = "Richard Bruce Wright",
                            Bio = "This is the description of the author",
                        },
                        new Author()
                        {
                            FullName = "Carlo D'Este",
                            Bio = "This is the description of the author",
                        },
                        new Author()
                        {
                            FullName = "Gina Bari Kolata",
                            Bio = "This is the description of the author",
                        },
                        new Author()
                        {
                            FullName = "E. J. W. Barber",
                            Bio = "This is the description of the author",
                        }
                    });
                    context.SaveChanges();
                }

                if (!context.Publishers.Any())
                {
                    context.Publishers.AddRange(new List<Publisher>() {
                        new Publisher()
                        {
                            FullName = "Oxford University Press",
                            Bio = "This is the description of the publisher",
                        },
                        new Publisher()
                        {
                            FullName = "HarperFlamingo Canada",
                            Bio = "This is the description of the publisher",
                        },
                        new Publisher()
                        {
                            FullName = "HarperPerennial",
                            Bio = "This is the description of the publisher",
                        },
                        new Publisher()
                        {
                            FullName = "Farrar Straus Giroux",
                            Bio = "This is the description of the publisher",
                        },
                        new Publisher()
                        {
                            FullName = "W. W. Norton &amp; Company",
                            Bio = "This is the description of the publisher",
                        }
                    });
                    context.SaveChanges();
                }

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new List<Book>()
                    {
                        new Book()
                        {
                            Title = "Classical Mythology",
                            ISBN = "0195153448",
                            Description = "This is the description of the book",
                            PublishDate = "2002",
                            Quantity = 30,
                            Rating = 4,
                            Price = 39.99,
                            ImageURL = "http://images.amazon.com/images/P/0195153448.01.THUMBZZZ.jpg",
                            BookCategory = BookCategory.Mystery,
                            AuthorId = 1,
                            PublisherId = 1,
                        },
                        new Book()
                        {
                            Title = "Clara Callan",
                            ISBN = "0002005018",
                            Description = "This is the description of the book",
                            PublishDate = "2001",
                            Quantity = 30,
                            Rating = 4,
                            Price = 39.99,
                            ImageURL = "http://images.amazon.com/images/P/0002005018.01.THUMBZZZ.jpg",
                            BookCategory = BookCategory.Biography,
                            AuthorId = 2,
                            PublisherId = 2,
                        },
                        new Book()
                        {
                            Title = "Decision in Normandy",
                            ISBN = "0060973129",
                            Description = "This is the description of the book",
                            PublishDate = "1991",
                            Quantity = 30,
                            Rating = 4,
                            Price = 39.99,
                            ImageURL = "http://images.amazon.com/images/P/0060973129.01.THUMBZZZ.jpg",
                            BookCategory = BookCategory.History,
                            AuthorId = 3,
                            PublisherId = 3,
                        },
                        new Book()
                        {
                            Title = "Flu: The Story of the Great Influenza Pandemic of 1918 and the Search for the Virus That Caused It",
                            ISBN = "0374157065",
                            Description = "This is the description of the book",
                            PublishDate = "1999",
                            Quantity = 30,
                            Rating = 4,
                            Price = 39.99,
                            ImageURL = "http://images.amazon.com/images/P/0374157065.01.THUMBZZZ.jpg",
                            BookCategory = BookCategory.History,
                            AuthorId = 4,
                            PublisherId = 4,
                        },
                        new Book()
                        {
                            Title = "The Mummies of Urumchi",
                            ISBN = "0393045218",
                            Description = "This is the description of the book",
                            PublishDate = "1999",
                            Quantity = 30,
                            Rating = 4,
                            Price = 39.99,
                            ImageURL = "http://images.amazon.com/images/P/0393045218.01.THUMBZZZ.jpg",
                            BookCategory = BookCategory.Mystery,
                            AuthorId = 5,
                            PublisherId = 5,
                        },
                    });
                    context.SaveChanges();
                }

            }
        }
    }
}
