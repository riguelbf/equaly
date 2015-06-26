using System;

namespace DKO.Equaly.Projection.NaoConformidade.PlanoDeAcao
{
    public class PlanoDeAcaoProjection
    {
        public int NaoConformidadeId { get; set; }
        public int Indice { get; set; }
        public int PlanoDeAcaoId { get; set; }
        public int UsuarioQuemId { get; set; }
        public string NomeQuem { get; set; }

        public String OQue { get; set; }

        public String PorQue { get; set; }

        public String Quando { get; set; }

        public String Onde { get; set; }

        public String Como { get; set; }

        public decimal QuantoCusta { get; set; }

        public int StatusId { get; set; }
        public string Status { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataConclusao { get; set; }

        public int TipoDePlanoDeAcaoId { get; set; }

        public string TipoDePlanoDeAcao { get; set; } 
    }
}