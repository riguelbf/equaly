using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKO.EQualy.Domain.Entities
{
    public class Permissao : Entities.EntityBase
    {
        public Permissao()
        {
            this.MenuItems = new List<MenuItem>();
            this.Menus = new List<Menu>();
        }
        public bool Criar { get; set; }
        public bool Apagar { get; set; }
        public bool Editar { get; set; }
        public bool Listar { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<MenuItem> MenuItems { get; set; }
    }
}
