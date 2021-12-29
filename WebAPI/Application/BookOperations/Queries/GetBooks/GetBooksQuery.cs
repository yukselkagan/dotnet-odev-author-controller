using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DbOperations;
using WebAPI.Common;
using WebAPI.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.BookOperations.GetBooks
{
    public class GetBooksQuery
    {

        private readonly BookStoreDbContext _dbContext;


        private readonly IMapper _mapper;


        public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
        {

            _dbContext = dbContext;
            _mapper = mapper;

        }



        public List<BooksViewModel> Handle()
        {
            


            var bookList = _dbContext.Books.Include(x => x.Genre).OrderBy(x => x.Id).ToList<Book>();


            /*
            List<BooksViewModel> vm = new List<BooksViewModel>();
            foreach (var book in bookList)
            {
                vm.Add(new BooksViewModel()
                {
                    Title = book.Title,
                    Genre = ((GenreEnum)book.GenreId).ToString(),
                    PublishDate = book.PublishDate.ToString("dd/MM/yyyy"),
                    PageCount = book.PageCount,

                    Id = book.Id,


                });

            }
            */

            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);

            




            return vm;

        }


    }






    public class BooksViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int PageCount { get; set; }

        public string PublishDate { get; set; }

        public string Genre { get; set; }




    }











}
