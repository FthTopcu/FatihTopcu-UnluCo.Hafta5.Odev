using FluentValidation;

namespace UnluCo.Hafta2.Odev.Application.StudentOperations.Queries.GetStudentDetail
{ 
    public class GetStudentDetailQueryValidator : AbstractValidator<GetStudentDetailQuery>
    {
        public GetStudentDetailQueryValidator()
        {
            RuleFor(query => query.StudentId).GreaterThan(0);
        }
    }
}
