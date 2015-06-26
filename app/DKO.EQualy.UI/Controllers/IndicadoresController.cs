using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DKO.EQualy.Domain.Interfaces.Service;
using DKO.Equaly.DTO.Indicadores;
using DKO.Equaly.Projection.Indicadores;
using DKO.EQulay.Infra.Repositories;
using DKO.EQulay.Infra.Repositories.EF;
using Microsoft.Ajax.Utilities;

namespace DKO.EQualy.UI.Controllers
{
    public class IndicadoresController : BaseController
    {
        private readonly NaoConformidadeRepository _naoConformidadeRepository;
        private readonly PlanoAcaoRepository _planoDeAcaoRepository;
        private readonly DocumentoRepository _documentoRepository;


        public IndicadoresController(NaoConformidadeRepository naoConformidadeRepository, PlanoAcaoRepository planoAcaoRepository, DocumentoRepository documentoRepository)
        {
            this._naoConformidadeRepository = naoConformidadeRepository;
            this._planoDeAcaoRepository = planoAcaoRepository;
            this._documentoRepository = documentoRepository;
        }
        //
        // GET: /Indicadores/
        public ActionResult GerenciarIndicadores()
        {
            return View("GerenciarIndicadores");
        }

        public ActionResult PesquisaGeral(DateTime dataInicial, DateTime dataFinal)
        {
            try
            {
                var dto = new PosicaoAtualDto
                {
                    QtdAcaoCorretiva = this.ObterTotalAcoesCorretivas(dataInicial, dataFinal),
                    QtdAcaoPreventiva = this.ObterTotalAcoesPreventivas(dataInicial, dataFinal),
                    QtdDocumentos = this.ObterTotalDocumentos(dataInicial, dataFinal),
                    QtdRncAbertas = this.ObterTotalRncAbertas(dataInicial, dataFinal),
                    QuantidadeDeRNC = this.ObterTotalRncRegPorArea(dataInicial, dataFinal).ToList(),
                    QuantidadeDeRNCAvaliada = this.ObterTotalRncAvaliadaPorArea(dataInicial, dataFinal).ToList(),
                    NaoConformidadeRegistrada = this.ObterRncRegistradaMes(dataInicial, dataFinal).OrderBy(r => r.Data).ToList(),
                    PlanoDeAcaoRegistrada = this.ObterPlanoDeAcaoMes(dataInicial,dataFinal).ToList()
                };
                return Json(dto);
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }
        }

        #region [ Mini graficos ]

        private int ObterTotalAcoesCorretivas(DateTime dataInicial, DateTime dataFinal)
        {
            return _planoDeAcaoRepository.GetAll()
                        .Select(p => p.Ferramenta5W2H
                            .Select(f => f.DataCriacao >= dataInicial
                                    && f.DataCriacao <= dataFinal
                                    && f.TipoDePlanoDeAcao == EQualy.Domain.Enum.NaoConformidade.TipoDePlanoDeAcao.Corretiva)).ToList().Count;
        }

        private int ObterTotalAcoesPreventivas(DateTime dataInicial, DateTime dataFinal)
        {
            return _planoDeAcaoRepository.GetAll()
                        .Select(p => p.Ferramenta5W2H
                            .Select(f => f.DataCriacao >= dataInicial
                                    && f.DataCriacao <= dataFinal
                                    && f.TipoDePlanoDeAcao == EQualy.Domain.Enum.NaoConformidade.TipoDePlanoDeAcao.Preventiva)).ToList().Count;
        }

        private int ObterTotalRncAbertas(DateTime dataInicial, DateTime dataFinal)
        {
            return
                _naoConformidadeRepository.GetAll()
                    .Select(nc => nc.DataCriacao >= dataInicial && nc.DataCriacao <= dataFinal)
                    .Count();
        }

        private int ObterTotalDocumentos(DateTime dataInicial, DateTime dataFinal)
        {
            return
                _documentoRepository.GetAll()
                    .Select(
                        d =>
                            d.DataEmissao >= dataInicial & d.DataEmissao <= dataFinal &&
                            d.FaseDocumento == EQualy.Domain.Enum.Documento.FaseDocumento.Disponibilizado)
                    .Count();
        }

        #endregion

        #region [ Graficos pizza ]

        private IEnumerable<GraficoPizzaProjection> ObterTotalRncRegPorArea(DateTime dataInicial, DateTime dataFinal)
        {
            return _naoConformidadeRepository.GetAll()
                .Where(nc => nc.DataCriacao >= dataInicial && nc.DataCriacao <= dataFinal)
                .GroupBy(nc => new { nc.UsuarioResponsavel.Setor.Id, nc.UsuarioResponsavel.Setor.Nome }).Select(r => new GraficoPizzaProjection
            {
                NomeSerie = r.Key.Nome,
                Valor = 1

            }).ToList();
        }

        private IEnumerable<GraficoPizzaProjection> ObterTotalRncAvaliadaPorArea(DateTime dataInicial, DateTime dataFinal)
        {
            return _naoConformidadeRepository.GetAll()
                .Where(nc => nc.DataCriacao >= dataInicial && nc.DataCriacao <= dataFinal && nc.Eficacia.Pontuacao > 0)
                .GroupBy(nc => new { nc.UsuarioResponsavel.Setor.Id, nc.UsuarioResponsavel.Setor.Nome }).Select(r => new GraficoPizzaProjection
                {
                    NomeSerie = r.Key.Nome,
                    Valor = 1

                }).ToList();
        }

        #endregion

        #region [ Grafico de linha ]
        private IEnumerable<GraficoLinhaProjection> ObterRncRegistradaMes(DateTime dataInicial, DateTime dataFinal)
        {
            return _naoConformidadeRepository.GetAll()
                .Where(nc => nc.DataCriacao >= dataInicial && nc.DataCriacao <= dataFinal)
                .GroupBy(nc => new { nc.DataCriacao }).ToList().ConvertAll(r => new GraficoLinhaProjection
                {
                    Data = r.Key.DataCriacao.Year + "/" + r.Key.DataCriacao.Month + "/" + r.Key.DataCriacao.Day,
                    Quantidade = 1

                }).ToList();
        }

        #endregion

        #region [ Graficos barra ]

        private IEnumerable<GraficoLinhaProjection> ObterPlanoDeAcaoMes(DateTime dataInicial, DateTime dataFinal)
        {
            var listaPlanosAcao = _planoDeAcaoRepository.GetAll()
                .Select(p => p.Ferramenta5W2H
                    .GroupBy(pa => new {pa.DataCriacao}).ToList().Select(r => new
                    {
                        Data = r.Key.DataCriacao,
                        Valor = 1
                    })).Single().ToList();

            var resultado = new List<GraficoLinhaProjection>();

            listaPlanosAcao.ForEach(x => resultado.Add(new GraficoLinhaProjection
            {
                Data = x.Data.Year + "/" + x.Data.Month + "/" + x.Data.Day,
                Quantidade = x.Valor

            }));

            return resultado;
        }

        #endregion
    }
}