using FluentValidation;
using KariyerNetBackendTestCase.Core.Utilities.Exception;

namespace KariyerNetBackendTestCase.Core.Aspects.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var result = validator.Validate(entity);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
