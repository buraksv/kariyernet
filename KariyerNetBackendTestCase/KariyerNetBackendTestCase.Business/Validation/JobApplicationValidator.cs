using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using KariyerNetBackendTestCase.Dto;
using KariyerNetBackendTestCase.Entity;

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
