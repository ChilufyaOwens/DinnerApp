using DinnerApp.Domain.Common.Models;
using DinnerApp.Domain.MenuAggregate.ValueObjects;

namespace DinnerApp.Domain.MenuAggregate.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items = [];
        public string Name { get; private set; } 
        public string Description { get; private set;}
        public IReadOnlyCollection<MenuItem> Items => _items.AsReadOnly();

        private MenuSection(MenuSectionId menuSectionId,
            string name,
            string description,
            List<MenuItem> menuItems) : base(menuSectionId) 
        {
            Name = name;
            Description = description;
            _items = menuItems;
        }

        public static MenuSection Create(
            string name,
            string description,
            List<MenuItem> menuItems)
        {
            return new MenuSection(
                MenuSectionId.CreateUnique(),
                name,
                description,
                menuItems ?? []);
        }
    }   
}
