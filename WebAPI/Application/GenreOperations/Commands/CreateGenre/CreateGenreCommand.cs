using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DbOperations;
using WebAPI.Entities;

namespace WebAPI.Application.GenreOperations.Commands.CreateGenre
{
 

    public class CreateGenreCommand
    {
        public CreateGenreModel Model { get; set; }

        private readonly BookStoreDbContext _context;


        public CreateGenreCommand(BookStoreDbContext context)
        {
            _context = context;
        }


        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Name == Model.name);
            if(genre is not null)
            {
                throw new InvalidOperationException("Already in Db");
            }
            genre = new Genre();
            genre.Name = Model.name;
            _context.Genres.Add(genre);
            _context.SaveChanges();


        }





    }








    public class CreateGenreModel
    {
        public string name { get; set; }
    }




}
