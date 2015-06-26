using System;
using System.Threading.Tasks;

namespace DKO.EQualy.Domain.Entities
{
    public class AprovacaoDocumento : Entities.EntityBase
    {
        public Usuario UsuarioAprovador { get; set; }
        public Documento DocumentoParaAprovacao { get; set; }
        public bool Aprovado { get; set; }
        public string TipoAprovacao { get; set; }
        public DateTime Data { get; set; }
        public string JustificativaObservacao { get; set; }
    }
}