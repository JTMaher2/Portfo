using FluentValidation;

using Portfo.Services.Model;

namespace Portfo.Services.Validators
{
    public class PostValidator: AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(x => x.PostAuthor.AuthorID).NotEmpty();
            RuleFor(x => x.PostDescription).NotEmpty();
            RuleFor(x => x.PostTitle).NotEmpty();
        }
    }
}
