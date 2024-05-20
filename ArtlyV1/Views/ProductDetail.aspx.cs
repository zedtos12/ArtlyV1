using ArtlyV1.Controllers;
using ArtlyV1.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtlyV1.Views
{
    public partial class ProductDetail : System.Web.UI.Page
    {
        ProductDetailController detailController = new ProductDetailController();
        ProductDetailHandler detailHandler = new ProductDetailHandler();
        public String productID;
        public String productName;
        public String sellerName;
        public String productImage;
        public String productDescription;
        public decimal productPrice;
        public int productStock;

        protected void Page_Load(object sender, EventArgs e)
        {
            //productID = Request["productID"];
            productID = "001CCA71-5CDD-4744-87D3-8D2F4E415C9F";

            if (productID == null)
            {
                Response.Redirect("~/Views/ProductPage.aspx");
            }

            if (detailController.isProductValid(productID) == false)
            {
                Response.Redirect("~/Views/ProductPage.aspx");
            }

            productName = detailHandler.getProductName(productID);
            sellerName = detailHandler.getSellerName(productID);
            productImage = detailHandler.getProductImage(productID);
            productDescription = detailHandler.getProductDescription(productID);
            productPrice = detailHandler.getProductPrice(productID);
            productStock = detailHandler.getProductStock(productID);
        }
    }
}