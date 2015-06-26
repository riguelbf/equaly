using System;
using DKO.EQualy.Domain.Entities;
using DKO.EQualy.Domain.Interfaces;
using DKO.EQualy.Domain.Interfaces.Repository;
using DKO.EQualy.Domain.Interfaces.Service;

namespace DKO.Equaly.Service.Concrete
{
    public class AtividadeService : ServiceBase, IAtividadeService
    {
        private readonly IAtividadeRepository _atividadeRepository;

        public AtividadeService(IAtividadeRepository atividadeRepository)
        {
            _atividadeRepository = atividadeRepository;
        }

        public Atividade ObterPoId(int idAtividade)
        {
            return _atividadeRepository.Get(a => a.Id == idAtividade);
        }

        public void Salvar(Atividade atividade)
        {
            this.BeginTransaction();
            _atividadeRepository.Add(atividade);
            this.Commit();
        }

        public void Atualizar(Atividade atividade)
        {
            this.BeginTransaction();
            _atividadeRepository.Update(atividade);
            this.Commit();
        }
    }
}