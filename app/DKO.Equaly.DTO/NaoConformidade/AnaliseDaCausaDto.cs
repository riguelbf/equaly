using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DKO.Equaly.Projection.NaoConformidade.AnaliseDaCausa;

namespace DKO.Equaly.DTO.NaoConformidade
{
    [Serializable]
    public class AnaliseDaCausaDto
    {
        public AnaliseDaCausaDto()
        {
            this.EquipeEnvolvidaDisponivel = new List<EquipeEnvolvidaProjection>();
            this.EquipeEnvolvidaSelecionada = new List<EquipeEnvolvidaProjection>();
            this.CincoPorQue = new List<CincoPorQueProjection>();
        }
        public int CausaRaizId { get; set; }
        public int NaoConformidadeId { get; set; }
        
        [DisplayName("Data de conclusão")]
        public DateTime DataConclusao { get; set; }

        [DisplayName("Definição da causa raiz")]
        public string DefinicaoDaCausaRaiz { get; set; }
        public IEnumerable<CincoPorQueProjection> CincoPorQue { get; set; }
        public IEnumerable<EquipeEnvolvidaProjection> EquipeEnvolvidaSelecionada { get; set; }
        public IEnumerable<EquipeEnvolvidaProjection> EquipeEnvolvidaDisponivel { get; set; }

        public string TesteComArray { get; set; }
    }
}