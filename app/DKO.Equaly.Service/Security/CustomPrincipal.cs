using System.Linq;
using System.Security.Principal;
using DKO.EQualy.Domain.Interfaces;
using Ninject;

namespace DKO.Equaly.Service.Security
{
    public class CustomPrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role)
        {
            return Roles.Any(role.Contains);
        }

        public CustomPrincipal(string username)
        {
            this.Identity = new GenericIdentity(username);
        }

        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Roles { get; set; }
    }
}
