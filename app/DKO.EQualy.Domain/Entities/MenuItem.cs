using System;
using System.Collections.Generic;

namespace DKO.EQualy.Domain.Entities
{
    public class MenuItem : Entities.EntityBase
    {
        public MenuItem()
        {
            this.Permissao = new List<Permissao>();
        }
        public String Name { get; set; }
        public String ActionName { get; set; }
        public String ControllerName { get; set; }
        public String Url { get; set; }
        public String ClassIcon { get; set; }
        public int Order { get; set; }
        public virtual ICollection<Permissao> Permissao { get; set; }
    }
}