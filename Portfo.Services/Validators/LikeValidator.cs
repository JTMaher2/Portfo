using FluentValidation;

using Portfo.Services.Model;

namespace Portfo.Services.Validators
{
    public class LikeValidator: AbstractValidator<Like>
    {
        public LikeValidator()
        {
            RuleFor(x => x.LikeAuthor.AuthorID).NotEmpty();
            RuleFor(x => x.LikePost.PostID).NotEmpty();
        }
    }
}
