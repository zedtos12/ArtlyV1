using ArtlyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtlyV1.Factories
{
    public class ProductFactory
    {
        public static MsProduct Create(string ProductName, string IdProductCategory, string IdProductType, string IdUser, 
                                        decimal price, int stock, string description, string ProductImage)
        {
            MsProduct product = new MsProduct();
            product.IdProduct = Guid.NewGuid().ToString();
            product.ProductName = ProductName;
            product.IdProductCategory = IdProductCategory;
            product.IdProductType = IdProductType;
            product.Price = price;
            product.Stock = stock;
            product.IsActive = true;
            product.DateCreated = DateTime.Now;
            product.Description = description;
            product.ProductImage = ProductImage;
            product.UserInput = IdUser;
            return product;
        }
    }
}