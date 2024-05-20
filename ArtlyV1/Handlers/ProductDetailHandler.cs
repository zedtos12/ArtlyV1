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

        public String getSellerName(String productID)
        {
            String userID = (from x in db.MsProducts where x.IdProduct == productID select x.UserInput).FirstOrDefault();
            String sellerName = (from x in db.MsUsers where x.IdUser == userID select x.UserName).FirstOrDefault();
            return sellerName;
        }

        public String getProductImage(String productID)
        {
            String productImage = (from x in db.MsProducts where x.IdProduct == productID select x.ProductImage).FirstOrDefault();
            return productImage;
        }

        public String getProductDescription(String productID)
        {
            String productDescription = (from x in db.MsProducts where x.IdProduct == productID select x.Description).FirstOrDefault(); 
            return productDescription;
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