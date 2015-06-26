using System;
using System.IO;
using System.Web;
using DKO.EQualy.Domain.Enum;
using DKO.EQualy.Domain.Interfaces.Repository;
using DKO.EQualy.Domain.Interfaces.Service;
using DKO.Equaly.DTO.Documentos;
using Microsoft.Win32;
using DKO.EQualy.Domain.Enum;

namespace DKO.Equaly.Service.Concrete
{
    public class ArquivoService : ServiceBase, IArquivoService
    {
        private readonly IDocumentoRepository _documentoRepository;

        public ArquivoService(IDocumentoRepository documentoRepository)
        {
            this._documentoRepository = documentoRepository;
        }

        public Arquivo.Tipo ObterTipoArquivo(string nomeArquivo)
        {
            switch (Path.GetExtension(nomeArquivo).ToLower())
            {
                case ".pdf":
                    return Arquivo.Tipo.PDF;

                case ".doc":
                    return Arquivo.Tipo.Word;

                case ".docx":
                    return Arquivo.Tipo.Word;

                case ".xls":
                    return Arquivo.Tipo.Excel;

                case ".xlsx":
                    return Arquivo.Tipo.Excel;

                default:
                    return Arquivo.Tipo.Outro;
            }
        }

        public string SalvarArquivoDocumento(HttpPostedFileBase arquivo
                                            , DKO.EQualy.Domain.Enum.Documento.FaseDocumento? faseDocumento, int documentoId)
        {
            var isUploaded = false;
            var message = string.Empty;
            var codigoNomeArquivo = string.Empty;

            if (arquivo == null || arquivo.ContentLength == 0) return string.Empty;
            var diretorioDestino = ObterDiretorioDestino(ObterTipoArquivo(arquivo.FileName));

            if (faseDocumento != null)
                codigoNomeArquivo = ObterCodigoNome(faseDocumento);

            try
            {
                arquivo.SaveAs(Path.Combine(diretorioDestino, (codigoNomeArquivo + "_" + documentoId + "_" + arquivo.FileName).Trim()));
                message = "";
            }
            catch (Exception ex)
            {
                message = string.Format("Erro ao tentar salvar o arquivo: {0}", ex.Message);
            }

            return message;
        }

        public string ObterCodigoNome(DKO.EQualy.Domain.Enum.Documento.FaseDocumento? faseDocumento)
        {
            switch (faseDocumento)
            {
                case DKO.EQualy.Domain.Enum.Documento.FaseDocumento.Elaboracao:
                    return "EDOC";

                case DKO.EQualy.Domain.Enum.Documento.FaseDocumento.Revisao:
                    return "RDOC";

                default:
                    return string.Empty;
            }
        }

        public string ObterDiretorioDestino(Arquivo.Tipo tipoArquivo)
        {
            switch (tipoArquivo)
            {
                case Arquivo.Tipo.Excel:
                    return HttpContext.Current.Server.MapPath("~/Content/arquivos/excel");

                case Arquivo.Tipo.Fisico:
                    return "";

                case Arquivo.Tipo.FotoUsuario:
                    return "";

                case Arquivo.Tipo.PDF:
                    return "";

                case Arquivo.Tipo.TXT:
                    return HttpContext.Current.Server.MapPath("~/Content/arquivos/txt");

                case Arquivo.Tipo.Word:
                    return HttpContext.Current.Server.MapPath("~/Content/arquivos/word");

                default:
                    return HttpContext.Current.Server.MapPath("~/Content/arquivos/outro");
            }
        }

        public DadosDownloadDto ObterDadosDownload(int documentoId)
        {
            var documento = _documentoRepository.Get(documentoId);

            var diretorio = this.ObterDiretorioDestino(ObterTipoArquivo(documento.NomeArquivo));

            return new DadosDownloadDto
            {
                CaminhoFisico = diretorio,
                ContentType = this.ObterContentType(documento.NomeArquivo),
                NomeCompletoArquivo = MontaNomeDocumentoPorFase(documento)
            };
        }

        public string MontaNomeDocumentoPorFase(EQualy.Domain.Entities.Documento documento)
        {
            switch (documento.FaseDocumento)
            {
                case DKO.EQualy.Domain.Enum.Documento.FaseDocumento.Revisao:
                    return "E" + documento.CodigoIdentificacao + "_" + documento.Id + "_" + documento.NomeArquivo;

                case DKO.EQualy.Domain.Enum.Documento.FaseDocumento.Aprovacao:
                    return "R" + documento.CodigoIdentificacao + "_" + documento.Id + "_" + documento.NomeArquivo.Substring(8);
                
                default :
                    return "P" + documento.CodigoIdentificacao + "_" + documento.Id + "_" + documento.NomeArquivo.Substring(8);
            }
        }

        public string ObterContentType(string fileName)
        {
            var extension = Path.GetExtension(fileName);

            if (String.IsNullOrWhiteSpace(extension))
            {
                return null;
            }

            var registryKey = Registry.ClassesRoot.OpenSubKey(extension);

            if (registryKey == null)
            {
                return null;
            }

            var value = registryKey.GetValue("Content Type") as string;

            return String.IsNullOrWhiteSpace(value) ? null : value;
        }

        public void DownloadArquivo(DadosDownloadDto dadosDownloadDto)
        {
           
            #region [ old ] 
            
            /*
             *  //Create a stream for the file
            Stream stream = null;

            //This controls how many bytes to read at a time and send to the client
            int bytesToRead = 10000;

            // Buffer to read bytes in chunk size specified above
            byte[] buffer = new Byte[bytesToRead];

            // The number of bytes read
            try
            {
                //Create a WebRequest to get the file
                HttpWebRequest fileReq = (HttpWebRequest)HttpWebRequest.Create(dadosDownloadDto.CaminhoFisico);

                //Create a response for this request
                HttpWebResponse fileResp = (HttpWebResponse)fileReq.GetResponse();

                if (fileReq.ContentLength > 0)
                    fileResp.ContentLength = fileReq.ContentLength;

                //Get the Stream returned from the response
                stream = fileResp.GetResponseStream();

                // prepare the response to the client. resp is the client Response
                var resp = HttpContext.Current.Response;

                //Indicate the type of data being sent
                resp.ContentType = "application/octet-stream";

                //Name the file 
                resp.AddHeader("Content-Disposition", "attachment; filename=\"" + dadosDownloadDto.NomeCompletoArquivo + "\"");
                resp.AddHeader("Content-Length", fileResp.ContentLength.ToString());

                int length;
                do
                {
                    // Verify that the client is connected.
                    if (resp.IsClientConnected)
                    {
                        // Read data into the buffer.
                        length = stream.Read(buffer, 0, bytesToRead);

                        // and write it out to the response's output stream
                        resp.OutputStream.Write(buffer, 0, length);

                        // Flush the data
                        resp.Flush();

                        //Clear the buffer
                        buffer = new Byte[bytesToRead];
                    }
                    else
                    {
                        // cancel the download if client has disconnected
                        length = -1;
                    }
                } while (length > 0); //Repeat until no data is read
            }
            finally
            {
                if (stream != null)
                {
                    //Close the input stream
                    stream.Close();
                }
            }
             */

            #endregion
        }

        public void AtualizaNomeDoArquivoFisico(EQualy.Domain.Entities.Documento documento)
        {
            var diretorio = ObterDiretorioDestino(ObterTipoArquivo(documento.NomeArquivo));
            var nomeCompletoArquivoAtual = System.IO.Path.Combine(diretorio, MontaNomeDocumentoPorFase(documento));
            documento.FaseDocumento = this.ObterProximaFase(documento.FaseDocumento);
            
            var nomeCompletoArquivoNovo = System.IO.Path.Combine(diretorio, MontaNomeDocumentoPorFase(documento));
            documento.NomeArquivo = MontaNomeDocumentoPorFase(documento);
            System.IO.File.Copy(nomeCompletoArquivoAtual, nomeCompletoArquivoNovo, true);
            System.IO.File.Delete(nomeCompletoArquivoAtual);
        }

        public EQualy.Domain.Enum.Documento.FaseDocumento ObterProximaFase(EQualy.Domain.Enum.Documento.FaseDocumento faseDocumento)
        {
            switch (faseDocumento)
            {
                case EQualy.Domain.Enum.Documento.FaseDocumento.Elaboracao:
                    return EQualy.Domain.Enum.Documento.FaseDocumento.Revisao;
                case EQualy.Domain.Enum.Documento.FaseDocumento.Revisao:
                    return EQualy.Domain.Enum.Documento.FaseDocumento.Aprovacao;
                case EQualy.Domain.Enum.Documento.FaseDocumento.Aprovacao:
                    return EQualy.Domain.Enum.Documento.FaseDocumento.Publicacao;
                default:
                    return EQualy.Domain.Enum.Documento.FaseDocumento.Disponibilizado;
            }
        }
    }
}