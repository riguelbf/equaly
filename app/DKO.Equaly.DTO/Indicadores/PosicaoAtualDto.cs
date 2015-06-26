using System.Collections.Generic;
using DKO.Equaly.Projection.Indicadores;

namespace DKO.Equaly.DTO.Indicadores
{
    public class PosicaoAtualDto
    {
        public int QtdRncAbertas { get; set; }
        public int QtdAcaoPreventiva { get; set; }
        public int QtdAcaoCorretiva { get; set; }
        public int QtdDocumentos { get; set; }
        public List<GraficoPizzaProjection> QuantidadeDeRNC { get; set; }
        public List<GraficoPizzaProjection> QuantidadeDeRNCAvaliada { get; set; }
        public List<GraficoLinhaProjection> NaoConformidadeRegistrada { get; set; }
        public List<GraficoLinhaProjection> PlanoDeAcaoRegistrada { get; set; } 
    }
}
