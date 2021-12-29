using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DbOperations;
using WebAPI.Entities;

namespace WebAPI.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel model { get; set; }

        private readonly BookStoreDbContext _dbContext;

        private readonly IMapper _mapper;

        public CreateAuthorCommand(BookStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;

        }


        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x => x.firstName == model.firstName && x.lastName == model.lastName);

            if(author is not null)
            {
                throw new InvalidOperationException("Author already in db");
            }

            author = _mapper.Map<Author>(model);

            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();


        }





    }







    public class CreateAuthorModel
    {

        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthday { get; set; }



    }




}
