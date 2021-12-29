using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {

        public UpdateAuthorCommandValidator()
        {
            RuleFor(command => command.model.firstName).MinimumLength(3).NotEmpty();
            RuleFor(command => command.model.lastName).NotEmpty().MinimumLength(3);
            RuleFor(command => command.model.birthday).LessThan(DateTime.Now.Date);
        }


    }
}
