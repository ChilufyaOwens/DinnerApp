using DinnerApp.Domain.Common.Models;

namespace DinnerApp.Domain.Menu.ValueObjects;

public sealed class MenuItemId : ValueObject
{
    public Guid Value { get; }

    private MenuItemId(Guid value)
    {
        Value = value;
    }

    public static MenuItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponent()
    {
        yield return Value;
    }
}
