using System.Data.Entity.ModelConfiguration;
using DKO.EQualy.Domain.Entities;

namespace DKO.EQulay.Infra.Repositories.Maps
{
    public class NiveisAcessoMap : EntityTypeConfiguration<NivelAcesso>
    {
        public NiveisAcessoMap()
        {
            this.ToTable("NiveisAcesso");
            this.HasKey(na => na.Id);
            this.Property(na => na.Ativo).IsRequired();
            this.Property(na => na.Tipo).HasMaxLength(50);
            this.HasMany(na => na.Menu);
            this.HasMany(u => u.Menu)
               .WithMany(d => d.NiveisAcesso)
               .Map(nm => nm.ToTable("NiveisAcessoMenu"));
        }
    }
}