using ArtlyV1.Controllers;
using ArtlyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtlyV1.Views
{
    public partial class PaymentPage : System.Web.UI.Page
    {
        PaymentController controller = new PaymentController();
        List<CartItem> cartList;
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
            if (Session["cartTotal"] != null)
            {
                total = decimal.Parse(Session["cartTotal"].ToString());
            }

            if (Session["balance"] != null)
            {
                currentBalance = decimal.Parse(Session["balance"].ToString());
            }

            resultingBalance = currentBalance - total;
        }

        protected void paymentBtn_Click(object sender, EventArgs e)
        {
            String userID = Session["user"].ToString();

            if(isAllItemDigital())
            {
                String msg = controller.doPaymentWithoutShipping(userID, resultingBalance);

                if(msg != "Successful")
                {
                    alertBox.Visible = true;
                    errorLabel.Text = msg;
                    return;
                }
            }
            else
            {
                String shippingAddress = shippingAddressTB.Text;
                String shippingCity = shippingCityTB.Text;
                String shippingCountry = shippingCountryTB.Text;
                String shippingZip = shippingZipTB.Text;

                String msg = controller.doPaymentWithShipping(userID, resultingBalance, shippingAddress, shippingCountry, shippingCity, shippingZip);
            }
        }
    }
}