using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;

namespace DKO.EQualy.Domain.Entities
{
    public class Documento : Entities.EntityBase
    {
        public Documento()
        {
            this.UsuariosRevisores = new List<Usuario>();
            this.Aprovacoes = new List<AprovacaoDocumento>();
            this.Historico = new List<Historico>();
        }
        [DisplayName("Codigo identificação")]
        public string CodigoIdentificacao { get; set; }
        [DisplayName("Título")]
        public string Titulo { get; set; }
        [DisplayName("Versão")]
        public string NumeroRevisao { get; set; }
        [DisplayName("Data Criação")]
        public DateTime DataEmissao { get; set; }
        [DisplayName("Local físico")]
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
        public virtual Enum.Documento.TipoDocumento TipoDocumento { get; set; }
        [DisplayName("Fase atual")]
        public virtual Enum.Documento.FaseDocumento FaseDocumento { get; set; }
        [DisplayName("Tipo de armazenamento")]
        public virtual Enum.Documento.TipoDeArmazenamento TipoDeArmazenamento { get; set; }
        [DisplayName("Revisore(s)")]
        public virtual ICollection<Usuario> UsuariosRevisores { get; set; }
        [DisplayName("Aprovações")]
        public virtual ICollection<AprovacaoDocumento> Aprovacoes { get; set; }
        [DisplayName("Aprovador")]
        public virtual Usuario UsuariosAprovador{ get; set; }
        [DisplayName("Elaborador do documento")]
        public virtual Usuario UsuariosElaborador { get; set; }
        [DisplayName("Solicitante")]
        public virtual Usuario UsuariosSolicitante { get; set; }
        [DisplayName("Setor")]
        public virtual Setor SetorEnvolvido { get; set; }
        public virtual List<Historico> Historico { get; set; }
        public string NomeArquivo { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public DateTime? Validade { get; set; }
        public bool CopiaControlada { get; set; }
    }
}
