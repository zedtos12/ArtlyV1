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
    public partial class TransactionDetailPage : System.Web.UI.Page
    {
        TransactionDetailHandler handler = new TransactionDetailHandler();
        List<TransactionDetail> transactionDetailList;
        String transactionID;
        public int itemQty = 0;
        public decimal subtotalTransactionPrice = 0;
        public decimal tax;
        public decimal totalTransactionPrice;

        protected void Page_Load(object sender, EventArgs e)
        {
            transactionID = Request.QueryString["ID"];

            if (Session["user"] == null || transactionID == null)
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }

            if(!IsPostBack)
            {
                transactionDetailList = handler.getTransactionDetailList(transactionID);

                foreach(TransactionDetail transactionDetail in transactionDetailList)
                {
                    itemQty++;
                    subtotalTransactionPrice += (transactionDetail.UnitPrice * transactionDetail.Quantity);
                }

                tax = subtotalTransactionPrice * 10 / 100;
                totalTransactionPrice = subtotalTransactionPrice + tax;

                transactionDetailRepeater.DataSource = transactionDetailList;
                transactionDetailRepeater.DataBind();
            }
        }
    }
}