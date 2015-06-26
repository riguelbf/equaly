using System.Collections.Generic;
using DKO.EQualy.Domain.Entities;
using DKO.Equaly.DTO.NaoConformidade;
using DKO.Equaly.Projection.NaoConformidade;

namespace DKO.EQualy.Domain.Interfaces.Service
{
    public interface INaoConformidadeService
    {
        IEnumerable<NaoConformidadeRegistradaProjection> ObterNaoConformidadeRegistradas(FiltroRNCDto filtro);

        NaoConformidadeDto ObterNaoConformidade(int naoConformidadeId);

        void Excluir(int naoConformidadeId);

        IEnumerable<Historico> ObterHistoricos(int naoConformidadeId);
    }
}