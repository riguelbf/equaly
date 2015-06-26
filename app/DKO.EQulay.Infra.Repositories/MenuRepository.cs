using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DKO.EQualy.Domain.Entities;
using DKO.EQualy.Domain.Interfaces;
using DKO.EQualy.Domain.Interfaces.Repository;

namespace DKO.EQulay.Infra.Repositories
{
    public class MenuRepository : RepositoryBase<Menu>, IMenuRepository
    {

    }
}