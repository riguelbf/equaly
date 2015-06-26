using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DKO.EQualy.Domain.Entities
{
    public class Atividade : Entities.EntityBase
    {
        public DateTime _dataCriacao;
        
        [DisplayName("Título")]
        public string Titulo { get; set; }
        
        [DisplayName("Data criação")]
        public DateTime DataCriacao
        {
            get { return DateTime.Now; }
            set { _dataCriacao = value; }
        }
        
        [DisplayName("Data conclusão")]
        public DateTime DataConclusao { get; set; }
        
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        public Usuario UsuarioCriou { get; set; }
        
        [DisplayName("Usuário Destino")]
        public int UsuarioDestinoId { get; set; }
        
        [DisplayName("Tipo")]
        public virtual Enum.Atividade.TipoAtividade Tipo { get; set; }
        
        [DisplayName("Status")]
        public virtual Enum.Atividade.StatusAtividade StatusAtividade { get; set; }

    }
}