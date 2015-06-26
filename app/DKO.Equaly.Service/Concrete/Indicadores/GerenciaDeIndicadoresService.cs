using System;
using System.Linq;
using DKO.EQualy.Domain.Interfaces.Repository;
using DKO.EQualy.Domain.Interfaces.Service;
using DKO.Equaly.DTO.Indicadores;

namespace DKO.Equaly.Service.Concrete.Indicadores
{
    public class GerenciaDeIndicadoresService : ServiceBase, IGerenciaDeIndicadoresService
    {
          private readonly INaoConformidadeRepository _naoConformidadesRepository;
        private readonly IPlanoAcaoRepository _planoDeAcaoRepository;
        private readonly IDocumentoRepository _documentosRepository;

     
        public GerenciaDeIndicadoresService(IDocumentoRepository documentoRepository,INaoConformidadeRepository naoConformidadeRepository
                                , IPlanoAcaoRepository planoAcaoRepository)
        {
            this._naoConformidadesRepository = naoConformidadeRepository;
            this._planoDeAcaoRepository = planoAcaoRepository;
            this._documentosRepository = documentoRepository;
        }
        public PosicaoAtualDto PesquisaPosicaoAtual(DateTime dataInicial, DateTime dataFinal)
        {
            return new PosicaoAtualDto
            {
                QtdAcaoCorretiva = this.ObterTotalAcoesCorretivas(dataInicial,dataFinal),
                QtdAcaoPreventiva = this.ObterTotalAcoesPreventivas(dataInicial,dataFinal),
                QtdDocumentos = this.ObterTotalDocumentos(dataInicial,dataFinal),
                QtdRncAbertas = this.ObterTotalRncAbertas(dataInicial,dataFinal),
                QuantidadeDeRNC = null,
                QuantidadeDeRNCAvaliada = null
            };
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
                _naoConformidadesRepository.GetAll()
                    .Select(nc => nc.DataCriacao >= dataInicial && nc.DataCriacao <= dataFinal)
                    .Count();
        }

        private int ObterTotalDocumentos(DateTime dataInicial, DateTime dataFinal)
        {
            return
                _documentosRepository.GetAll()
                    .Select(
                        d =>
                            d.DataEmissao >= dataInicial & d.DataEmissao <= dataFinal &&
                            d.FaseDocumento == EQualy.Domain.Enum.Documento.FaseDocumento.Disponibilizado)
                    .Count();
        }

        #endregion

        #region [ Graficos pizza ]

        #endregion

        #region [ Graficos barra ]

        #endregion
    }
}