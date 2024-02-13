using DinnerApp.Domain.Common.Models;

namespace DinnerApp.Domain.Menu.ValueObjects
{
    public sealed class MenuId : ValueObject
    {
        private Guid Value { get; }

        private MenuId(Guid value) { 
            Value = value;
        }

        public static MenuId CreateUnique()
        {
          return new MenuId(Guid.NewGuid());
        }

        protected override IEnumerable<object> GetEqualityComponent()
        {
            yield return Value;
        }
    }
}
