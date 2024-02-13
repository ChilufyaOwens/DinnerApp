using DinnerApp.Domain.Common.Models;

namespace DinnerApp.Domain.Dinner.ValueObjects;

public class DinnerId : ValueObject
{
    private Guid Value { get; }

    private DinnerId(Guid value)
    {
        Value = value;
    }
   
    public static DinnerId CreateInstance()
    {
        return new DinnerId(Guid.NewGuid());
    }
    protected override IEnumerable<object> GetEqualityComponent()
    {
        yield return Value;
    }
}