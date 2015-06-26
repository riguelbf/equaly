using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DKO.EQualy.Domain.Entities
{
    public class CausaRaiz : Entities.EntityBase
    {
        public CausaRaiz()
        {
            this.CincoPorQues = new List<CincoPorQues>();
            this.UsuariosEnvolvidos = new List<Usuario>();
        }

        [DisplayName("Definição da causa raiz")]
        public string DescricaoDefinicao { get; set; }
        [DisplayName("Prazo conclusão")]
        public DateTime DataConclusao { get; set; }
        public virtual List<CincoPorQues> CincoPorQues { get; set; }
        [DisplayName("Equipe envolvida")]
        public virtual List<Usuario> UsuariosEnvolvidos { get; set; }
        public virtual NaoConformidade NaoConformidade { get; set; }
    }
}
