using FluentValidation;

using Portfo.Services.Model;

namespace Portfo.Services.Validators
{
    public class ActivityValidator : AbstractValidator<Activity>
    {
        public ActivityValidator()
        {
            RuleFor(x => x.ActivityID).NotEmpty();
            RuleFor(x => x.ActivityOccuredAt).NotEmpty();
            RuleFor(x => x.ActivityOperation).NotEmpty();
            RuleFor(x => x.ActivityUser.AuthorID).NotEmpty();
        }
    }
}
