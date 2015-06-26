using System.Data.Entity.ModelConfiguration;
using DKO.EQualy.Domain.Entities;

namespace DKO.EQulay.Infra.Repositories.Maps
{
    public class EficaciaMap : EntityTypeConfiguration<Eficacia>
    {
        public EficaciaMap()
        {
            this.ToTable("Eficacia");
            this.HasKey(e => e.Id);
            this.Property(e => e.Observacao).HasMaxLength(500).IsOptional();
            this.Property(e => e.DataDeCriacao).IsRequired();
            this.HasMany(e => e.NomeArquivo).WithOptional().Map(m => m.ToTable("EficaciaNomeArquivo"));
        } 
    }
}