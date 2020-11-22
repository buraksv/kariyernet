using FluentValidation;
using KariyerNetBackendTestCase.Dto;

namespace KariyerNetBackendTestCase.Business.Validation
{
    public class JobApplicationValidator : AbstractValidator<JobApplicationDto>
    {
        public JobApplicationValidator()
        {
            RuleFor(p => p.UserId).NotEmpty();
            RuleFor(p => p.CompanyJobAdvertisementId).NotEmpty();
            

        }
    }
}
