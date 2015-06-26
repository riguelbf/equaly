using System.Data.Entity;
using System.Web;

namespace DKO.EQulay.Infra.Repositories.EF
{
    public class ContextManager
    {
        public const string ContextKey = "ContextManager.Context";

        public DbContext Context
        {
            get
            {
                if (HttpContext.Current.Items[ContextKey] == null)
                {
                    HttpContext.Current.Items[ContextKey] = new EQualyContext();
                }

                return (EQualyContext)HttpContext.Current.Items[ContextKey];
            }
        }
    }
}