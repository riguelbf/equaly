using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DKO.EQualy.Domain.Entities
{
    public class Reclamativa : Entities.EntityBase
    {
        [DisplayName("Titulo da ocorrência")]
        public string Titulo { get; set; }
        [DisplayName("Nome do reclamante")]
        public String NomeReclamante { get; set; }
        [DisplayName("Email do reclamante")]
        public String EmailReclamante { get; set; }
        [DisplayName("Telefone contato")]
        public String TelefoneReclamante { get; set; }
        [DisplayName("Data de abertura")]
        public DateTime DataCriacao { get; set; }
        [DisplayName("Descrição")]
        public String DescricaoReclamacao { get; set; }
        [DisplayName("Numero pedido/Nf")]
        public String NumeroPedidoNf { get; set; }
        [DisplayName("Responsavel pela abertura")]
        public Usuario UsuarioCriou { get; set; }
        public virtual NaoConformidade NaoConformidade { get; set; }
    }
}
