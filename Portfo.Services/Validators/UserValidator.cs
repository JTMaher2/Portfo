using FluentValidation;

using Portfo.Services.Model;

namespace Portfo.Services.Validators
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.AuthorFirstname).NotEmpty();
            RuleFor(x => x.AuthorLastname).NotEmpty();
            RuleFor(x => x.AuthorAddress.AddressID).NotEmpty();
        }
    }
}
