using DKO.Equaly.DTO.Email;

namespace DKO.EQualy.Domain.Interfaces.Service
{
    public interface IEmailService
    {
        void Enviar(EmailDto emailDto);
    }
}