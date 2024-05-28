using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;

namespace ArtlyV1.Repository
{
    public class ArtlyDatabaseConfiguration : DbConfiguration
    {
        public ArtlyDatabaseConfiguration()
        {
            DbInterception.Add(new ActiveEntitiesInterceptor());
        }
    }
}
