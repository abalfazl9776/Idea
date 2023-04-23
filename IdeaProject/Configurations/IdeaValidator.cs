using FluentValidation;
using IdeaProject.ViewModels.Idea;

namespace IdeaProject.Configurations
{
    public class IdeaValidator : AbstractValidator<IdeaInputVm>
    {
        public IdeaValidator()
        {
            RuleFor(x => x.Idea).NotEmpty().MinimumLength(50);
            RuleFor(x => x.Title).Length(0,10).WithMessage("You should declare the title");
        }
    }
}
