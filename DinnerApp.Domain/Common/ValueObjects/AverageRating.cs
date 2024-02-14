using DinnerApp.Domain.Common.Models;

namespace DinnerApp.Domain.Common.ValueObjects;

public sealed class AverageRating : ValueObject
{
    private AverageRating(double value, int numberOfRatings)
    {
        Value = value;
        NumberOfRatings = numberOfRatings;
    }

    public double Value { get; private set;}
    public int NumberOfRatings { get; private set;}
    
    public static AverageRating CreateNew(double rating = 0, int numberOfRatings = 0)
    {
        return new AverageRating(rating, numberOfRatings);
    }
    
    public void AddRating(Rating rating)
    {
        Value = (Value * NumberOfRatings + rating.Value) / (NumberOfRatings + 1);
    }
    
    public void RemoveRating(Rating rating)
    {
        Value = (Value * NumberOfRatings - rating.Value) / (NumberOfRatings - 1);
        
    }
    
    protected override IEnumerable<object> GetEqualityComponent()
    {
        yield return Value;
        yield return NumberOfRatings;
    }
}