using ArtlyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtlyV1.Views
{
    public partial class ShoppingCartPage : System.Web.UI.Page
    {
        private List<CartItem> cartList;
        public int itemQty = 0;
        public decimal subtotalPrice = 0;
        public decimal tax = 0;
        public decimal totalPrice = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                refreshPage();
            }
        }

        private void refreshPage()
        {
            cartList = (List<CartItem>)Session["cart"];
            itemQty = 0;
            subtotalPrice = 0;

            if (cartList == null)
            {
                return;
            }

            foreach (CartItem item in cartList)
            {
                itemQty++;
                subtotalPrice += (item.qty * item.product.Price);
            }

            tax = subtotalPrice * 10 / 100;

            totalPrice = tax + subtotalPrice;

            cartItemRepeater.DataSource = cartList;
            cartItemRepeater.DataBind();
        }

        private CartItem findItem(String productID)
        {
            cartList = (List<CartItem>)Session["cart"];

            if (cartList == null)
            {
                return null;
            }

            foreach (CartItem item in cartList)
            {
                if (item.product.IdProduct == productID)
                {

                    return item;
                }
            }

            return null;
        }

        private void removeItem(CartItem item)
        {
            cartList = (List<CartItem>)Session["cart"];

            if (cartList == null)
            {
                return;
            }

            cartList.Remove(item);

            Session["cart"] = cartList;
            refreshPage();
        }

        protected void removeBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            String productID = btn.CommandArgument.ToString();

            CartItem item = findItem(productID);

            removeItem(item);
        }

        protected void decrementQtyBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            String productID = btn.CommandArgument.ToString();

            CartItem item = findItem(productID);

            if (item == null) return;

            if(item.qty <= 1)
            {
                removeItem(item);
            }

            item.qty--;
            refreshPage();
        }

        protected void incrementQtyBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            String productID = btn.CommandArgument.ToString();

            CartItem item = findItem(productID);

            if (item == null) return;

            if (item.qty >= item.product.Stock) {
                refreshPage();
                return;
            }

            item.qty++;
            refreshPage();
        }
    }
}