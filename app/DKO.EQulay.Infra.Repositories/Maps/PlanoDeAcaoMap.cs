using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DKO.EQualy.Domain.Entities;

namespace DKO.EQulay.Infra.Repositories.Maps
{
    public class PlanoDeAcaoMap : EntityTypeConfiguration<PlanoDeAcao>
    {
        public PlanoDeAcaoMap()
        {
            this.ToTable("PlanoDeAcao");
            this.HasKey(ac => ac.Id);
            this.Property(ac => ac.Observacao).HasMaxLength(400);
            this.HasMany(ac => ac.Ferramenta5W2H).WithMany().Map(af => af.ToTable("PlanoDeAcaoFerramenta5W2H"));
            this.Property(ac => ac.DataConclusaoValidacao).IsOptional();
            this.Property(ac => ac.NomeDocumentoEvidencia).IsOptional().HasMaxLength(150);

            //this.HasOptional(cr => cr.NaoConformidade).WithOptionalPrincipal() WithOptional().WillCascadeOnDelete(true);
        }
    }
}
