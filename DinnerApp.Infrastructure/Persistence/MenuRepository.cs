using DinnerApp.Application.Common.Interfaces.Persistence;
using DinnerApp.Domain.Menu;

namespace DinnerApp.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    private static readonly List<Menu> _menus = [];
    public void AddMenu(Menu menu)
    {
        _menus.Add(menu);
    }
}