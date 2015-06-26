using System.Data.Entity.ModelConfiguration;
using DKO.EQualy.Domain.Entities;

namespace DKO.EQulay.Infra.Repositories.Maps
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            this.ToTable("Usuario");
            this.HasKey(u => u.Id);
            this.Property(u => u.Matricula).HasMaxLength(50).IsRequired();
            this.Property(u => u.Nome).HasMaxLength(100).IsRequired();
            this.Property(u => u.NomeUsuario).HasMaxLength(100).IsRequired();
            this.Property(u => u.Senha).HasMaxLength(100).IsRequired();

            this.HasRequired(u => u.Setor);
            this.HasRequired(u => u.NivelAcesso);
        }
    }
}