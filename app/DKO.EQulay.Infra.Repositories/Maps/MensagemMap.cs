using System.Data.Entity.ModelConfiguration;
using DKO.EQualy.Domain.Entities;

namespace DKO.EQulay.Infra.Repositories.Maps
{
    public class MensagemMap : EntityTypeConfiguration<Mensagem>
    {
        public MensagemMap()
        {
            this.HasKey(m => m.Id);
            this.ToTable("Mensagem");
            this.Property(m => m.Titulo).HasMaxLength(250).IsRequired();
            this.Property(m => m.Descricao).HasMaxLength(550).IsRequired();
            this.Property(m => m.UsuarioDestinoId).IsRequired();
            this.Property(m => m.DataCriacao).IsRequired();
            
            this.HasRequired(m => m.UsuarioCriou).WithMany();
        } 
    }
}