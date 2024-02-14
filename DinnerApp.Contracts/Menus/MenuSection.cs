namespace DinnerApp.Contracts.Menus;

public record MenuSection(
    string Name,
    string Description,
    List<MenuItem> Items);