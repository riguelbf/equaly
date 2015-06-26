using System;
using System.Collections.Generic;
using System.ServiceModel.Channels;
using System.Web;
using CommonServiceLocator.NinjectAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;
using Ninject;

namespace DKO.EQualy.Infra.IOC
{
    public class Ioc
    {
        private static StandardKernel _kernel;

        public static void Init()
        {
            _kernel = new StandardKernel(new IocModule());
            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(_kernel));
        }

        public static object Get(Type type)
        {
            return _kernel.TryGet(type);
        }

        public static IEnumerable<object> GetAll(Type type)
        {
            return _kernel.GetAll(type);
        } 
    }
}