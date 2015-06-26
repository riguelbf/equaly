using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace DKO.EQualy.Domain.Entities
{
    public class Menu : Entities.EntityBase
    {
        public Menu()
        {
            this.MenuItems = new List<MenuItem>();
            this.NiveisAcesso = new List<NivelAcesso>();
        }

        public String Name { get; set; }
        public String ClassIcon { get; set; }
        public int Order { get; set; }
        public String Action { get; set; }
        public String Controller { get; set; }
        public virtual ICollection<MenuItem> MenuItems { get; set; }
        public virtual ICollection<NivelAcesso> NiveisAcesso { get; set; }
    }
}
