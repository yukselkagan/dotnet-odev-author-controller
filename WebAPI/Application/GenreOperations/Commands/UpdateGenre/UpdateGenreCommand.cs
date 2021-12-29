using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DbOperations;

namespace WebAPI.Application.GenreOperations.Commands.UpdateGenre
{

    public class UpdateGenreCommand
    {
        private readonly BookStoreDbContext _context;

        public int GenreId { get; set; }

        public UpdateGenreModel Model { get; set; }


        public UpdateGenreCommand(BookStoreDbContext context)
        {
            _context = context;
            
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
            if(genre is null)
            {
                throw new InvalidOperationException("Can not find genre in Db");
            }

            if(_context.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Id != GenreId ))
            {
                throw new InvalidOperationException("Have genre with same name");
            }

            genre.Name = Model.Name;
            genre.IsActive = Model.isActive;
            _context.SaveChanges();




        }




    }



    public class UpdateGenreModel
    {
        public string Name { get; set; }

        public bool isActive { get; set; } = true;
    }

}
