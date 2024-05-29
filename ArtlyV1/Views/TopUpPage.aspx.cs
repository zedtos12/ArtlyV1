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
    public partial class TopUpPage : System.Web.UI.Page
    {
        TopUpHandler handler = new TopUpHandler();
        String userID = null;
        decimal topUpBalance = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(topUpUserIDTB.Text == "")
            {
                userID = null;
            }
            else
            {
                userID = topUpUserIDTB.Text;
            }
        }

        public Boolean isUserFound()
        {
            if (userID == null) return false;
            return true;
        }
        public Boolean isTopUpBalanceValid()
        {
            if (topUpBalance <= 0) return false;
            return true;
        }

        protected void topUpUsernameTB_TextChanged(object sender, EventArgs e)
        {
            String username = topUpUsernameTB.Text;
            userID = handler.findUserID(username);

            if(!isUserFound())
            {
                topUpUserIDTB.Text = null;
                return;
            }

            topUpUserIDTB.Text = userID;
        }

        private void errorAlert(String msg)
        {
            successBox.Visible = false;
            alertBox.Visible = true;
            errorLabel.Text = msg;
        }

        protected void topUpBtn_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(topUpBalanceTB.Text, out topUpBalance))
            {
                topUpBalance = 0;
                errorAlert("Top up balance is not a valid decimal!");
                return;
            }

            if (!isTopUpBalanceValid())
            {
                errorAlert("Top up balance is less than or equal to 0!");
                return;
            }

            userID = topUpUserIDTB.Text;

            if(!isUserFound())
            {
                errorAlert("User not found!");
                return;
            }

            alertBox.Visible = false;
            successBox.Visible = true;
            successLabel.Text = String.Format("User with username {0} has been topped up with a balance of IDR {1}", topUpUsernameTB.Text, topUpBalance.ToString("#,##0.00"));
            handler.topUpUserBalance(userID, topUpBalance);
        }
    }
}