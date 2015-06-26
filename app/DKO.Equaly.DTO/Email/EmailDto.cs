using System;
using System.Web.Configuration;

namespace DKO.Equaly.DTO.Email
{
    public class EmailDto
    {
        public EmailDto()
        {
            this.Url = WebConfigurationManager.AppSettings["urlDoSistema"];
        }
        public string Titulo { get; set; }
        public DateTime Data { get; set; }
        public string EmailDestinatario { get; set; }
        public string ComCopia { get; set; }
        public string Descricao { get; set; }
        public string DescricaoAtividade { get; set; }
        public string Url { get; set; }
        public string Assunto { get; set; }
    }
}