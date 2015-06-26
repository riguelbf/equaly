using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DKO.EQualy.Domain.Interfaces.Service;
using DKO.Equaly.DTO.Email;

namespace DKO.Equaly.Service.Concrete
{
    public class EmailService : ServiceBase, IEmailService
    {
        public void Enviar(EmailDto emailDto)
        {
            var template = PopulaTemplate(emailDto.Titulo, emailDto.DescricaoAtividade,
                emailDto.Data.ToLongDateString(), emailDto.Url, emailDto.Descricao);

            EnviarEmailTemplateFormatado(emailDto.EmailDestinatario,emailDto.DescricaoAtividade,template);
        }

        private static string PopulaTemplate(string titulo, string descricaoAtividade, string data, string url, string descricao)
        {
            string template;
            using (var reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/Templates/Email/htmlMail/default.html")))
            {
                template = reader.ReadToEnd();
            }

            template = template.Replace("{TituloAtividade}", descricaoAtividade);
            template = template.Replace("{Data}", data);
            template = template.Replace("{Titulo}", titulo);
            template = template.Replace("{Descricao}", descricao);
            template = template.Replace("{Url}", url);
            
            return template;
        }

        private static void EnviarEmailTemplateFormatado(string emailDestinatario, string assunto, string template)
        {
            using (var mensagemEmail = new MailMessage())
            {
                mensagemEmail.From = new MailAddress(ConfigurationManager.AppSettings["EmailSistemaEQualy"]);
                mensagemEmail.Subject = assunto;
                mensagemEmail.Body = template;
                mensagemEmail.IsBodyHtml = true;
                mensagemEmail.To.Add(new MailAddress(emailDestinatario));
                
                var smtp = new SmtpClient
                {
                    Host = ConfigurationManager.AppSettings["Host"],
                    EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"])
                };

                var networkCred = new System.Net.NetworkCredential
                {
                    UserName = ConfigurationManager.AppSettings["UserName"],
                    Password = ConfigurationManager.AppSettings["Password"]
                };

                smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkCred;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
                smtp.Send(mensagemEmail);
            }
        }
    }
}
