using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DKO.EQualy.Domain.Entities;
using DKO.EQualy.Domain.Interfaces;
using DKO.EQualy.Domain.Interfaces.Helpers;
using DKO.Equaly.DTO.Usuario;
using DKO.Equaly.Service;
using DKO.Equaly.Service.Concrete;
using DKO.Equaly.Service.Security;
using Microsoft.AspNet.Identity;

namespace DKO.EQualy.UI.Controllers
{
    public class PerfilController : BaseController
    {
        private readonly UsuarioService _usuarioService;
        private readonly MensagemService _mensagemService;
        private readonly AtividadeService _atividadeService;
        
        public PerfilController(UsuarioService usuarioService, MensagemService mensagemService, AtividadeService atividadeService, IEnumHelper enumHelper)
        {
            this._usuarioService = usuarioService;
            this._mensagemService = mensagemService;
            this._atividadeService = atividadeService;
            ViewBag.Usuarios = usuarioService.ObterUsuarios();

            ViewBag.ListaStatusTarefa = Enum.GetValues(typeof(DKO.EQualy.Domain.Enum.Atividade.StatusAtividade)).Cast<DKO.EQualy.Domain.Enum.Atividade.StatusAtividade>().Select(v => new SelectListItem
            {
                Text = enumHelper.ObterDescricaoDoEnum(v),
                Value = ((int)v).ToString()

            }).ToList();

            ViewBag.LstaTipoTarefa = Enum.GetValues(typeof(DKO.EQualy.Domain.Enum.Atividade.TipoAtividade)).Cast<DKO.EQualy.Domain.Enum.Atividade.TipoAtividade>().Select(v => new SelectListItem
            {
                Text = enumHelper.ObterDescricaoDoEnum(v),
                Value = ((int)v).ToString()
            });
    
        }
        public ActionResult Index()
        {
            var model = _usuarioService.ObterDadosPerfilUsuario(this.CustomPrincipal.UsuarioId);
            return View("Perfil", model);
        }

        #region [Visao geral]

        #region [ Atividade ]

        public ActionResult RegistrarAtividade(Atividade atividade)
        {
            try
            {
                if (atividade.Id > 0)
                {
                    _atividadeService.Atualizar(atividade);
                    return Json("Atualização realizada com suceso!");
                }
                else
                {
                    atividade.UsuarioCriou = _usuarioService.ObterUsuarios().FirstOrDefault(u => u.Id == 1);
                    _atividadeService.Salvar(atividade);
                    return Json("Inclusão realizada com suceso!");
                }
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }

        public ActionResult EditarTarefa(int idAtividade)
        {
            var atividade = _atividadeService.ObterPoId(idAtividade) ?? new Atividade { DataCriacao = DateTime.Now, DataConclusao = DateTime.Now.AddDays(1), StatusAtividade = Domain.Enum.Atividade.StatusAtividade.Criada };
            return PartialView("_ManterAtividade", atividade);
        }

        public ActionResult ExcluirTarefa(int idAtividade)
        {
            return PartialView("_ManterAtividade", new Atividade());

        }

        #endregion

        #region [ Mensagem ]

        [HttpPost]
        public ActionResult RegistrarMensagem(Mensagem mensagem)
        {
            try
            {
                if (mensagem.Id > 0)
                {
                    _mensagemService.Atualizar(mensagem);
                    return Json("Atualização realizada com suceso!");
                }
                else
                {
                    _mensagemService.Salvar(mensagem);
                    return Json("Inclusão realizada com suceso!");
                }
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }

        public ActionResult EditarMensagem(Mensagem mensagem)
        {
            var atividade = _atividadeService.ObterPoId(mensagem.Id) ?? new Atividade { DataCriacao = DateTime.Now, DataConclusao = DateTime.Now.AddDays(1) , StatusAtividade = Domain.Enum.Atividade.StatusAtividade.Criada };
            return PartialView("_ManterAtividade", atividade);
        }

        public ActionResult ExcluirMensagem(int id)
        {
            return PartialView("_ManterAtividade", new Atividade());
        }

        #endregion

        #endregion

        #region [Dados perfil]

        [HttpPost]
        public ActionResult AtualizarDadosPerfil(PerfilDto perfilDto)
        {
            try
            {
                _usuarioService.Salvar(perfilDto);
                return Json("Atualização realizada com suceso!");
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }

        public ActionResult AtualizarSenha(PerfilDto perfilDto)
        {
            try
            {
                _usuarioService.AtualizarSenha(perfilDto);
                return Json("Atualização realizada com suceso!");
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult AtualizarFotoPerfil(PerfilDto perfilDto)
        {
            try
            {
                _usuarioService.SalvarNovaFotoPerfil(perfilDto.Arquivo);
                return Json("Atualização de foto realizada com suceso!");
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }

        //[HttpPost]
        //public JsonResult AtualizarFotoPerfil()
        //{
        //    HttpPostedFileBase myFile = Request.Files["MyFile"];
        //    bool isUploaded = false;
        //    string message = "File upload failed";

        //    if (myFile != null && myFile.ContentLength != 0)
        //    {
        //        string pathForSaving = Server.MapPath("~/Content/images/imagesPerfil");

        //        try
        //        {
        //            myFile.SaveAs(Path.Combine(pathForSaving, myFile.FileName));
        //            isUploaded = true;
        //            message = "File uploaded successfully!";
        //        }
        //        catch (Exception ex)
        //        {
        //            message = string.Format("File upload failed: {0}", ex.Message);
        //        }
        //    }
        //    return Json(new { isUploaded = isUploaded, message = message }, "text/html");
        //}

        #endregion

        
    }
}