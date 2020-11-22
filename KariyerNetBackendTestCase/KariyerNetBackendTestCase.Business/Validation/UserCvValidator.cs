using FluentValidation;
using KariyerNetBackendTestCase.Dto;

namespace KariyerNetBackendTestCase.Business.Validation
{
    public class UserCvValidator : AbstractValidator<UserCvDto>
    {
        public UserCvValidator()
        {
            RuleFor(p => p.JobTitle).NotEmpty();
            RuleFor(p => p.PhoneNumber).NotEmpty();
            RuleFor(p => p.BornDate).NotEmpty();
            RuleFor(p => p.Country).GreaterThan((short)0);
            RuleFor(p => p.City).GreaterThan(0);
            RuleFor(p => p.Town).GreaterThan(0); 

        }
    }
}
