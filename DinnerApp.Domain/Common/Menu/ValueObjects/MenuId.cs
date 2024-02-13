using DinnerApp.Domain.Common.Models;

namespace DinnerApp.Domain.Common.Menu.ValueObjects
{
    public sealed class MenuId : ValueObject
    {
        public Guid Value { get; }

        private MenuId(Guid value) { 
            Value = value;
        }

        public static MenuId CreateUnique()
        {
          return new(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponent()
        {
            yield return Value;
        }
    }
}
