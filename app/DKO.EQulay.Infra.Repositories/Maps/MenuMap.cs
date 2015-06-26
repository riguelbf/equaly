using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using DKO.EQualy.Domain.Entities;

namespace DKO.EQulay.Infra.Repositories.Maps
{
    public class MenuMap : EntityTypeConfiguration<Menu>
    {
        public MenuMap()
        {
            this.ToTable("Menu");
            this.HasKey(m => m.Id);
            this.Property(m => m.Name).HasMaxLength(50);
            this.Property(m => m.ClassIcon).HasMaxLength(100);
            this.Property(m => m.Action).HasMaxLength(200);
            this.Property(m => m.Controller).HasMaxLength(200);

            this.HasMany(m => m.MenuItems);
        }
    }
}