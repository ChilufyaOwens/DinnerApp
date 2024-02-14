using DinnerApp.Domain.Common.Models;

namespace DinnerApp.Domain.MenuAggregate.ValueObjects;

public sealed class MenuSectionId : ValueObject
{
    public Guid Value { get; }
    
    private MenuSectionId(Guid value)
    {
        Value = value;
    }

    public static MenuSectionId CreateUnique()
    {
        return new MenuSectionId(Guid.NewGuid());
    }

    public static MenuSectionId Create(Guid value)
    {
        return new MenuSectionId(value);
    }

    protected override IEnumerable<object> GetEqualityComponent()
    {
        yield return Value;
    }

    
}
