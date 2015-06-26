using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using DKO.EQualy.Domain.Entities;

namespace DKO.EQulay.Infra.Repositories.Maps
{
    public class AtividadeMap : EntityTypeConfiguration<Atividade>
    {
        public AtividadeMap()
        {
            this.ToTable("Atividade");
            this.HasKey(m => m.Id);
            this.Property(a => a.DataCriacao).IsRequired();
            this.Property(a => a.DataConclusao).IsOptional();
            this.Property(a => a.Descricao).HasMaxLength(500).IsRequired();
            this.Property(a => a.StatusAtividade).IsRequired();
            this.Property(a => a.Titulo).IsRequired();
            this.Property(a => a.Tipo).IsRequired();
            this.Property(a => a.UsuarioDestinoId).IsRequired();
            
            this.HasRequired(a => a.UsuarioCriou).WithMany();
        }
    }
}