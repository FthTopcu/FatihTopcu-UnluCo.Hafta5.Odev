using FluentValidation;

namespace UnluCo.Hafta2.Odev.Application.SchoolOperations.Commands.UpdateSchool
{
    public class UpdateSchoolCommandValidator : AbstractValidator<UpdateSchoolCommand>
    {
        public UpdateSchoolCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(6);
        }
    }
}
