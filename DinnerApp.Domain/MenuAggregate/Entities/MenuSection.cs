using DinnerApp.Domain.Common.Models;
using DinnerApp.Domain.MenuAggregate.ValueObjects;

namespace DinnerApp.Domain.MenuAggregate.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();
    public string Name { get; private set; } 
    public string Description { get; private set;}
    public IReadOnlyCollection<MenuItem> Items => _items.AsReadOnly();

    private MenuSection(
        string name,
        string description,
        List<MenuItem> menuItems, MenuSectionId? id = null) : base( id ?? MenuSectionId.CreateUnique()) 
    {
        Name = name;
        Description = description;
        _items = menuItems;
    }

    public static MenuSection Create(
        string name,
        string description,
        List<MenuItem>? menuItems = null)
    {
        return new MenuSection(
            name,
            description,
            menuItems ?? []);
    }
    #pragma warning disable CS8618
    private MenuSection() { }
    #pragma warning restore CS8618  
}   
