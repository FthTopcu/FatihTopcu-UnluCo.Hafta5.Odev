using FluentValidation;

namespace UnluCo.Hafta2.Odev.Application.SchoolOperations.Queries.GetSchoolDetail
{ 
    public class GetSchoolDetailQueryValidator : AbstractValidator<GetSchoolDetailQuery>
    {
        public GetSchoolDetailQueryValidator()
        {
            RuleFor(query => query.SchoolId).GreaterThan(0);
        }
    }
}
