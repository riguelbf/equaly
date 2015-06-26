using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using DKO.EQualy.Domain.Entities;
using DKO.EQualy.Domain.Interfaces.Repository;
using DKO.EQualy.Domain.Interfaces.Service;
using DKO.Equaly.DTO.NaoConformidade;
using DKO.Equaly.Projection.NaoConformidade;

namespace DKO.Equaly.Service.Concrete.NaoConformidade
{
    public class NaoConformidadeService : ServiceBase, INaoConformidadeService
    {
        private readonly INaoConformidadeRepository _naoConformidadeRepository;
        private readonly IReclamativaRepository _reclamativaRepository;

        public NaoConformidadeService(INaoConformidadeRepository naoConformidadeRepository,
                                      IReclamativaRepository reclamativaRepository)
        {
            this._naoConformidadeRepository = naoConformidadeRepository;
            this._reclamativaRepository = reclamativaRepository;
        }

        public IEnumerable<NaoConformidadeRegistradaProjection> ObterNaoConformidadeRegistradas(FiltroRNCDto filtro)
        {
            if (filtro.DataInicial == DateTime.MinValue)
                filtro.DataInicial = DateTime.MinValue.AddYears(1900);

            if (filtro.DataFinal == DateTime.MinValue)
                filtro.DataFinal = DateTime.MaxValue;

            var ncp = _reclamativaRepository.GetMany(r =>

                (r.UsuarioCriou.Id == filtro.UsuarioCriouId || filtro.UsuarioCriouId == 0) &&
                (r.NomeReclamante.ToUpper().Contains(filtro.NomeReclamante) || string.IsNullOrEmpty(filtro.NomeReclamante)) &&
                (r.UsuarioCriou.Setor.Id == filtro.SetorResponsavelId || filtro.SetorResponsavelId == 0) &&
                (r.DataCriacao >= filtro.DataInicial && r.DataCriacao <= filtro.DataFinal)

                ).Select(r => new NaoConformidadeRegistradaProjection
                {
                    Codigo = r.Id,
                    DataAbertura = r.DataCriacao,
                    IndicadorPrazo = ObterIndicadorDePrazo(r.DataCriacao),
                    NomeReclamante = r.NomeReclamante,
                    NomeResponsavelAbertura = r.UsuarioCriou.Nome,
                    Status = "",
                    TelefoneReclamante = r.TelefoneReclamante,
                    Titulo = r.Titulo
                });

            return ncp;
        }

        public NaoConformidadeDto ObterNaoConformidade(int naoConformidadeId)
        {
            var naoConformidade = _naoConformidadeRepository.Get(naoConformidadeId);

            return new NaoConformidadeDto
            {
                Codigo = naoConformidade.Codigo,
                DataCriacao = naoConformidade.DataCriacao,
                NaoConformidadeId = naoConformidade.Id
            };
        }

        public void Excluir(int naoConformidadeId)
        {
            this.BeginTransaction();
            _naoConformidadeRepository.Delete(nc => nc.Id == naoConformidadeId);
            this.Commit();
        }

        private static string ObterIndicadorDePrazo(DateTime dataCriacao)
        {
            var dataDoPrazo = dataCriacao.Date.AddDays(7);
            var dias = (dataDoPrazo - DateTime.Now.Date).Days;

            if (dias >= 0 && dias <= 2)
                return "yellowDeadline.png";
            else if (dias < 0)
                return "redDeadline.png";
            else
                return "greenDeadline.png";
        }

        public IEnumerable<Historico> ObterHistoricos(int naoConformidadeId)
        {
            var naoConformidade = _naoConformidadeRepository.Get(naoConformidadeId);
            return naoConformidade == null? null : naoConformidade.HistoricoRncs.ToList();
        }
    }
}