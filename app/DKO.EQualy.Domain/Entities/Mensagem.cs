using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DKO.EQualy.Domain.Entities
{
    public class Mensagem : Entities.EntityBase
    {
        [Required]
        [DisplayName("Título")]
        public string Titulo { get; set; }
        [Required]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public Usuario UsuarioCriou { get; set; }
        [Required]
        [DisplayName("Usuário Destino")]
        public int UsuarioDestinoId { get; set; } 
    }
}