using FluentValidation;
using KariyerNetBackendTestCase.Dto;

namespace KariyerNetBackendTestCase.Business.Validation
{
    public class CompanyJobAdvertisementValidator : AbstractValidator<CompanyJobAdvertisementDto>
    {
        public CompanyJobAdvertisementValidator()
        {
            RuleFor(p => p.AdvertisementName).NotEmpty();
            RuleFor(p => p.CountryId).GreaterThan((short)0);
            RuleFor(p => p.CityId).GreaterThan(0);
            RuleFor(p => p.TownId).GreaterThan(0);

        }
    }
}
