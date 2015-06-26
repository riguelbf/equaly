using System;
using DKO.Equaly.DTO.Indicadores;

namespace DKO.EQualy.Domain.Interfaces.Service
{
    public interface IIindicadoresService
    {
        PosicaoAtualDto PesquisaPosicaoAtual(DateTime dataInicial, DateTime dataFinal);
    }
}