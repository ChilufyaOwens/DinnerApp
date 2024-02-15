using DinnerApp.Domain.Common.Models;
using DinnerApp.Domain.Common.ValueObjects;
using DinnerApp.Domain.DinnerAggregate.ValueObjects;
using DinnerApp.Domain.HostAggregate.ValueObjects;
using DinnerApp.Domain.MenuAggregate.Entities;
using DinnerApp.Domain.MenuAggregate.ValueObjects;
using DinnerApp.Domain.MenuReviewAggregate.ValueObjects;

namespace DinnerApp.Domain.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId>  
{
    
    private readonly List<MenuSection>? _sections = [];
    private readonly List<DinnerId> _dinnerIds = [];
    private readonly List<MenuReviewId> _menuReviewIds = [];

    public string Name { get; private set; }    
    public string Description { get; private set; }
    public AverageRating AverageRating { get; private set; }
    public IReadOnlyCollection<MenuSection>? Sections => _sections?.AsReadOnly();
    public HostId HostId { get; private set; }

    public IReadOnlyCollection<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    
    public IReadOnlyCollection<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Menu(
        MenuId menuId,
        HostId hostId,
        string name,
        string description,
        AverageRating averageRating,
        List<MenuSection>? sections
        ) : base(menuId)
    {
        HostId = hostId;
        Name = name;
        Description = description;
        AverageRating = averageRating;
        _sections = sections;
    }

    public static Menu  Create(
        HostId hostId, 
        string name, 
        string description, 
        List<MenuSection>? sections)
    {
        return new Menu(
            MenuId.CreateUnique(),
            hostId,
            name,
            description,
            AverageRating.CreateNew(0, 0), 
            sections ?? new() );
    }
    
    #pragma warning disable CS8618  
    private Menu() { }
    #pragma warning restore CS8618  

}
