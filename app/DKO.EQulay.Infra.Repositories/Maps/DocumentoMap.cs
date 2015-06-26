using System.Data.Entity.ModelConfiguration;
using DKO.EQualy.Domain.Entities;

namespace DKO.EQulay.Infra.Repositories.Maps
{
    public class DocumentoMap : EntityTypeConfiguration<Documento>
    {
        public DocumentoMap()
        {
            this.ToTable("Documento");
            this.HasKey(d => d.Id);
            this.Property(d => d.LocalDigital).HasMaxLength(150);
            this.Property(d => d.LocalFisico).HasMaxLength(150);
            this.Property(d => d.NumeroRevisao).HasMaxLength(50);
            this.Property(d => d.Observacao).HasMaxLength(500);
            this.Property(d => d.QtdNumeroCopia).IsRequired();
            this.Property(d => d.DataEmissao).IsRequired();
            this.Property(d => d.Ativo).IsRequired();
            this.Property(d => d.TipoDocumento).IsRequired();
            this.Property(d => d.TipoDeArmazenamento).IsOptional();
            this.Property(d => d.Titulo).HasMaxLength(150);
            this.Property(d => d.Ativo).IsRequired();
            this.Property(d => d.SendoRevisado).IsOptional();
            this.Property(d => d.NomeArquivo).HasMaxLength(100).IsOptional();
            this.Property(d => d.Validade).IsOptional();
            this.Property(d => d.DataPublicacao).IsOptional();

            this.HasRequired(d => d.SetorEnvolvido);
            this.HasRequired(d => d.UsuariosElaborador);
            this.HasRequired(d => d.UsuariosAprovador);
            this.HasRequired(d => d.UsuariosSolicitante);
            this.HasMany(d => d.UsuariosRevisores).WithMany().Map(ud => ud.ToTable("RevisoresDocumento"));
            this.HasMany(d => d.Aprovacoes).WithMany();
            this.HasMany(n => n.Historico).WithOptional().Map(m => m.MapKey("HistoricoDocId"));
        }
    }
}