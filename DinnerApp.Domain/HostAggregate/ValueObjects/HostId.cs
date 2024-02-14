using DinnerApp.Domain.Common.Models;

namespace DinnerApp.Domain.HostAggregate.ValueObjects;

public sealed class HostId : ValueObject
{
    public Guid Value { get; }

    private HostId(Guid value)
    {
        Value = value;
    }
    
    public static HostId CreateUnique()
    {
        return new HostId(Guid.NewGuid());
    }
    
    public static HostId Create(string requestHostId)
    {
        return Guid.TryParse(requestHostId, out var guid) ? new HostId(guid) 
            : throw new ArgumentException("Invalid HostId");
    }
    
    protected override IEnumerable<object> GetEqualityComponent()
    {
        yield return Value;
    }

    
}