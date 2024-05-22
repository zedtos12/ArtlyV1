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

        public Boolean isProductValid(String productID)
        {
            if (productID == null || detailHandler.isProductFound(productID) == false)
            {
                return false;
            }
            return true;
        }
    }
}