using System;
using System.ComponentModel;

namespace DKO.Equaly.DTO.Documentos
{
    public class FiltroDocumentosDto
    {
        [DisplayName("Titulo")]
        public string Titulo { get; set; }
        [DisplayName("Fase")]
        public int FaseDocumento { get; set; }
        [DisplayName("Data criação")]
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        [DisplayName("Setor")]
        public int SetorId { get; set; }
        [DisplayName("Status")]
        public bool Ativo { get; set; }
    }
}