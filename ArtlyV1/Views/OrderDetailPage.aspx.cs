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
    public partial class OrderDetailPage : System.Web.UI.Page
    {
        OrderHistoryHandler orderHistoryHandler = new OrderHistoryHandler();
        string UserID;
        string TransactionID;
        List<TransactionDetail> orderDetails;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            UserID = Session["user"].ToString();
            TransactionID = Request.QueryString["transactionID"];

            if (TransactionID == null)
            {
                Response.Redirect("HomePage.aspx");
            }

            if (!orderHistoryHandler.verifyUserTransaction(UserID, TransactionID))
            {
                Response.Redirect("HomePage.aspx");
            }

            if (!IsPostBack)
            {
                OrderDetailGV.DataSource = orderDetails;
                OrderDetailGV.DataBind();
            }

            decimal total = 0;
            
            foreach (TransactionDetail orderDetail in orderDetails)
            {
                total += orderDetail.UnitPrice * orderDetail.Quantity;
            }

            TotalLabel.Text = total.ToString();
        }
    }
}