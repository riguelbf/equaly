using DKO.EQualy.Domain.Entities;
using DKO.EQualy.Domain.Interfaces;
using DKO.EQualy.Domain.Interfaces.Repository;
using DKO.EQualy.Domain.Interfaces.Service;

namespace DKO.Equaly.Service.Concrete
{
    public class MensagemService : ServiceBase, IMensagemService
    {
        private readonly IMensagemRepository _mensagemRepository;

        public MensagemService(IMensagemRepository mensagemRepository)
        {
            _mensagemRepository = mensagemRepository;
        }

        public void Salvar(Mensagem mensagem)
        {
            this.BeginTransaction();
            _mensagemRepository.Add(mensagem);
            this.Commit();
        }

        public void Atualizar(Mensagem mensagem)
        {
            this.BeginTransaction();

            var mensagemAntiga = _mensagemRepository.Get(m => m.Id == mensagem.Id);
            _mensagemRepository.Update(mensagem);
            this.Commit();
        }
    }
}