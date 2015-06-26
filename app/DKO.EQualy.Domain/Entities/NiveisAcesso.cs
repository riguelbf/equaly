using System;
using System.Collections.Generic;

namespace DKO.EQualy.Domain.Entities
{
    public class NivelAcesso : Entities.EntityBase
    {
        public NivelAcesso()
        {
            this.Menu = new List<Menu>();
        }

        public String Tipo { get; set; }
        public Boolean Ativo { get; set; }
        public virtual ICollection<Menu> Menu{ get; set; }
    }
}
