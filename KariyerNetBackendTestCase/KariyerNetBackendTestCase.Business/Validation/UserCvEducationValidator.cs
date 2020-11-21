using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using KariyerNetBackendTestCase.Dto;
using KariyerNetBackendTestCase.Entity;

namespace KariyerNetBackendTestCase.Business.Validation
{
    public class UserCvEducationValidator : AbstractValidator<UserCvEducationDto>
    {
        public UserCvEducationValidator()
        {
            RuleFor(p => p.UserCvId).NotEmpty();
            RuleFor(p => p.SchoolLevel).NotEmpty();
            RuleFor(p => p.SchoolName).NotEmpty();
            RuleFor(p => p.GradeAverage).NotEmpty();
            RuleFor(p => p.EndYear).GreaterThanOrEqualTo(y => y.StartYear).When(x=>x.EndYear.HasValue);
        }
    }
}
