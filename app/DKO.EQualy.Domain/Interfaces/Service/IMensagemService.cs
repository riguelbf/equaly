using DKO.EQualy.Domain.Entities;

namespace DKO.EQualy.Domain.Interfaces.Service
{
    public interface IMensagemService
    {
        void Salvar(Mensagem mensagem);

        void Atualizar(Mensagem mensagem);
    }
}