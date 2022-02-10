using System;
using FluentValidation;

namespace UnluCo.Hafta2.Odev.Application.SchoolOperations.Commands.DeleteSchool
{
    public class DeleteSchoolCommandValidator : AbstractValidator<DeleteSchoolCommand>
    {
        public DeleteSchoolCommandValidator()
        {
            RuleFor(command => command.SchoolId).GreaterThan(0);
        }
    }
}
