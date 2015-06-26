using System;
using System.ComponentModel;

namespace DKO.Equaly.DTO.NaoConformidade
{
    public class ReclamativaDto
    {
        public int Id { get; set; }
        public int NaoConformidadeId { get; set; }

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
        public int UsuarioCriouId { get; set; } 
    }
}