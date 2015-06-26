using DKO.Equaly.DTO.NaoConformidade.PlanoDeAcao;

namespace DKO.EQualy.Domain.Interfaces.Service
{
    public interface IPlanoDeAcaoService
    {
        void RegistrarPlanoDeAcao(PlanoDeAcaoDto planoDeAcaoDto);

        PlanoDeAcaoDto ObterPlanoDeAcaoDto(int naoConformidadeId);
    }
}