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
	public partial class ProductSeller : System.Web.UI.Page
	{
        SellerDashboardController sellerDashboardController = new SellerDashboardController();	
        protected void Page_Load(object sender, EventArgs e)
		{
            string sellerId = Session["user"].ToString();

            if (!IsPostBack)
            {
                List<MsProduct> products = sellerDashboardController.getListProductByUserId(sellerId);
                ProductRPT.DataSource = products;
                ProductRPT.DataBind();
            }
        }
        protected void Product_Command(object sender, CommandEventArgs e)
        {
            string sellerId = Session["user"].ToString();
            string productId = e.CommandArgument.ToString();

            if (e.CommandName == "Delete")
            {
                sellerDashboardController.DisableProduct(productId);
                List<MsProduct> products = sellerDashboardController.getListProductByUserId(sellerId);
                ProductRPT.DataSource = products;
                ProductRPT.DataBind();

            }
            else if (e.CommandName == "Update")
            {
                Response.Redirect("UpdateProductPage.aspx?productId=" + productId);
            }
        }
    }
}