using System.Web;
using DKO.EQualy.Domain.Interfaces;
using DKO.Equaly.Service.Security;
using Microsoft.Practices.ServiceLocation;

namespace DKO.Equaly.Service.Concrete
{
    public class ServiceBase
    {
        private IUnitOfWork _unityOfWork;

        public void BeginTransaction()
        {
            _unityOfWork = ServiceLocator.Current.GetInstance<IUnitOfWork>();
            _unityOfWork.BeginTransaction();
        }

        public void Commit()
        {
            _unityOfWork.Commit();
        }

        public CustomPrincipal GetUserLogged()
        {
            return ((CustomPrincipal) HttpContext.Current.User);
        }
    }
}