using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DKO.EQualy.Domain.Entities;
using DKO.EQualy.Domain.Interfaces.Helpers;
using DKO.EQualy.Domain.Interfaces.Service;
using DKO.Equaly.DTO.App;
using DKO.Equaly.DTO.NaoConformidade;
using DKO.Equaly.DTO.NaoConformidade.Eficacia;
using DKO.Equaly.DTO.NaoConformidade.PlanoDeAcao;
using DKO.Equaly.Projection.NaoConformidade.AnaliseDaCausa;
using DKO.Equaly.Projection.NaoConformidade.PlanoDeAcao;
using DKO.Equaly.Service.Concrete;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;

namespace DKO.EQualy.UI.Controllers
{
    public class NaoConformidadesController : BaseController
    {
        private readonly ISetorService _setorService;
        private readonly IUsuarioService _usuarioService;
        private readonly IEnumHelper _enumHelper;
        private readonly INaoConformidadeService _naoConformidadeService;
        private readonly IReclamativaService _reclamativaService;
        private readonly ICausaRaizService _causaRaizService;
        private readonly IPlanoDeAcaoService _planoDeAcaoService;
        private readonly IEficaciaService _eficaciaService;

        #region [ Geral ]

        public NaoConformidadesController(ISetorService setorService
                                         , IUsuarioService usuarioService
                                         , IEnumHelper enumHelper
                                         , INaoConformidadeService naoConformidadeService
                                         , IReclamativaService reclamativaService
                                         , ICausaRaizService causaRaizService
                                         , IPlanoDeAcaoService planoDeAcaoService
            ,IEficaciaService eficaciaService)
        {
            this._setorService = setorService;
            this._usuarioService = usuarioService;
            this._enumHelper = enumHelper;
            this._naoConformidadeService = naoConformidadeService;
            this._reclamativaService = reclamativaService;
            this._causaRaizService = causaRaizService;
            this._planoDeAcaoService = planoDeAcaoService;
            this._eficaciaService = eficaciaService;

            ViewBag.Setores = _setorService.ObterSetores().ConvertAll(s => new ValorTextoDto() { Text = s.Id.ToString(), Value = s.Nome }).OrderBy(r => r.Text);
            ViewBag.Usuarios = _usuarioService.ObterUsuarios().ToList().ConvertAll(s => new ValorTextoDto() { Text = s.Id.ToString(), Value = s.Nome }).OrderBy(r => r.Text);
            ViewBag.StatusRnc = Enum.GetValues(typeof(DKO.EQualy.Domain.Enum.NaoConformidade.Status)).Cast<DKO.EQualy.Domain.Enum.NaoConformidade.Status>().Select(v => new SelectListItem
            {
                Text = _enumHelper.ObterDescricaoDoEnum(v),
                Value = ((int)v).ToString()

            }).ToList();
        }

        public ActionResult GerenciarNaoConformidades()
        {
            return View();
        }

        #endregion

        #region [ Não conformidades geral ]

        public ActionResult ObterNaoConformidades(FiltroRNCDto filtro)
        {
            try
            {
                var listaRnc = _naoConformidadeService.ObterNaoConformidadeRegistradas(filtro);
                return PartialView("_TabelaDeRNC", listaRnc.ToList());
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }

        public PartialViewResult NovaRnc()
        {
            var model = new NaoConformidadeDto
            {
                Codigo = "XXX",
                DataCriacao = DateTime.Now.Date
            };
            return PartialView("_ManterRNC", model);
        }

        public ActionResult EditarRnc(int naoConformidadeId)
        {
            var naoConformidadeDto = _naoConformidadeService.ObterNaoConformidade(naoConformidadeId);
            return PartialView("_ManterRNC", naoConformidadeDto);
        }

        public ActionResult ExcluirRnc(int naoConformidadeId)
        {
            try
            {
                _naoConformidadeService.Excluir(naoConformidadeId);
                return Json("Exclusão de registro realizada com sucesso!");
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }

        #endregion

        #region [ Reclamativa ]

        public ActionResult ReclamativaIndex(int naoConformidadeId)
        {
            try
            {
                var reclamativaDto = naoConformidadeId == 0 ? new ReclamativaDto { DataCriacao = DateTime.Now }
                                                            : _reclamativaService.ObterReclamativaDto(naoConformidadeId);
                return PartialView("_Reclamativa", reclamativaDto);
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }

        public ActionResult RegistrarReclamativa(ReclamativaDto reclamativa)
        {
            try
            {
                _reclamativaService.RegistrarReclamativa(reclamativa);
                return Json("Reclamativa criada/atualizada com sucesso");
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }

        #endregion

        #region [ Causa raiz - Analise da causa]

        public ActionResult AnaliseDaCausaIndex(int naoConformidadeId)
        {
            try
            {
                var analiseDaCausa = naoConformidadeId == 0 ? new AnaliseDaCausaDto { NaoConformidadeId = naoConformidadeId } :
                                                              _causaRaizService.ObterAnaliseDaCausaDto(naoConformidadeId);

                return PartialView("_AnaliseDaCausa", analiseDaCausa);
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult RegistrarCausaRaiz(AnaliseDaCausaDto analiseDaCausaDto)
        {
            try
            {
                _causaRaizService.Registrar(analiseDaCausaDto);
                return Json("Registro da analise de causa realizada com sucesso!");
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditarPorque(CincoPorQueProjection cincoPorQueProjection)
        {
            return PartialView("_Manter5PorQue", cincoPorQueProjection ?? new CincoPorQueProjection());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult NovoCincoPorque(int[] equipeEnvolvidaIds)
        {
            if (equipeEnvolvidaIds != null)
                ViewBag.EquipeEnvolvidaCincoPorque =
                    _usuarioService.ObterUsuarios().Where(u => equipeEnvolvidaIds.Contains(u.Id)).ToList().ConvertAll(r => new ValorTextoDto
                    {
                        Text = r.Nome,
                        Value = r.Id.ToString()
                    });

            return PartialView("_Manter5PorQue", new CincoPorQueProjection());
        }

        #endregion

        #region [ Plano Ação ]

        public ActionResult PlanoDeAcaoIndex(int naoConformidadeId)
        {
            try
            {
                var planodeAcaoDto = _planoDeAcaoService.ObterPlanoDeAcaoDto(naoConformidadeId) ?? new PlanoDeAcaoDto();
                return PartialView("_PlanoAcao",planodeAcaoDto );
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }

        public ActionResult NovoPlanoAcao(int[] equipeEnvolvidaIds)
        {
            if (equipeEnvolvidaIds != null)
                ViewBag.EquipeEnvolvidaPlanoDeAcao =
                    _usuarioService.ObterUsuarios().Where(u => equipeEnvolvidaIds.Contains(u.Id)).ToList().ConvertAll(r => new ValorTextoDto
                    {
                        Text = r.Nome,
                        Value = r.Id.ToString()
                    });

            ViewBag.StatusPlanoDeAcao = Enum.GetValues(typeof(DKO.EQualy.Domain.Enum.NaoConformidade.StatusPlanoDeAcao)).Cast<DKO.EQualy.Domain.Enum.NaoConformidade.StatusPlanoDeAcao>().Select(v => new SelectListItem
            {
                Text = _enumHelper.ObterDescricaoDoEnum(v),
                Value = ((int)v).ToString()

            }).ToList();

            ViewBag.TiposPlanoDeAcao = Enum.GetValues(typeof(DKO.EQualy.Domain.Enum.NaoConformidade.TipoDePlanoDeAcao)).Cast<DKO.EQualy.Domain.Enum.NaoConformidade.TipoDePlanoDeAcao>().Select(v => new SelectListItem
            {
                Text = _enumHelper.ObterDescricaoDoEnum(v),
                Value = ((int)v).ToString()

            }).ToList();

            return PartialView("_ManterPlanoAcao", new ManterPlanoDeAcaoDto());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult RegistrarPlanoAcao(PlanoDeAcaoDto planoDeAcaoDto)
        {
            try
            {
                _planoDeAcaoService.RegistrarPlanoDeAcao(planoDeAcaoDto);
                return Json("Plano de ação atualizado/cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }

        public ActionResult EditarPlanoDeAcao(ManterPlanoDeAcaoDto planoDeAcaoDto, int[] equipeEnvolvidaIds)
        {

            if (equipeEnvolvidaIds != null)
                ViewBag.EquipeEnvolvidaPlanoDeAcao =
                    _usuarioService.ObterUsuarios().Where(u => equipeEnvolvidaIds.Contains(u.Id)).ToList().ConvertAll(r => new ValorTextoDto
                    {
                        Text = r.Nome,
                        Value = r.Id.ToString()
                    });

            ViewBag.StatusPlanoDeAcao = Enum.GetValues(typeof(DKO.EQualy.Domain.Enum.NaoConformidade.StatusPlanoDeAcao)).Cast<DKO.EQualy.Domain.Enum.NaoConformidade.StatusPlanoDeAcao>().Select(v => new SelectListItem
            {
                Text = _enumHelper.ObterDescricaoDoEnum(v),
                Value = ((int)v).ToString()

            }).ToList();

            ViewBag.TiposPlanoDeAcao = Enum.GetValues(typeof(DKO.EQualy.Domain.Enum.NaoConformidade.TipoDePlanoDeAcao)).Cast<DKO.EQualy.Domain.Enum.NaoConformidade.TipoDePlanoDeAcao>().Select(v => new SelectListItem
            {
                Text = _enumHelper.ObterDescricaoDoEnum(v),
                Value = ((int)v).ToString()

            }).ToList();

            return PartialView("_ManterPlanoAcao", new ManterPlanoDeAcaoDto());
        }

        public ActionResult ExcluirPlanoAcao(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region [ Avaliação da Eficacia ]

        public ActionResult AvaliacaoDaEficaciaIndex(int naoConformidadeId)
        {
            try
            {
                var eficaciaDto = _eficaciaService.ObterEficaciaDto(naoConformidadeId);
                return PartialView("_AvaliacaoDaEficacia", eficaciaDto);
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }

        public ActionResult RegistrarVerificacaoEficacia(EficaciaDto eficaciaDto)
        {
            try
            {
                var usuarioQueRegistrouId = CustomPrincipal.UsuarioId;
                _eficaciaService.RegistrarEficacia(eficaciaDto, usuarioQueRegistrouId);
                return Json("Avaliação de eficácia realizada com sucesso!");
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }

        #endregion

        #region [ Histórico ]

        public ActionResult HistoricoIndex(int naoConformidadeId)
        {
            try
            {
                var historicos = _naoConformidadeService.ObterHistoricos(naoConformidadeId) ?? new List<Historico>();
                return PartialView("_HistoricoRnc", historicos.ToList());
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }

        #endregion
    }
}