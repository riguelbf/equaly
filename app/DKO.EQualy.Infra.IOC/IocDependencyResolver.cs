using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using DKO.EQualy.Domain.Interfaces;

namespace DKO.EQualy.Infra.IOC
{
    public class IocDependencyResolver : IDependencyResolver
    {
        public object GetService(Type serviceType)
        {
            return Ioc.Get(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Ioc.GetAll(serviceType);
        }
    }
}