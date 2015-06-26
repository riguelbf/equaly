using DKO.Equaly.DTO.NaoConformidade.Eficacia;

namespace DKO.EQualy.Domain.Interfaces.Service
{
    public interface IEficaciaService
    {
        EficaciaDto ObterEficaciaDto(int naoConformidadeId);

        void RegistrarEficacia(EficaciaDto eficaciaDto,int usuarioQueRegistrouID);
        void EnviarEmailDeAvisoDePublicacao(EQualy.Domain.Entities.NaoConformidade naoConformidade);
    }
}