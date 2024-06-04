using ArtlyV1.Factories;
using ArtlyV1.Models;
using ArtlyV1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtlyV1.Handlers
{
    public class ProductHandler
    {

        ArtlyDatabaseEntities db = DatabaseSingleton.getInstance();

        public List<MsProduct> GetProductByUserId(string userId)
        {
            List<MsProduct> products = (from x in db.ActiveEntities<MsProduct>() where x.UserInput == userId select x).ToList();
            return products;
        }

        public List<MsProduct> GetProductByCategory(string categoryId)
        {
            List<MsProduct> products = (from x in db.ActiveEntities<MsProduct>() where x.IdProductCategory == categoryId select x).ToList();
            return products;
        }

        public List<MsProduct> GetProductByType(string typeId)
        {
            List<MsProduct> products = (from x in db.ActiveEntities<MsProduct>() where x.IdProductType == typeId select x).ToList();
            return products;
        }

        public List<MsProduct> GetAllProduct()
        {
            List<MsProduct> products = (from x in db.ActiveEntities<MsProduct>() select x).ToList();
            return products;
        }

        public MsProduct GetProductByProductId(string productId)
        {
            return (from x in db.ActiveEntities<MsProduct>() where x.IdProduct == productId select x).FirstOrDefault();
        }

        public void DisableProduct(string productId)
        {
            MsProduct product = GetProductByProductId(productId);
            product.IsActive = false;
            db.SaveChanges();
        }

        public void InsertProduct(string productID, string ProductName, string IdProductCategory, string IdProductType, string IdUser,
                                        decimal price, int stock, string description)
        {
            MsProduct product = ProductFactory.Create(productID, ProductName, IdProductCategory, IdProductType, IdUser, price, stock, description, "placeholder");
            db.MsProducts.Add(product);
            db.SaveChanges();
        }

        public void UpdateProductImage(String ProductID, String imageFilePath)
        {
            MsProduct product = (from x in db.ActiveEntities<MsProduct>() where x.IdProduct == ProductID select x).FirstOrDefault();
            product.ProductImage = imageFilePath;
            db.SaveChanges();
        }

        public void UpdateProduct(string IdProduct, string ProductName, string IdProductCategory, string IdProductType, string IdUser,
                                                   decimal price, int stock, string description, string ProductImage)
        {
            MsProduct product = GetProductByProductId(IdProduct);
            product.ProductName = ProductName;
            product.IdProductCategory = IdProductCategory;
            product.IdProductType = IdProductType;
            product.UserInput = IdUser;
            product.Price = price;
            product.Stock = stock;
            product.Description = description;
            product.ProductImage = ProductImage;
            db.SaveChanges();
        }

        public List<LtProductCategory> GetProductCategory()
        {
            return (from x in db.ActiveEntities<LtProductCategory>() select x).ToList();
        }

        public string GetProductCategoryIdByName(string categoryName)
        {
            return (from x in db.ActiveEntities<LtProductCategory>() where x.ProductCategoryName == categoryName select x.IdProductCategory).FirstOrDefault();
        }

        public List<LtProductType> GetProductType()
        {
            return (from x in db.ActiveEntities<LtProductType>() select x).ToList();
        }

       public string GetProductTypeIdByName(string typeName)
        {
            return (from x in db.ActiveEntities<LtProductType>() where x.ProductTypeName == typeName select x.IdProductType).FirstOrDefault();
        }

        public List<MsProduct> GetProductBySearch(string search)
        {
            List<MsProduct> products = (from x in db.ActiveEntities<MsProduct>() where x.ProductName.Contains(search) select x).ToList();
            return products;
        }

        public List<MsProduct> GetProductByPrice(decimal min, decimal max)
        {
            List<MsProduct> products = (from x in db.ActiveEntities<MsProduct>() where x.Price >= min && x.Price <= max select x).ToList();
            return products;
        }


    }
    

}