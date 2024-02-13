using DinnerApp.Domain.Common.Models;

namespace DinnerApp.Domain.Common.ValueObjects;

public class Rating : ValueObject
{
    public double Value { get; private set; }
    private Rating(double value)
    {
        Value = value;
    }
    protected override IEnumerable<object> GetEqualityComponent()
    {
        yield return Value;
    }
}