using DinnerApp.Domain.Common.Models;

namespace DinnerApp.Domain.MenuReview.ValueObjects;

public class MenuReviewId : ValueObject
{
    private Guid Value { get; }
    
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