using System.Data.Entity.ModelConfiguration;
using DKO.EQualy.Domain.Entities;

namespace DKO.EQulay.Infra.Repositories.Maps
{
    public class Ferramenta5W2HMap : EntityTypeConfiguration<Ferramenta5W2H>
    {
        public Ferramenta5W2HMap()
        {
            this.ToTable("Ferramenta5W2H");
            this.HasKey(f => f.Id);
            this.Property(f => f.OQue).HasMaxLength(500);
            this.Property(f => f.Onde).HasMaxLength(500);
            this.Property(f => f.PorQue).HasMaxLength(500);
            this.Property(f => f.Quando).HasMaxLength(500);
            this.Property(f => f.QuantoCusta).HasPrecision(18,2);
            this.Property(f => f.Quem).HasMaxLength(500);
            this.Property(f => f.Status).HasMaxLength(1).IsRequired();
        }
    }
}