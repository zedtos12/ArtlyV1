using ArtlyV1.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtlyV1.Views
{
    public partial class ProductDetail : System.Web.UI.Page
    {
        ProductDetailController detailController = new ProductDetailController();
        public String productName;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}