using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DbOperations;

namespace WebAPI.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {

        private readonly BookStoreDbContext _dbContext;

        public int authorId { get; set; }


        public DeleteAuthorCommand(BookStoreDbContext context)
        {
            _dbContext = context;

        }


        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x => x.Id == authorId);
            if(author is null)
            {
                throw new InvalidOperationException("Can not find author");
            }

            _dbContext.Remove(author);
            _dbContext.SaveChanges();


        }













    }
}
