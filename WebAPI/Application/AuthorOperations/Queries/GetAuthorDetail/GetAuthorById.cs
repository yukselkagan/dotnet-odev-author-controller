using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DbOperations;
using WebAPI.Entities;

namespace WebAPI.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorById
    {
        private readonly BookStoreDbContext _dbContext;

        private readonly IMapper _mapper;

        public int authorId { get; set; }

        public GetAuthorById(BookStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }


        public GetAuthorByIdModel Handle()
        {
            Author author = _dbContext.Authors.Where(x => x.Id == authorId).SingleOrDefault();
            if(author is null)
            {
                throw new InvalidOperationException("Can not find author");
            }


            /*without mapper
            GetAuthorByIdModel model = new GetAuthorByIdModel();
            model.firstName = author.firstName;
            model.lastName = author.lastName;
            model.birthday = author.birthday;
            */


            GetAuthorByIdModel vm = _mapper.Map<GetAuthorByIdModel>(author);


            return vm;




        }





    }



    public class GetAuthorByIdModel
    {

        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthday { get; set; }




    }






}
