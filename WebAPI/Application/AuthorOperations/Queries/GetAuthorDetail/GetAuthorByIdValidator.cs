using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebAPI.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorByIdValidator : AbstractValidator<GetAuthorById>
    {

        public GetAuthorByIdValidator()
        {
            RuleFor(command => command.authorId).GreaterThan(0);
        }


    }
}
