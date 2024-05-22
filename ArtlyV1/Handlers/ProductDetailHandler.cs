using ArtlyV1.Models;
using ArtlyV1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtlyV1.Handlers
{
    public class ProductDetailHandler
    {
        ArtlyDatabaseEntities db = DatabaseSingleton.getInstance();

        public Boolean isProductFound(String productID)
        {
            MsProduct product = (from x in db.MsProducts where x.IdProduct == productID select x).FirstOrDefault();
            return product != null;
        }

        public MsProduct getProduct(String productID)
        {
            MsProduct product = (from x in db.MsProducts where x.IdProduct == productID select x).FirstOrDefault();
            return product;
        }

        public String getSellerName(String productID) {
            String sellerID = (from x in db.MsProducts where x.IdProduct == productID select x.UserInput).FirstOrDefault();
            String sellerName = (from x in db.MsUsers where x.IdUser == sellerID select x.UserName).FirstOrDefault();
            return sellerName;
        }
    }
}