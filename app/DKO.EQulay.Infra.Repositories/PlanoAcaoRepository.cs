using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DKO.EQualy.Domain.Entities;
using DKO.EQualy.Domain.Interfaces;
using DKO.EQualy.Domain.Interfaces.Repository;
using DKO.EQulay.Infra.Repositories.EF;
using Microsoft.Practices.ServiceLocation;

namespace DKO.EQulay.Infra.Repositories
{
    public class PlanoAcaoRepository : RepositoryBase<PlanoDeAcao>, IPlanoAcaoRepository
    {
        
    }
}
