using System;
using FluentValidation;

namespace UnluCo.Hafta2.Odev.Application.SchoolOperations.Commands.CreateSchool
{
    public class CreateSchoolCommandValidator : AbstractValidator<CreateSchoolCommand>
    {
        public CreateSchoolCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(5);
            
        }
    }
}
