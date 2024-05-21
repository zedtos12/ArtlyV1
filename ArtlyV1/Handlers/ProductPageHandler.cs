using ArtlyV1.Models;
using ArtlyV1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtlyV1.Handlers
{
    public class ProductPageHandler
    {
        ArtlyDatabaseEntities db = DatabaseSingleton.getInstance();

        public List<MsProduct> getProducts()
        {
            List<MsProduct> results = (from products in db.MsProducts select products).ToList();
            return results;
        }

        public List<MsProduct> getProductsByCategory(String idProductCategory, String idProductType)
        {
            List<MsProduct> results = (from products in db.MsProducts
                                       where products.IdProductCategory == idProductCategory
                                       && products.IdProductType == idProductType
                                       select products).ToList();
            return results;

        }

        public List<MsProduct> getProductsBySearch(String searchQuery)
        {
            List<MsProduct> results = (from products in db.MsProducts
                                       where products.ProductName.Contains(searchQuery)
                                       select products).ToList();
            return results;
        }

        public List<LtProductCategory> getCategories()
        {
            List<LtProductCategory> results = (from category in db.LtProductCategories
                                               select category).ToList();
            return results;
        }

        public List<LtProductType> getTypes()
        {

            List<LtProductType> results = db.LtProductTypes.ToList();
            return results;
        }

        public List<MsProduct> getProductByFilter(string search, List<string> idProductCategory, List<string> idProductType)
        {
            List<MsProduct> results = db.MsProducts
                            .ToList();

            if (!String.IsNullOrEmpty(search))
                results = results.Where(x => x.ProductName.ToLower().Contains(search.ToLower())).ToList();

            if (idProductCategory.Count() > 0)
                results = results.Where(x => idProductCategory.Any(y => y == x.IdProductCategory)).ToList();

            if (idProductType.Count() > 0)
                results = results.Where(x => idProductType.Any(y => y == x.IdProductType)).ToList();


            return results;
        }
    }
}