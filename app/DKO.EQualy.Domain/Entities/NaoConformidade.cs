using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace DKO.EQualy.Domain.Entities
{
    public class NaoConformidade : Entities.EntityBase
    {
        public NaoConformidade()
        {
            this.HistoricoRncs = new List<Historico>();
        }

        public decimal ValorNaoQualidade { get; set; }
        public DateTime DataCriacao { get; set; }
        public String Codigo { get; set; }
        public Usuario UsuarioResponsavel { get; set; }
        public virtual List<Historico> HistoricoRncs { get; set; }
        public virtual Eficacia Eficacia { get; set; }
        public virtual Reclamativa Reclamativa { get; set; }
        public virtual CausaRaiz CausaRaiz { get; set; }
        public virtual PlanoDeAcao PlanoDeAcao { get; set; }
    }
}
