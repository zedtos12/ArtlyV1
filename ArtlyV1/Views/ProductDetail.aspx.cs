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
        private List<CartItem> cartList;

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

            cartList = (List<CartItem>)Session["cart"];
        }

        private int findProductIndexInCart()
        {
            if(cartList == null)
            {
                return -1;
            }

            for(int i = 0; i < cartList.Count; i++)
            {
                if (cartList[i].product == product)
                {
                    return i;
                }
            }

            return -1;
        }

        public Boolean isProductInCart()
        {
            if(findProductIndexInCart() != -1)
            {
                return true;
            }

            return false;
        }

        private void alertError(String msg)
        {
            successBox.Visible = false;
            errorBox.Visible = true;
            errorLabel.Text = msg;
        }

        private void alertSuccess(String msg)
        {
            errorBox.Visible = false;
            successBox.Visible = true;
            successLabel.Text = msg;
        }

        protected void addCartButton_Click(object sender, EventArgs e)
        {
            if (cartList == null) cartList = new List<CartItem>();
            int qty = Int32.Parse(inputQuantity.Value);

            if(qty < 1)
            {
                alertError("Quantity is less than the minimum of 1!");
                return;
            }

            if (qty > productStock)
            {
                alertError("Quantity is more than the stock of product!");
                return;
            }

            CartItem cartItem = new CartItem(product, sellerName, qty);

            cartList.Add(cartItem);
            Session["cart"] = cartList;

            alertSuccess(String.Format("{0} '{1}' successfully added to your cart.", qty, productName));
         }

        protected void updateCartButton_Click(object sender, EventArgs e)
        {
            int index = findProductIndexInCart();

            if(index == -1)
            {
                return;
            }

            int qty = Int32.Parse(inputQuantity.Value);

            if (qty < 1)
            {
                alertError("Quantity is less than the minimum of 1!");
                return;
            }

            if (qty > productStock)
            {
                alertError("Quantity is more than the stock of product!");
                return;
            }

            cartList[index].qty = qty;

            alertSuccess(String.Format("'{0}' quantity of {1} successfully updated to your cart.", productName, qty));
        }
    }
}