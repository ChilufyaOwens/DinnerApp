using DinnerApp.Domain.Common.Models;

namespace DinnerApp.Domain.MenuAggregate.ValueObjects;

public sealed class MenuId : ValueObject
{
    public Guid Value { get; private set; }

    private MenuId(Guid value) { 
        Value = value;
    }

    public static MenuId CreateUnique()
    {
      return new MenuId(Guid.NewGuid());
    }

    public static MenuId Create(Guid value)
    {
        return new MenuId(value);
    }

    protected override IEnumerable<object> GetEqualityComponent()
    {
        yield return Value;
    }
}
