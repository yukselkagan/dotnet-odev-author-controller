using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DbOperations;

namespace WebAPI.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        private readonly BookStoreDbContext _dbContext;

        public int authorId { get; set; }

        public UpdateAuthorModel model { get; set; }



        public UpdateAuthorCommand(BookStoreDbContext context)
        {
            _dbContext = context;

        }




        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x => x.Id == authorId);
            if(author is null)
            {
                throw new InvalidOperationException("Author not in db");
            }

            author.firstName = (model.firstName != default) ? model.firstName : author.firstName;
            author.lastName = (model.lastName != default) ? model.lastName : author.lastName;
            author.birthday = (model.birthday != default) ? model.birthday : author.birthday;

            _dbContext.SaveChanges();

        }






    }






    public class UpdateAuthorModel
    {

        public string firstName { get; set; }
        public string lastName { get; set; }

        public DateTime birthday { get; set; }


    }


}
