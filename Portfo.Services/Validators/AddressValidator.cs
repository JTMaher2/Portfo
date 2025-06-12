using FluentValidation;

using Portfo.Services.Model;

namespace Portfo.Services.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.AddressStreet).NotEmpty();
            RuleFor(x => x.AddressCity).NotEmpty();
            RuleFor(x => x.AddressCountry).NotEmpty();
            RuleFor(x => x.AddressZipCode).NotEmpty();
        }
    }
}
