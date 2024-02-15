using DinnerApp.Application.Menus.Commands.CreateMenu;
using DinnerApp.Contracts.Menus;
using DinnerApp.Domain.MenuAggregate;
using Mapster;
using MenuItem = DinnerApp.Domain.MenuAggregate.Entities.MenuItem;
using MenuSection = DinnerApp.Domain.MenuAggregate.Entities.MenuSection;

namespace DinnerApp.Api.Common.Mapping;

public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest request, string HostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => src.HostId)
            .Map(dest => dest, src => src.request);

        config.NewConfig<Menu, CreateMenuResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.AverageRating, src => src.AverageRating.Value)
            .Map(dest => dest.HostId, src => src.HostId.Value)
            .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(d => d.Value))
            .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(menuId => menuId.Value));
        

        config.NewConfig<MenuSection, MenuSectionResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
            
        
        config.NewConfig<MenuItem, MenuItemResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}