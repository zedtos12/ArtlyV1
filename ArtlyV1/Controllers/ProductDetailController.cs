using ArtlyV1.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtlyV1.Controllers
{
    public class ProductDetailController
    {
        ProductDetailHandler detailHandler = new ProductDetailHandler();

        private Boolean isProductValid(String productID)
        {
            if (productID == null || detailHandler.isProductFound(productID))
            {
                return false;
            }
            return true;
        }

        public String getProductName(String productID)
        {
            if(isProductValid(productID))
            {
                return detailHandler.getProductName(productID);
            }

            return null;
        }

        public decimal getProductPrice(String productID)
        {
            if (isProductValid(productID))
            {
                return detailHandler.getProductPrice(productID);
            }

            return -1;
        }

        public int getProductStock(String productID)
        {
            if (isProductValid(productID))
            {
                return detailHandler.getProductStock(productID);
            }

            return -1;
        }
    }
}