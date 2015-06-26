using System.Data.Entity.ModelConfiguration;
using DKO.EQualy.Domain.Entities;

namespace DKO.EQulay.Infra.Repositories.Maps
{
    public class CausaRaizMap : EntityTypeConfiguration<CausaRaiz>
    {
        public CausaRaizMap()
        {
            this.ToTable("CausaRaiz");
            this.HasKey(cr => cr.Id);
            this.HasMany(cr => cr.UsuariosEnvolvidos).WithMany().Map(af => af.ToTable("CausaRaizUsuario"));
            this.HasMany(cr => cr.CincoPorQues);

           // this.HasRequired(cr => cr.NaoConformidade).WithOptional().WillCascadeOnDelete(true);
        }
    }
}