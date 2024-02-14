using FluentValidation;

namespace DinnerApp.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandValidator : AbstractValidator<CreateMenuCommand>  
{
    public CreateMenuCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MaximumLength(200);
        RuleFor(c => c.Description).NotEmpty().MaximumLength(1000);
        RuleFor(c => c.HostId).NotEmpty();
        RuleForEach(c => c.Sections).SetValidator(new MenuSectionCommandValidator());
    }
}