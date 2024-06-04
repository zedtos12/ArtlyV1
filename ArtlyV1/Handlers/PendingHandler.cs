using ArtlyV1.Models;
using ArtlyV1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtlyV1.Handlers
{
    public class PendingHandler
    {
        ArtlyDatabaseEntities db = DatabaseSingleton.getInstance();

        public List<PendingProduct> GetPendingProducts()
        {
            List<PendingProduct> results = (from products in db.ActiveEntities<PendingProduct>() select products).ToList();
            return results;
        }

        public void ApproveProduct(string idProduct)
        {

        }
    }
}