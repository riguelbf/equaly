using System;

namespace DKO.EQualy.Domain.Entities
{
    public class Historico : Entities.EntityBase
    {
        public DateTime DataCriacao { get; set; }
        public Usuario UsuarioCriou { get; set; }
        public string Decricao { get; set; }
        public virtual Enum.Historico.TipoHistorico Tipo { get; set; }
    }
}