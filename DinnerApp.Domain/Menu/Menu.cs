using DinnerApp.Domain.Menu.Entities;
using DinnerApp.Domain.Menu.ValueObjects;
using DinnerApp.Domain.Common.Models;
using DinnerApp.Domain.Common.ValueObjects;
using DinnerApp.Domain.Dinner.ValueObjects;
using DinnerApp.Domain.Host.ValueObjects;
using DinnerApp.Domain.MenuReview.ValueObjects;

namespace DinnerApp.Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId>  
    {
        
        private readonly List<MenuSection> _sections = [];
        private readonly List<DinnerId> _dinners = [];
        private readonly List<MenuReviewId> _menuReviewIds;

        public string Name { get; }    
        public string Description { get; }
        public AverageRating AverageRating { get; }
        public IReadOnlyCollection<MenuSection> Sections => _sections.AsReadOnly();
        public HostId HostId { get; }
        public IReadOnlyCollection<DinnerId> DinnerIds => _dinners.AsReadOnly();
        public IReadOnlyCollection<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private Menu(MenuId menuId,
            string name,
            string description,
            HostId hostId,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(menuId)
        {
            Name = name;
            Description = description;
            HostId = hostId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Menu Create(string name, string description, HostId hostId)
        {
            return new Menu(
                MenuId.CreateUnique(),
                name,
                description,
                hostId,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }

    }
}
