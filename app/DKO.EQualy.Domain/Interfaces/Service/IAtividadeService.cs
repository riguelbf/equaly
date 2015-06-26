using DKO.EQualy.Domain.Entities;

namespace DKO.EQualy.Domain.Interfaces.Service
{
    public interface IAtividadeService
    {
        Atividade ObterPoId(int idAtividade);

        void Salvar(Atividade atividade);

        void Atualizar(Atividade atividade);
    }
}