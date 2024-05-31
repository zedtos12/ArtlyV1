using ArtlyV1.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtlyV1.Views
{
    public partial class SellerDashboard : System.Web.UI.Page
    {
        SellerDashboardController sellerDashboardController = new SellerDashboardController();
        public int sales;
        public decimal revenue;
        public int products;

        public int salesToday;
        public decimal revenueToday;
        public int productsToday;

        protected void Page_Load(object sender, EventArgs e)
        {
            string sellerId = Session["user"].ToString();
            if (!IsPostBack)
            {
                sales = sellerDashboardController.getSellerSales(sellerId);
                revenue = sellerDashboardController.getSellerRevenue(sellerId);
                products = sellerDashboardController.getSellerProducts(sellerId);
                salesToday = sellerDashboardController.getSellerSalesToday(sellerId);
                revenueToday = sellerDashboardController.getSellerRevenueToday(sellerId);
                productsToday = sellerDashboardController.getSellerProductsToday(sellerId);

                RecentlyRPT.DataSource = sellerDashboardController.sellerDashboardResult_RecentSales(sellerId);
                RecentlyRPT.DataBind();
            }
        }
    }
}