using DinnerApp.Domain.Menu;

namespace DinnerApp.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    void AddMenu(Menu menu);
}