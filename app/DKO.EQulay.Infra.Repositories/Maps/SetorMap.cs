
using System.Data.Entity.ModelConfiguration;
using DKO.EQualy.Domain.Entities;

namespace DKO.EQulay.Infra.Repositories.Maps
{
    public class SetorMap : EntityTypeConfiguration<Setor>
    {
        public SetorMap()
        {
            this.ToTable("Setor");
            this.HasKey(s => s.Id);
            this.Property(s => s.Codigo).HasMaxLength(50).IsRequired();
            this.Property(s => s.Nome).HasMaxLength(50);
        }
    }
}