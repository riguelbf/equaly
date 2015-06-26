using System.Data.Entity.ModelConfiguration;
using DKO.EQualy.Domain.Entities;

namespace DKO.EQulay.Infra.Repositories.Maps
{
    public class HistoricoMap : EntityTypeConfiguration<Historico>
    {
        public HistoricoMap()
        {
            this.ToTable("Historico");
            this.HasKey(h => h.Id);
            this.Property(h => h.DataCriacao).IsRequired();
            this.Property(h => h.Tipo).IsOptional();
            this.Property(h => h.Decricao).HasMaxLength(500).IsRequired();
            this.HasRequired(h => h.UsuarioCriou);
        }
    }
}