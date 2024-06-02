using ArtlyV1.Controllers;
using ArtlyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtlyV1.Views
{
    public partial class PaymentPage : System.Web.UI.Page
    {
        PaymentController controller = new PaymentController();
        List<CartItem> cartList;
        List<TrUserAddress> addressList;
        String userID;
        public decimal total = 0;
        public decimal currentBalance = 0;
        public decimal resultingBalance;
        
        public Boolean isAllItemDigital()
        {
            cartList = (List<CartItem>)Session["cart"];

            if(cartList == null)
            {
                return true;
            }
            
            foreach(CartItem item in cartList)
            {
                if (item.product.LtProductType.ProductTypeName != "Digital")
                {
                    return false;
                }
            }

            return true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cart"] == null || Session["cartTotal"] == null)
            {
                Response.Redirect("~/Views/ShoppingCartPage.aspx");
            }

            if (Session["balance"] == null || Session["user"] == null)
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }

            total = decimal.Parse(Session["cartTotal"].ToString());
            currentBalance = decimal.Parse(Session["balance"].ToString());
            userID = Session["user"].ToString();

            resultingBalance = currentBalance - total;

            addressList = controller.getAddressList(userID);
            addressRepeater.DataSource = addressList;
            addressRepeater.DataBind();
        }

        protected void paymentBtn_Click(object sender, EventArgs e)
        {
            String msg;
            cartList = (List<CartItem>)Session["cart"];

            if (isAllItemDigital())
            {
                msg = controller.doPaymentWithoutShipping(userID, resultingBalance, cartList);
            }
            else
            {
                RadioButton addressRB = this.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.GroupName == "Address" && rb.Checked);
                String addressName = null;
                
                if(addressRB != null)
                {
                    addressName = addressRB.Attributes["Value"];
                }

                msg = controller.doPaymentWithShipping(userID, resultingBalance, cartList, addressName);
            }

            if (msg != "Successful")
            {
                alertBox.Visible = true;
                errorLabel.Text = msg;
                return;
            }

            alertBox.Visible = false;
            successBox.Visible = true;
            successLabel.Text = "Your payment has been successfully completed.";

            int delay = 3000;
            Thread.Sleep(delay);
            Response.Redirect("~/Views/HomePage.aspx");
        }
    }
}