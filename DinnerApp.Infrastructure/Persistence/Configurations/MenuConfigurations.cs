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
        ConfigureMenuDinnerIdsTable(builder);
        ConfigureMenuReviewIdsTable(builder);
    }

    private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(mr => mr.MenuReviewIds, mri =>
        {
            mri.ToTable("MenuReviewIds");

            mri.WithOwner().HasForeignKey("MenuId");

            mri.HasKey("Id");

            mri.Property(r => r.Value)
                .HasColumnName("MenuReviewId")
                .ValueGeneratedNever();
        });
        
        builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.DinnerIds, di =>
        {
            di.ToTable("MenuDinnerIds");

            di.WithOwner().HasForeignKey("MenuId");

            di.HasKey("Id");

            di.Property(d => d.Value)
                .HasColumnName("DinnerId")
                .ValueGeneratedNever();
        });
        
        builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }


    private void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.Sections, ms =>
        {
            ms.ToTable("MenuSections");

            ms.WithOwner().HasForeignKey("MenuId");

            ms.HasKey(nameof(MenuSection.Id), "MenuSectionId");

            ms.Property(s => s.Id)
            .HasColumnName("MenuSectionId")
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => MenuSectionId.Create(value));

            ms.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(100);

            ms.Property(s => s.Description)
            .IsRequired()
            .HasMaxLength(500);

            ms.OwnsMany(s => s.Items, ib =>
            {
                ib.ToTable("MenuItems");

                ib.WithOwner().HasForeignKey("MenuSectionId", "MenuId");

                ib.HasKey(nameof(MenuItem.Id),"MenuSectionId", "MenuId");

                ib.Property(i => i.Id)
                .HasColumnName("MenuItemId") 
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => MenuItemId.Create(value));

                ib.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(100);

                ib.Property(i => i.Description)
                .IsRequired()
                .HasMaxLength(500);

            });

            ms.Navigation(s => s.Items).Metadata.SetField("_items");
            ms.Navigation(s => s.Items).UsePropertyAccessMode(PropertyAccessMode.Field);

            
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
