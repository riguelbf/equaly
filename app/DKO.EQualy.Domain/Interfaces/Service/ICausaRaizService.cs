using DKO.Equaly.DTO.NaoConformidade;

namespace DKO.EQualy.Domain.Interfaces.Service
{
    public interface ICausaRaizService
    {
        AnaliseDaCausaDto ObterAnaliseDaCausaDto(int naoConformidadeId);

        void Registrar(AnaliseDaCausaDto analiseDaCausaDto);
    }
}