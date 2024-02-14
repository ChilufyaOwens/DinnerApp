using FluentValidation;

namespace DinnerApp.Application.Menus.Commands.CreateMenu;

public class MenuSectionCommandValidator : AbstractValidator<MenuSectionCommand>
{
    public MenuSectionCommandValidator()
    {
        RuleFor(s => s.Name).NotEmpty().MaximumLength(200);
        RuleFor(s => s.Description).NotEmpty().MaximumLength(1000);
        RuleForEach(s => s.Items).SetValidator(new MenuItemCommandValidator());
    }
    
}