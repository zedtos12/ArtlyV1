using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ArtlyV1.Repository
{
    public class ArtlyDatabaseConfiguration : DbConfiguration
    {
        public ArtlyDatabaseConfiguration()
        {
            //DbInterception.Add(new ActiveEntitiesInterceptor());
        }
    }
}