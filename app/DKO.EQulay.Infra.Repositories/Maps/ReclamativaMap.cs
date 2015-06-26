using System.Data.Entity.ModelConfiguration;
using DKO.EQualy.Domain.Entities;

namespace DKO.EQulay.Infra.Repositories.Maps
{
    public class ReclamativaMap : EntityTypeConfiguration<Reclamativa>
    {
        public ReclamativaMap()
        {
            this.ToTable("Reclamativa");
            this.HasKey(r => r.Id);
            this.Property(r => r.DescricaoReclamacao).HasMaxLength(500).IsRequired();
            this.Property(r => r.EmailReclamante).HasMaxLength(100);
            this.Property(r => r.NomeReclamante).HasMaxLength(150);
            this.Property(r => r.NumeroPedidoNf).HasMaxLength(50);
            this.Property(r => r.TelefoneReclamante).HasMaxLength(20);
            this.Property(r => r.Titulo).HasMaxLength(150);

           // this.HasRequired(cr => cr.NaoConformidade).WithOptional().WillCascadeOnDelete(true);
        }
    }
}