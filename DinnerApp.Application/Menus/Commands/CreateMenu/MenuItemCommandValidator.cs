using FluentValidation;

namespace DinnerApp.Application.Menus.Commands.CreateMenu;

public class MenuItemCommandValidator : AbstractValidator<MenuItemCommand>
{
    public MenuItemCommandValidator()
    {
        RuleFor(i => i.Name).NotEmpty().MaximumLength(200);
        RuleFor(i => i.Description).NotEmpty().MaximumLength(1000);
    }
}