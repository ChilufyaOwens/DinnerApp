using DinnerApp.Domain.Menu;
using ErrorOr;
using MediatR;

namespace DinnerApp.Application.Menus.Commands.CreateMenu;

public record CreateMenuCommand(
    string HostId,
    string Name,
    string Description,
    List<MenuSectionCommand> Sections) : IRequest<ErrorOr<Menu>>;