using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtlyV1.Views
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String[] files = Directory.GetFiles(Server.MapPath("~/Views/Images/HomePage/TopSeller"));
            List<String> images = new List<String>(files.Count());

            foreach(String file in files)
            {
                images.Add(String.Format("~/Views/Images/HomePage/TopSeller/{0}", System.IO.Path.GetFileName(file)));
            }

            topSellerRepeater.DataSource = images;
            topSellerRepeater.DataBind();
        }

        protected void getStartedBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/RegisterPage.aspx");
        }
    }
}