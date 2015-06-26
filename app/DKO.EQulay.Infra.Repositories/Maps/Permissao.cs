using System.Data.Entity.ModelConfiguration;
using DKO.EQualy.Domain.Entities;

namespace DKO.EQulay.Infra.Repositories.Maps
{
    public class PermissaoMap : EntityTypeConfiguration<Permissao>
    {
        public PermissaoMap()
        {
            this.ToTable("Permissao");
            this.HasKey(p => p.Id);
            this.Property(p => p.Criar).IsRequired();
            this.Property(p => p.Editar).IsRequired();
            this.Property(p => p.Apagar).IsRequired();
            this.Property(p => p.Listar).IsRequired();

            this.HasMany(mm => mm.MenuItems)
                .WithMany(m => m.Permissao).Map(r => r.ToTable("PermissaoMenuImtem"));

        }    
    }
}