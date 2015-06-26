using System.Data.Entity.ModelConfiguration;
using DKO.EQualy.Domain.Entities;

namespace DKO.EQulay.Infra.Repositories.Maps
{
    public class MenuItemMap : EntityTypeConfiguration<MenuItem>
    {
        public MenuItemMap()
        {
            this.ToTable("MenuItem");
            this.HasKey(m => m.Id);
            this.Property(m => m.ActionName).HasMaxLength(150).IsRequired();
            this.Property(m => m.ControllerName).HasMaxLength(150).IsRequired();
            this.Property(m => m.Name).HasMaxLength(150).IsRequired();
            this.Property(m => m.Url).HasMaxLength(150).IsRequired();
            this.Property(m => m.ClassIcon).HasMaxLength(100);

            this.HasMany(m => m.Permissao);
        }
    }
}

