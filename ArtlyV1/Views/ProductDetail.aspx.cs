using ArtlyV1.Controllers;
using ArtlyV1.Handlers;
using ArtlyV1.Models;
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
        private String productID;
        private MsProduct product;
        public String productName;
        public String sellerName;
        public String productImage;
        public String productDescription;
        public decimal productPrice;
        public int productStock;

        protected void Page_Load(object sender, EventArgs e)
        {
            //productID = Request["productID"];
            productID = Request.QueryString["ID"];

            if (productID == null)
            {
                Response.Redirect("~/Views/ProductPage.aspx");
            }

            if (detailController.isProductValid(productID) == false)
            {
                Response.Redirect("~/Views/ProductPage.aspx");
            }

            product = detailHandler.getProduct(productID);

            productName = product.ProductName;
            sellerName = detailHandler.getSellerName(productID);
            productImage = product.ProductImage;
            productDescription = product.Description;
            productPrice = product.Price;
            productStock = product.Stock;
        }

        protected void addCartButton_Click(object sender, EventArgs e)
        {
            List<CartItem> cartList = (List<CartItem>)Session["cart"];
            if (cartList == null) cartList = new List<CartItem>();
            int qty = Int32.Parse(inputQuantity.Value);

            CartItem cartItem = new CartItem(product, sellerName, qty);

            cartList.Add(cartItem);
            Session["cart"] = cartList;

            successBox.Visible = true;
            successLabel.Text = String.Format("{0} '{1}' successfully added to your cart.", qty, productName);
         }
    }
}