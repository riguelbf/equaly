using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.ModelConfiguration;
using DKO.EQualy.Domain.Entities;

namespace DKO.EQulay.Infra.Repositories.Maps
{
    public class NaoConformidadeMap : EntityTypeConfiguration<NaoConformidade>
    {
        public NaoConformidadeMap()
        {
            this.ToTable("NaoConformidade");
            this.HasKey(n => n.Id);
            this.Property(n => n.Codigo).HasMaxLength(50).IsRequired();

            this.HasOptional(n => n.Eficacia).WithOptionalPrincipal().WillCascadeOnDelete(true);
            this.HasMany(n => n.HistoricoRncs).WithOptional().Map(m => m.MapKey("HistoricoRncId")).WillCascadeOnDelete(true);
            this.HasOptional(n => n.Reclamativa).WithRequired(r => r.NaoConformidade).WillCascadeOnDelete(true);
            this.HasOptional(n => n.PlanoDeAcao).WithRequired(pa => pa.NaoConformidade).WillCascadeOnDelete(true);
            this.HasOptional(n => n.CausaRaiz).WithRequired(cr => cr.NaoConformidade).WillCascadeOnDelete(true);
        }
    }
}