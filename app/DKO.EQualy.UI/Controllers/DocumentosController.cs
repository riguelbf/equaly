using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DKO.EQualy.Domain.Interfaces.Service;
using DKO.Equaly.DTO.Documentos;
using DKO.Equaly.Projection.Documentos;
using DKO.Equaly.Service.Security;

namespace DKO.EQualy.UI.Controllers
{
    public class DocumentosController : BaseController
    {
        private readonly ISetorService _setorService;
        private readonly IDocumentoService _documentosService;
        private readonly IUsuarioService _usuarioService;
        private readonly IArquivoService _arquivoService;

        #region [ Geral ]

        public DocumentosController(ISetorService setorService, IDocumentoService documentosService, IUsuarioService usuarioService, IArquivoService arquivoService)
        {
            this._setorService = setorService;
            this._documentosService = documentosService;
            this._usuarioService = usuarioService;
            this._arquivoService = arquivoService;

            ViewBag.Usuarios = _usuarioService.ObterUsuarios().OrderBy(u => u.Nome).ToList();
            ViewBag.Setores = _setorService.ObterSetores().OrderBy(s => s.Nome).ToList();
            ViewBag.DadosTabelas = new DocumentosProjection();
        }
        
        public ActionResult GerenciarDocumentos()
        {
            ViewBag.Setores = _setorService.ObterSetores();
            return View("Documentos");
        }

        [HttpPost]
        public ActionResult ObterDocumentos(FiltroDocumentosDto filtroDocumentosDto)
        {
            var documentos = _documentosService.ObterDocumentos(filtroDocumentosDto);
            return PartialView("_TabelasDocumentos", documentos);
        }

        public ActionResult NovoDocumento()
        {

            var solicitacaoDoc = new SolicitacaoDocumentoDto()
            {
                NumeroRevisao = "Documento sem versão",
                DataEmissao = DateTime.Now.Date
            };
            return PartialView("_ManterDocumento", solicitacaoDoc);
        }

        public ActionResult EditarDocumento(int documentoId)
        {
            var documento = _documentosService.ObterSolicitacaoDocumentoPorId(documentoId);
            var solicitacaoDoc = new SolicitacaoDocumentoDto()
            {
                NumeroRevisao = documento.NumeroRevisao,
                DataEmissao = documento.DataEmissao,
                Observacao = documento.Observacao,
                Titulo = documento.Titulo,
                Ativo = documento.Ativo,
                Historico = documento.Historico,
                Arquivo = documento.Arquivo,
                AprovacaoId = documento.AprovacaoId,
                LocalDigital = documento.LocalDigital,
                CodigoIdentificacao = documento.CodigoIdentificacao,
                FaseDocumento = documento.FaseDocumento,
                LocalFisico = documento.LocalFisico,
                Id = documento.Id,
                QtdNumeroCopia = documento.QtdNumeroCopia,
                SendoRevisado = documento.SendoRevisado,
                SetorID = documento.SetorID,
                TipoDocumento = documento.TipoDocumento,
                UsuariosAprovadorId = documento.UsuariosAprovadorId,
                UsuariosRevisores = documento.UsuariosRevisores,
                TipoDeArmazenamento = documento.TipoDeArmazenamento,
                UsuariosElaboradorId = documento.UsuariosElaboradorId,
                UsuariosSolicitanteId = documento.UsuariosSolicitanteId

            };

            return PartialView("_ManterDocumento", solicitacaoDoc);
        }

        public ActionResult ExcluirDocumento(int documentoId)
        {
            try
            {
                _documentosService.ExcluirDocumento(documentoId);
                return Json("Documento excluido com sucesso!", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }

        public ActionResult DownloadDocDisponivel(int documentoId)
        {
            try
            {
                var arquivo = _arquivoService.ObterDadosDownload(documentoId);
                var caminhoArquivo = string.Concat(arquivo.CaminhoFisico, "\\", arquivo.NomeCompletoArquivo);
                var fileBytes = System.IO.File.ReadAllBytes(caminhoArquivo);
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, arquivo.NomeCompletoArquivo);
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }

        #endregion

        #region [ Execução das fases ]

        #region [ Fase 1 ]

        public ActionResult ExecucaoFase1(SolicitacaoDocumentoDto solicitacaoDocumentoDto)
        {
            try
            {
                solicitacaoDocumentoDto.UsuariosSolicitanteId = CustomPrincipal.UsuarioId;
                _documentosService.RegistrarSolicitacaoDocumento(solicitacaoDocumentoDto);
                return Json("Documento / Registro solicitado com sucesso.");
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }

        #endregion

        #region [ Fase 2 ]

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ExecucaoFase2(FormCollection form)
        {
            try
            {
                var postedFile = Request.Files["PostedFile"];
                if (postedFile == null) throw new Exception();

                _documentosService.RegistraSolicitacaoDeRevisão(Convert.ToInt32(form[0]),postedFile);
                
                ViewBag.MensagemFase2 = "Success";

                return Json("Solicitação de revisão realizada com sucesso.");
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }

        #endregion

        #region [ Fase 3 ]

        public FileResult ExecucaoFase3DownloadDocumento(int documentoId)
        {
            try
            {
                var arquivo = _arquivoService.ObterDadosDownload(documentoId);
                var caminhoArquivo = string.Concat(arquivo.CaminhoFisico, "\\", arquivo.NomeCompletoArquivo);
                var fileBytes = System.IO.File.ReadAllBytes(caminhoArquivo);
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, arquivo.NomeCompletoArquivo);
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }
        public ActionResult ExecucaoFase3AprovacaoDocumento(SolicitacaoDocumentoDto solicitacaoDocumentoDto)
        {
            try
            {
                _documentosService.RegistrarAprovacaoDeRevisao(solicitacaoDocumentoDto);
                return Json("Aprovação de documento realizada com sucesso.");
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }
        public ActionResult ExecucaoFase3ReprovacaoDocumento(SolicitacaoDocumentoDto solicitacaoDocumentoDto)
        {
            try
            {
                _documentosService.RegistrarReprovacaoDeRevisao(solicitacaoDocumentoDto);
                return Json("Reprovação de documento realizada com sucesso.");
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }

        #endregion

        #region [ Fase 4 ]

        public FileResult ExecucaoFase4DownloadDocumento(int documentoId)
        {
            try
            {
                var arquivo = _arquivoService.ObterDadosDownload(documentoId);
                var caminhoArquivo = string.Concat(arquivo.CaminhoFisico, "\\", arquivo.NomeCompletoArquivo);
                var fileBytes = System.IO.File.ReadAllBytes(caminhoArquivo);
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, arquivo.NomeCompletoArquivo);
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }
        public ActionResult ExecucaoFase4AprovacaoDocumento(SolicitacaoDocumentoDto solicitacaoDocumentoDto)
        {
            try
            {
                _documentosService.RegistrarAprovacaoDeDocumento(solicitacaoDocumentoDto);
                return Json("Aprovação de documento realizada com sucesso.");
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }
        public ActionResult ExecucaoFase4ReprovacaoDocumento(SolicitacaoDocumentoDto solicitacaoDocumentoDto)
        {
            try
            {
                _documentosService.RegistrarReprovacaoDeDocumento(solicitacaoDocumentoDto);
                return Json("Reprovação de documento realizada com sucesso.");
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }

        #endregion

        #region [ Fase 5 ]

        public ActionResult ExecucaoFase5Publicacao(SolicitacaoDocumentoDto solicitacaoDocumentoDto)
        {
            try
            {
                _documentosService.RegistrarPublicacaoDeDocumento(solicitacaoDocumentoDto);
                return Json("Publicação de documento realizada com sucesso.");
            }
            catch (Exception ex) 
            {
                throw new HttpException(ex.Message);
            }
        }

        #endregion
        
        #endregion
    }
}