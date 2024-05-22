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

        protected void Page_Load(object sender, EventArgs e)
        {
            cartList = (List<CartItem>)Session["cart"];

            if(cartList == null)
            {
                return;
            }

            foreach(CartItem item in cartList)
            {
                itemQty++;
            }

            cartItemRepeater.DataSource = cartList;
            cartItemRepeater.DataBind();
        }
    }
}