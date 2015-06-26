using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DKO.Equaly.DTO.NaoConformidade.Eficacia
{
    public class EficaciaDto
    {
        public EficaciaDto()
        {
            this.DataDeCriacao = DateTime.Now;
        }
        public int NaoConformidadeId { get; set; }
        public int EficaciaId { get; set; }
        
        [DisplayName("Data de cadastro")]
        public DateTime DataDeCriacao { get; set; }

        [DisplayName("Pontuação")]
        public decimal Pontuacao { get; set; }

        [DisplayName("Observação")]
        public string Observacao { get; set; }

        [DisplayName("Arquivos/Evidências")]
        public List<string> NomeArquivo { get; set; } //evidencias 
    }
}