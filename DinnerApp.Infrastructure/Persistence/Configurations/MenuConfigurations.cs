using DinnerApp.Domain.HostAggregate.ValueObjects;
using DinnerApp.Domain.Menu;
using DinnerApp.Domain.MenuAggregate.Entities;
using DinnerApp.Domain.MenuAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DinnerApp.Infrastructure.Persistence.Configurations;

public class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        ConfigureMenusTable(builder);
        ConfigureMenuSectionsTable(builder);
    }

    private void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.Sections, ms =>
        {
            ms.ToTable("MenuSections");

            ms.WithOwner().HasForeignKey("MenuId");

            ms.HasKey("Id", "MenuSectionId");

            ms.Property(ms => ms.Id)
            .HasColumnName("MenuSectionId")
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => MenuSectionId.Create(value));

            ms.Property(ms => ms.Name)
            .IsRequired()
            .HasMaxLength(100);

            ms.Property(ms => ms.Description)
            .IsRequired()
            .HasMaxLength(500);

            ms.OwnsMany(s => s.Items, ib =>
            {
                ib.ToTable("MenuItems");

                ib.WithOwner().HasForeignKey("MenuSectionId", "MenuId");

                ib.HasKey(nameof(MenuItem.Id),"MenuSectionId", "MenuId");

                ib.Property(ib => ib.Id)
                .HasColumnName("MenuItemId") 
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => MenuItemId.Create(value));

                ib.Property(ib => ib.Name)
                .IsRequired()
                .HasMaxLength(100);

                ib.Property(ib => ib.Description)
                .IsRequired()
                .HasMaxLength(500);

            });

            ms.Navigation(ms => ms.Items).Metadata.SetField("_items");
            ms.Navigation(ms => ms.Items).UsePropertyAccessMode(PropertyAccessMode.Field);

            
        });

        builder.Metadata.FindNavigation(nameof(Menu.Sections))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => MenuId.Create(value));

        builder.Property(m => m.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(m => m.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.OwnsOne(m => m.AverageRating);

        builder.Property(m => m.HostId)
            .IsRequired()
            .HasConversion(
            id => id.Value,
            value => HostId.Create(value)
            );

    }
}
