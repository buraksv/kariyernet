using System.Text.RegularExpressions;
using FluentValidation;
using KariyerNetBackendTestCase.Dto;

namespace KariyerNetBackendTestCase.Business.Validation
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(p => p.UserCvId).NotEmpty();
            RuleFor(p => p.Email).NotEmpty().Must(EmailRegexControl);
            RuleFor(p => p.UserName).NotEmpty();
        }

        private bool EmailRegexControl(string email)
        {
            string regex = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

            return Regex.IsMatch(email, regex, RegexOptions.ECMAScript);
        }
    }
}
