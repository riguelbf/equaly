using System;

namespace DKO.EQualy.Domain.Entities
{
    public class CincoPorQues :Entities.EntityBase
    {
        public String Resposta { get; set; }
        public String Pergunta { get; set; }
        public Usuario UsuarioDestino { get; set; }
    }
}
