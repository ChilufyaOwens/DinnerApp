using DinnerApp.Domain.Common.Models;

namespace DinnerApp.Domain.MenuReviewAggregate.ValueObjects;

public class MenuReviewId : ValueObject
{
    public Guid Value { get; }
    
    private MenuReviewId(Guid value)
    {
        Value = value;
    }
    
    public static MenuReviewId CreateUnique()
    {
        return new MenuReviewId(Guid.NewGuid());
    }
    protected override IEnumerable<object> GetEqualityComponent()
    {
        yield return Value;
    }
}