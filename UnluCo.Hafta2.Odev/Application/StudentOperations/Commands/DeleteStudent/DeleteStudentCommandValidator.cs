using System;
using FluentValidation;

namespace UnluCo.Hafta2.Odev.Application.StudentOperations.Commands.DeleteStudent
{
    public class DeleteStudentCommandValidator : AbstractValidator<DeleteStudentCommand>
    {
        public DeleteStudentCommandValidator()
        {
            RuleFor(command => command.StudentId).GreaterThan(0);
        }
    }
}
