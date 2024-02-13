using DinnerApp.Domain.Common.Menu.Entities;
using DinnerApp.Domain.Common.Menu.ValueObjects;
using DinnerApp.Domain.Common.Models;

namespace DinnerApp.Domain.Common.Menu
{
    public sealed class Menu : AggregateRoot<MenuId>  
    {
        private readonly List<MenuSection> _section = new();
        public string Name { get; }    
        public string Description { get; }
        public float AverageRatings { get; }

    }
}
