using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DKO.EQualy.Domain.Interfaces;
using Microsoft.Practices.ServiceLocation;

namespace DKO.EQulay.Infra.Repositories.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;

        public void BeginTransaction()
        {
            var contextManager = ServiceLocator.Current.GetInstance<ContextManager>();
            _context = contextManager.Context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
