using DinnerApp.Application.Common.Interfaces.Persistence;
using DinnerApp.Domain.MenuAggregate;

namespace DinnerApp.Infrastructure.Persistence.Repositories;

public class MenuRepository(DinnerDbContext dbContext) : IMenuRepository
{
    private readonly DinnerDbContext _dbContext = dbContext;

    public void AddMenu(Menu menu)
    {
        _dbContext.Add(menu);

        _dbContext.SaveChanges();
    }
}