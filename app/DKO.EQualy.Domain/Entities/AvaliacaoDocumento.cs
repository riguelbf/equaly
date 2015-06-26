using System;

namespace DKO.EQualy.Domain.Entities
{
    public class AvaliacaoDocumento :Entities.EntityBase
    {
        public DateTime DataCriacao { get; set; }
        public Usuario UsuarioAvaliador { get; set; }
        public Documento Documento { get; set; }
        public string Justificativa { get; set; }
        public Boolean Aprovado { get; set; }
    }
}