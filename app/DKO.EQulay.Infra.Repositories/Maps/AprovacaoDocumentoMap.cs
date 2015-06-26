using System.Data.Entity.ModelConfiguration;
using DKO.EQualy.Domain.Entities;

namespace DKO.EQulay.Infra.Repositories.Maps
{
    public class AprovacaoDocumentoMap : EntityTypeConfiguration<AprovacaoDocumento>
    {
        public AprovacaoDocumentoMap()
        {
            this.ToTable("AprovacaoDocumento");
            this.HasKey(ad => ad.Id);
            this.Property(ad => ad.Data).IsOptional();
            this.Property(ad => ad.Aprovado).IsOptional();
            this.Property(ad => ad.TipoAprovacao).HasMaxLength(2).IsOptional();
            this.Property(ad => ad.JustificativaObservacao).HasMaxLength(500).IsOptional();

            this.HasRequired(ad => ad.UsuarioAprovador);
            this.HasRequired(ad => ad.DocumentoParaAprovacao);
        }
    }
}