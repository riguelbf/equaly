using System.Data.Entity.ModelConfiguration;
using DKO.EQualy.Domain.Entities;

namespace DKO.EQulay.Infra.Repositories.Maps
{
    public class CincoPorQuesMap : EntityTypeConfiguration<CincoPorQues>
    {
        public CincoPorQuesMap()
        {
            this.ToTable("CincoPorQues");
            this.HasKey(c => c.Id);
            this.Property(c => c.Resposta).HasMaxLength(400);
            this.Property(c => c.Pergunta).HasMaxLength(400);
            this.HasOptional(c => c.UsuarioDestino).WithMany();
        }
    }
}