using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using DKO.EQualy.Domain.Entities;

namespace DKO.Equaly.DTO.Documentos
{
    public class SolicitacaoDocumentoDto
    {
        private const string _ErrorMessage = "Campo obrigatório";

        public SolicitacaoDocumentoDto()
        {
            this.Historico = new List<Historico>();
        }
        public int Id { get; set; }
        [DisplayName("Codigo identificação")]
        public string CodigoIdentificacao { get; set; }

        [DisplayName("Título")]
        public string Titulo { get; set; }
        
        [DisplayName("Versão")]
        public string NumeroRevisao { get; set; }
        
        [DisplayName("Data Criação")]
        public DateTime DataEmissao { get; set; }
       
        public string LocalFisico { get; set; }
       
        [DisplayName("Local digital")]
        public string LocalDigital { get; set; }
        
        [DisplayName("Qtd. Cópias permitidas")]
        public int QtdNumeroCopia { get; set; }

        [DisplayName("Observação")]
        public string Observacao { get; set; }
        
        [DisplayName("Revisado")]
        public bool SendoRevisado { get; set; }
       
        [DisplayName("Ativo")]
        public bool Ativo { get; set; }

        [DisplayName("Tipo de documento")]
        public int TipoDocumento { get; set; }
        
        [DisplayName("Fase atual")]
        public int FaseDocumento { get; set; }

        [DisplayName("Tipo de armazenamento")]
        public int TipoDeArmazenamento { get; set; }
        
        [DisplayName("Revisore(s)")]
        public virtual ICollection<int> UsuariosRevisores { get; set; }

        [DisplayName("Histórico")]
        public virtual ICollection<EQualy.Domain.Entities.Historico> Historico { get; set; }
        
        [DisplayName("Aprovações")]
        public int AprovacaoId { get; set; }
        
        [DisplayName("Aprovador")]
        public int UsuariosAprovadorId { get; set; }
        
        [DisplayName("Elaborador do documento")]
        public int UsuariosElaboradorId { get; set; }

        [DisplayName("Solicitante do documento")]
        public int UsuariosSolicitanteId { get; set; }

        [DisplayName("Setor")]
        public int SetorID { get; set; }

        [DisplayName("Selecione um arquivo")]
        public HttpPostedFileBase Arquivo { get; set; }
        public string JustificativaReprovacao { get; set; }
        
        [DisplayName("Data publicação")]
        public DateTime DataDePublicacao { get; set; }
        
        [DisplayName("Data validade")]
        public DateTime Validade { get; set; }
        public bool CopiaControlada { get; set; }
    }
}