using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DKO.EQualy.Domain.Entities;

namespace DKO.EQulay.Infra.Repositories.Maps
{
    public class AvaliacaoDocumentoMap : EntityTypeConfiguration<AvaliacaoDocumento>
    {
        public AvaliacaoDocumentoMap()
        {
            this.ToTable("AvaliacaoDocumento");
            this.HasKey(ad => ad.Id);
            this.Property(ad => ad.Aprovado).IsOptional();
            this.Property(ad => ad.DataCriacao).IsRequired();
            this.Property(ad => ad.Justificativa).HasMaxLength(500).IsOptional();
            this.HasRequired(ad => ad.Documento);
            this.HasRequired(ad => ad.UsuarioAvaliador);
        }
    }
}
