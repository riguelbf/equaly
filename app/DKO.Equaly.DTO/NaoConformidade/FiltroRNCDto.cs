using System;
using System.ComponentModel;

namespace DKO.Equaly.DTO.NaoConformidade
{
    public class FiltroRNCDto
    {
        [DisplayName("Data inicial")]
        public DateTime DataInicial { get; set; }
        [DisplayName("Data final")]
        public DateTime DataFinal { get; set; }
        [DisplayName("Usuario responsável")]
        public int UsuarioCriouId { get; set; }
        [DisplayName("Setor responsável")]
        public int SetorResponsavelId { get; set; }
        [DisplayName("Status")]
        public string Status { get; set; }
        [DisplayName("Nome do reclamante")]
        public string NomeReclamante { get; set; }
    }
}