using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace DKO.EQualy.Domain.Entities
{
    public class Usuario : Entities.EntityBase
    {
        public String Nome { get; set; }
        public String NomeUsuario { get; set; }
        public String Matricula { get; set; }
        public String Senha { get; set; }
        public String Email { get; set; }
        public String UrlFotoPerfil { get; set; }
        public virtual Setor Setor { get; set; }
        public virtual NivelAcesso NivelAcesso { get; set; }
    }
}
