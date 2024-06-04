using ArtlyV1.Handlers;
using ArtlyV1.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtlyV1.Views
{
    public partial class OrderHistoryPage : System.Web.UI.Page
    {
        OrderHistoryHandler orderHistoryHandler = new OrderHistoryHandler();
        List<MsTransaction> orders; 
        string userId;

        protected void Page_Load(object sender, EventArgs e)
        {
            userId = Session["user"].ToString();
            orders = orderHistoryHandler.findOrdersByUserID(userId);


            if (!IsPostBack)
            {
                OrderHistoryGV.DataSource = orders;
                OrderHistoryGV.DataBind();
            }
        }

        protected void OrderHistoryGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow GVR = OrderHistoryGV.Rows[index];
            int id = Convert.ToInt32(GVR.Cells[0].Text);
            Response.Redirect("OrderDetailPage.aspx?transactionID=" + id);
        }
    }
}