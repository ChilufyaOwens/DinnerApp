namespace DinnerApp.Contracts.Menus;

public record CreateMenuResponse(
    string Id,
    string Name,
    string Description,
    float AverageRating,
    List<MenuSectionResponse> Sections,
    string HostId,
    List<string> DinnerIds,
    List<string> MenuReviewIds,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime);