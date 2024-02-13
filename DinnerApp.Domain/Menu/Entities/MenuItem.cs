using DinnerApp.Domain.Menu.ValueObjects;
using DinnerApp.Domain.Common.Models;
using DinnerApp.Domain.Menu.ValueObjects;

namespace DinnerApp.Domain.Menu.Entities
{
    public sealed class MenuItem : Entity<MenuItemId>
    {
        public string Name { get; }
        public string Description { get; }

        private MenuItem(MenuItemId menuItemId, string name, string description)
            : base(menuItemId) 
        {
            Name = name;  
            Description = description;
        }

        public static MenuItem Create(string name, string description)
        {
            return new MenuItem(MenuItemId.CreateUnique(), name, description);
        }
    }
}
