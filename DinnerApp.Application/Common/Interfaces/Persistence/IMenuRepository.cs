using DinnerApp.Domain.MenuAggregate;

namespace DinnerApp.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    void AddMenu(Menu menu);
}