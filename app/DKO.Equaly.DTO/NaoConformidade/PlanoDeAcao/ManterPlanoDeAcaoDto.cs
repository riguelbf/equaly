using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DKO.EQualy.Domain.Entities;

namespace DKO.Equaly.DTO.NaoConformidade.PlanoDeAcao
{
    public class ManterPlanoDeAcaoDto
    {
        public int Indice { get; set; }
        public int PlanoDeAcaoId { get; set; }
        public int UsuarioResponsavelId { get; set; }
        
        [DisplayName("O quê?")]
        public String OQue { get; set; }

        [DisplayName("Por quê?")]
        public String PorQue { get; set; }

        [DisplayName("Quem?")]
        public String Quem { get; set; }

        [DisplayName("Quando?")]
        public String Quando { get; set; }

        [DisplayName("Onde?")]
        public String Onde { get; set; }

        [DisplayName("Como?")]
        public String Como { get; set; }

        [DisplayName("Quanto custa(R$)?")]
        public decimal QuantoCusta { get; set; }

        [DisplayName("Status")]
        public string Status { get; set; }

        [DisplayName("Data de cadastro")]
        public DateTime DataCadastro { get; set; }

        [DisplayName("Data de cadastro")]
        public DateTime DataConclusao { get; set; }

        public int TipoDePlanoDeAcaoValor { get; set; }

        [DisplayName("Tipo da ação")]
        public string TipoDePlanoDeAcao { get; set; }
    }
}