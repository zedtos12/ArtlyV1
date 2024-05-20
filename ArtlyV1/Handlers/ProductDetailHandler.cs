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

        public String getProductName(String productID)
        {
            String productName = (from x in db.MsProducts where x.IdProduct == productID select x.ProductName).FirstOrDefault();
            return productName;
        }

        public decimal getProductPrice(String productID)
        {
            decimal productPrice = (from x in db.MsProducts where x.IdProduct == productID select x.Price).FirstOrDefault();
            return productPrice;
        }

        public int getProductStock(String productID)
        {
            int productStock = (from x in db.MsProducts where x.IdProduct == productID select x.Stock).FirstOrDefault();
            return productStock;
        }
    }
}