using DinnerApp.Domain.Common.Models;

namespace DinnerApp.Domain.Menu.ValueObjects
{
    public sealed class MenuSectionId : ValueObject
    {
        private Guid Value { get; }
        
        private MenuSectionId(Guid value)
        {
            Value = value;
        }

        public static MenuSectionId CreateUnique()
        {
            return new MenuSectionId(Guid.NewGuid());
        }

        protected override IEnumerable<object> GetEqualityComponent()
        {
            yield return Value;
        }
    }
}
