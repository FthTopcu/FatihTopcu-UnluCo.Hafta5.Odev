using System;
using FluentValidation;

namespace UnluCo.Hafta2.Odev.Application.StudentOperations.Commands.CreateStudent
{
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.Email).NotEmpty().MinimumLength(8);
            RuleFor(command => command.Model.SchoolId).GreaterThan(0);
            
        }
    }
}
