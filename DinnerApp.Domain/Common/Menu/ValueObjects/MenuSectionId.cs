using DinnerApp.Domain.Common.Models;

namespace DinnerApp.Domain.Common.Menu.ValueObjects
{
    public sealed class MenuSectionId : ValueObject
    {
        public Guid Value { get; }
        x
        private MenuSectionId(Guid value)
        {
            Value = value;
        }

        public static MenuSectionId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponent()
        {
            yield return Value;
        }
    }
}
