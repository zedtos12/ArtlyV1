using ArtlyV1.Handlers;
using ArtlyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtlyV1.Controllers
{
    public class ProductPageController
    {
        ProductPageHandler productPageHandler = new ProductPageHandler();

        public List<LtProductType> GetListType()
        {
            var result = productPageHandler.getTypes();
            return result;
        }

        public List<LtProductCategory> GetListCategories()
        {
            var result = productPageHandler.getCategories();
            return result;
        }

        public List<MsProduct> GetListProductByFilter(string search, List<string> idProductCategory, List<string> idProductType)
        {
            var result = productPageHandler.getProductByFilter(search, idProductCategory, idProductType);
            return result;
        }
    }
}