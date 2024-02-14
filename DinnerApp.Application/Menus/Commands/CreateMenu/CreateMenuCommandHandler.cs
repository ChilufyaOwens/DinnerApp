using DinnerApp.Application.Common.Interfaces.Persistence;
using DinnerApp.Domain.HostAggregate.ValueObjects;
using DinnerApp.Domain.Menu;
using DinnerApp.Domain.MenuAggregate.Entities;
using ErrorOr;
using MediatR;

namespace DinnerApp.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler(IMenuRepository menuRepository)
    : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository = menuRepository;

    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
       await Task.CompletedTask;
       
       var menu = Menu.Create(
           HostId.Create(request.HostId), 
           request.Name,
           request.Description,
              request.Sections.ConvertAll(s => MenuSection.Create(
                  s.Name, 
                  s.Description,
                  s.Items.ConvertAll(item => MenuItem.Create(item.Name, item.Description)))
                  ));   
       
       _menuRepository.AddMenu(menu);
       return menu!; 
    }
}