using System.Data.Entity;

namespace BDProjeto.RepositorioEF
{
    public class MyConfig : DbConfiguration
    {
        public MyConfig()
        {
            SetProviderServices(System.Data.Entity.SqlServer.SqlProviderServices.ProviderInvariantName,
                System.Data.Entity.SqlServer.SqlProviderServices.Instance
                );
        }
    }
}
