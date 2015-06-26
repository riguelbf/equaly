using System.Collections.Generic;
using System.Linq;
using DKO.EQualy.Domain.Entities;
using DKO.EQualy.Domain.Interfaces;
using DKO.EQualy.Domain.Interfaces.Repository;
using DKO.EQualy.Domain.Interfaces.Service;

namespace DKO.Equaly.Service.Concrete
{
    public class SetorService : ServiceBase, ISetorService
    {
        private readonly ISetorRepository _setorRepository;

        public SetorService(ISetorRepository setorRepository)
        {
            this._setorRepository = setorRepository;
        }

        public List<Setor> ObterSetores()
        {
            return _setorRepository.GetAll().OrderBy(s => s.Nome).ToList();
        }
    }
}