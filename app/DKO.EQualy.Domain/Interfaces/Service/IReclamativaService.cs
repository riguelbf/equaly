using DKO.Equaly.DTO.NaoConformidade;

namespace DKO.EQualy.Domain.Interfaces.Service
{
    public interface IReclamativaService
    {
        ReclamativaDto ObterReclamativaDto(int naoConformidadeId);

        void RegistrarReclamativa(ReclamativaDto reclamativaDto);
    }
}