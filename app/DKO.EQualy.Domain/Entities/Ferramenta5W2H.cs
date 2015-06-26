using System;
using System.IdentityModel.Protocols.WSTrust;

namespace DKO.EQualy.Domain.Entities
{
    public class Ferramenta5W2H : Entities.EntityBase
    {
        public String OQue { get; set; }
        public String PorQue { get; set; }
        public String Quem { get; set; }
        public String Quando { get; set; }
        public String Onde { get; set; }
        public String Como { get; set; }
        public decimal QuantoCusta { get; set; }
        public string Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataConclusao { get; set; }
        public Enum.NaoConformidade.TipoDePlanoDeAcao TipoDePlanoDeAcao { get; set; }
    }
}
