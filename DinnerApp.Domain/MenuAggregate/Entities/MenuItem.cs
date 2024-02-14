﻿using DinnerApp.Domain.Common.Models;
using DinnerApp.Domain.MenuAggregate.ValueObjects;

namespace DinnerApp.Domain.MenuAggregate.Entities
{
    public sealed class  MenuItem : Entity<MenuItemId>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

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
