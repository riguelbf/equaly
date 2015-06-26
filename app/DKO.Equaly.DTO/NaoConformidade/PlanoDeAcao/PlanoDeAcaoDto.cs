using System.Collections.Generic;
using DKO.Equaly.Projection.NaoConformidade.PlanoDeAcao;

namespace DKO.Equaly.DTO.NaoConformidade.PlanoDeAcao
{
    public class PlanoDeAcaoDto
    {
        public int NaoConformidadeId { get; set; }
        public IEnumerable<PlanoDeAcaoProjection> PlanoDeAcaoProjections { get; set; } 
    }
}