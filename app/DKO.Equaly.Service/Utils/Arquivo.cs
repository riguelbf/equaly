using System;
using System.IO;
using System.Web;

namespace DKO.Equaly.Service.Utils
{
    public class Arquivo
    {
        public Boolean SalvarArquivo(HttpPostedFileBase arquivo)
        {
            var isUploaded = false;
            var message = "File upload failed";

            if (arquivo == null || arquivo.ContentLength == 0) return false;
           // string diretorioDestino = Server.MapPath("~/Content/images/imagesPerfil");
            string diretorioDestino = "";
            try
            {
                arquivo.SaveAs(Path.Combine(diretorioDestino, arquivo.FileName));
                isUploaded = true;
                message = "File uploaded successfully!";
            }
            catch (Exception ex)
            {
                message = string.Format("File upload failed: {0}", ex.Message);
            }

            return true;
        }
    }
}