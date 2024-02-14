namespace DinnerApp.Contracts.Menus;

public record CreateMenuRequest(
    string Name,
    string Description,
    List<MenuSection> Sections
    );

