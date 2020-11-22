using FluentValidation;
using KariyerNetBackendTestCase.Dto;

namespace KariyerNetBackendTestCase.Business.Validation
{
    public class UserCvWorkExperienceValidator : AbstractValidator<UserCvWorkingExperienceDto>
    {
        public UserCvWorkExperienceValidator()
        {
            RuleFor(p => p.CompanyName).NotEmpty();
            RuleFor(p => p.CompanySector).NotEmpty(); 
            RuleFor(p => p.Title).NotEmpty(); 
            RuleFor(p => p.WorkDetail).NotEmpty();
            RuleFor(p => p.EndDate).GreaterThanOrEqualTo(y => y.StartDate).When(x => x.EndDate.HasValue);
            RuleFor(p => p.Country).GreaterThan((short)0);
            RuleFor(p => p.City).GreaterThan(0); 
        }
    }
}
