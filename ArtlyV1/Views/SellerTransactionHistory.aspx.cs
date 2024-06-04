using ArtlyV1.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtlyV1.Views
{
    public partial class SellerTransactionHistory : System.Web.UI.Page
    {
        static string OnProcess = "On-Process";
        static string OnDelivery = "On-Delivery";
        static string Complete = "Complete";

        public string type;
        public string filter;
        public string typeName;

        SellerDashboardController sellerDashboardController = new SellerDashboardController();
        protected void Page_Load(object sender, EventArgs e)
        {
            string sellerId = Session["user"].ToString();
            type = Request.QueryString["Type"];
            filter = Request.QueryString["Filter"] == null ? "" : Request.QueryString["Filter"];

            if(type == "1")
            {
                DititalBTN.CssClass = "p-3 w-20 underline-box active";
                typeName = "Digital";
            }
            else
            {
                NonDigitalBTN.CssClass = "p-3 w-20 underline-box active";
                typeName = "Non-Digital";
            }

            if (!IsPostBack)
            {

                TransactionHistoryRPT.DataSource = sellerDashboardController.GetTransactionHistories(new Models.TransactionHistoryRequest
                {
                    IdUser = sellerId,
                    Type = type,
                    Filter = filter
                });
                TransactionHistoryRPT.DataBind();
                HlOnProcess.NavigateUrl = $"~/Views/SellerTransactionHistory.aspx?Type={type}&Filter={OnProcess}";
                HlOnDelivery.NavigateUrl = $"~/Views/SellerTransactionHistory.aspx?Type={type}&Filter={OnDelivery}";
                HlComplete.NavigateUrl = $"~/Views/SellerTransactionHistory.aspx?Type={type}&Filter={Complete}";

            }
        }

        protected void DititalBTN_Click(object sender, EventArgs e)
        {
            string url = "~/Views/SellerTransactionHistory.aspx?Type=1";
            Response.Redirect(url); 
        }

        protected void NonDigitalBTN_Click(object sender, EventArgs e)
        {
            string url = "~/Views/SellerTransactionHistory.aspx?Type=2";
            Response.Redirect(url); 
        }
    }
}