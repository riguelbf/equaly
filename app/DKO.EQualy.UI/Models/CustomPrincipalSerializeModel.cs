using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DKO.EQualy.UI.Models
{
    public class CustomPrincipalSerializeModel
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Roles { get; set; }
    }
}