using DinnerApp.Domain.Common.Models;

namespace DinnerApp.Domain.Host.ValueObjects;

public sealed class HostId : ValueObject
{
    private Guid Value { get; }

    private HostId(Guid value)
    {
        Value = value;
    }
    
    public static HostId CreateUnique()
    {
        return new HostId(Guid.NewGuid());
    }
    
    protected override IEnumerable<object> GetEqualityComponent()
    {
        yield return Value;
    }
}