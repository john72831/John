using FluentValidation;

namespace John.Api_MinimalApi.Validation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.FullName).NotEmpty();
        }
    }
}
