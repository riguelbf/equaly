using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using DKO.EQualy.Domain.Entities;

namespace DKO.Equaly.DTO.Usuario
{
    public class PerfilDto 
    {
        public PerfilDto()
        {
            this.Atividades = new List<Atividade>();
            this.Mensagens = new List<Mensagem>();
        }

        [Required]
        [DisplayName("Senha")]
        [StringLength(100, ErrorMessage = "100 caracteres permitido")]
        public string Senha { get; set; }

        [Required]
        [DisplayName("Nova Senha")]
        [StringLength(100, ErrorMessage = "100 caracteres permitido")]
        public string NovaSenha { get; set; }

        [Required]
        [DisplayName("Confirme a nova senha")]
        [StringLength(100, ErrorMessage = "100 caracteres permitido")]
        public string ConfirmaSenha { get; set; }
        public HttpPostedFileBase Arquivo { get; set; }
        public EQualy.Domain.Entities.Usuario Usuario { get; set; }
        public List<Atividade> Atividades { get; set; }
        public List<Mensagem> Mensagens { get; set; }
    }
}