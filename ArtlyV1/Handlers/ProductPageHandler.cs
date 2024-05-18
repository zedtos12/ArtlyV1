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

        private List<MsProduct> getProducts()
        {
            using (db)
            {
                List<MsProduct> results = (from products in db.MsProducts select products).ToList();
                return results;
            }
        }

        private List<MsProduct> getProductsByCategory(String idProductCategory, String idProductType)
        {
            using (db) 
            { 
                List<MsProduct> results = (from products in db.MsProducts 
                              where products.IdProductCategory == idProductCategory
                              && products.IdProductType == idProductType
                              select products).ToList();
                return results;
            }

        }

        private List<MsProduct> getProductsBySearch(String searchQuery)
        {
            using (db) 
            {
                List<MsProduct> results = (from products in db.MsProducts
                                           where products.ProductName.Contains(searchQuery)
                                           select products).ToList();
                return results;
            }
        }

        private List<LtProductCategory> getCategories()
        {
            using (db)
            {
                List<LtProductCategory> results = (from category in db.LtProductCategories
                                                   select category).ToList();
                return results;
            }
        }

        private List<LtProductType> getTypes()
        {
            using (db)
            {
                List<LtProductType> results = (from type in db.LtProductTypes
                                                   select type).ToList();
                return results;
            }
        }
    }
}