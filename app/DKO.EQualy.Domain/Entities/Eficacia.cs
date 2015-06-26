using System;
using System.Collections.Generic;

namespace DKO.EQualy.Domain.Entities
{
    public class Eficacia : EntityBase
    {
        public Eficacia()
        {
            this.NomeArquivo = new List<string>();
        }

        public DateTime DataDeCriacao { get; set; }
        public decimal Pontuacao { get; set; }
        public string Observacao { get; set; }
        public List<string> NomeArquivo { get; set; } //evidencias
    }
}