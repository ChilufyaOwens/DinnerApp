using DinnerApp.Domain.Common.Models;

namespace DinnerApp.Domain.DinnerAggregate.ValueObjects;

public class DinnerId : ValueObject
{
    public Guid Value { get; }

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