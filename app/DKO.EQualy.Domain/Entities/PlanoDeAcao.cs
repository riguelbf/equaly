using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DKO.EQualy.Domain.Entities
{
    public class PlanoDeAcao : Entities.EntityBase
    {
        public PlanoDeAcao()
        {
            this.Ferramenta5W2H = new List<Ferramenta5W2H>();
        }
        [DisplayName("Observações")]
        public String Observacao { get; set; }
        
        [DisplayName("Anexo de evidência")]
        public string NomeDocumentoEvidencia { get; set; }
        public DateTime DataConclusaoValidacao { get; set; }
        public virtual List<Ferramenta5W2H> Ferramenta5W2H { get; set; }
        public virtual NaoConformidade NaoConformidade { get; set; }
    }
}
