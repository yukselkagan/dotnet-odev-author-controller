using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }


                context.Genres.AddRange(

                    new Genre
                    {
                        Name = "Personal Growth"
                    },
                    new Genre
                    {
                        Name = "Science Fiction"
                    },
                    new Genre
                    {
                        Name = "Romance"
                    }


                );


                context.Authors.AddRange(
                    new Author
                    {
                        firstName = "Daniel",
                        lastName = "Defoe",
                        birthday = new DateTime(1700, 02, 02)
                    },
                    new Author
                    {
                        firstName = "Denis",
                        lastName = "Villeneuve",
                        birthday = new DateTime(1950, 03, 03)
                    },
                    new Author
                    {
                        firstName = "John",
                        lastName = "Doe",
                        birthday = new DateTime(1960, 01, 01)
                    }


                );

                

                context.Books.AddRange(
                    new Book
                    {
                        Id = 1,
                        Title = "Robinson Crusoe",
                        GenreId = 1,
                        PageCount = 100,
                        PublishDate = new DateTime(2000, 01, 01)
                    },
                    new Book
                    {
                        Id = 2,
                        Title = "Dune",
                        GenreId = 2,
                        PageCount = 200,
                        PublishDate = new DateTime(2002, 01, 01)
                    },
                    new Book
                    {
                        Id = 3,
                        Title = "Space",
                        GenreId = 2,
                        PageCount = 200,
                        PublishDate = new DateTime(2002, 01, 01)
                    }
                );

                context.SaveChanges();


                


            }


        }




    }
}
