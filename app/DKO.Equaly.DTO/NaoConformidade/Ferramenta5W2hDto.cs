using System;
using System.ComponentModel;

namespace DKO.Equaly.DTO.NaoConformidade
{
    public class Ferramenta5W2HDto
    {
        public int Id { get; set; }
        [DisplayName("O quê ? (título)")]
        public String OQue { get; set; }
        [DisplayName("Por quê ? (justificativa)")]
        public String PorQue { get; set; }
        [DisplayName("Quem ? (responsável)")]
        public int Quem { get; set; }
        [DisplayName("Quando ? (inicio)")]
        public String Quando { get; set; }
        [DisplayName("Onde ? (local)")]
        public String Onde { get; set; }
        [DisplayName("Como ? (descrição)")]
        public String Como { get; set; }
        [DisplayName("Quanto custa ? (custo)")]
        public decimal QuantoCusta { get; set; }
        [DisplayName("Status ?")]
        public string Status { get; set; }
        [DisplayName("Data criação")]
        public DateTime DataCriacao { get; set; }
        [DisplayName("Prazo de conclusão ?")]
        public DateTime DataConclusao { get; set; }
        [DisplayName("Tipo")]
        public int TipoDePlanoDeAcao { get; set; }
    }
}