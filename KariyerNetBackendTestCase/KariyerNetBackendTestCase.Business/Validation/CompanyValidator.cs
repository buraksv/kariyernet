using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using KariyerNetBackendTestCase.Dto;
using KariyerNetBackendTestCase.Entity;

namespace KariyerNetBackendTestCase.Business.Validation
{
    public class CompanyValidator : AbstractValidator<CompanyDto>
    {
        public CompanyValidator()
        {
            RuleFor(p => p.CompanyName).NotEmpty();
            RuleFor(p => p.CompanyAddress).NotEmpty();
            RuleFor(p => p.CreatorUserId).NotEmpty();

        }
    }
}
