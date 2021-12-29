using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {

        public CreateAuthorCommandValidator()
        {
            RuleFor(command => command.model.firstName).NotEmpty().MinimumLength(3);
            RuleFor(command => command.model.lastName).NotEmpty().MinimumLength(3);
            RuleFor(command => command.model.birthday).LessThan(DateTime.Now.Date);

        }


    }
}
