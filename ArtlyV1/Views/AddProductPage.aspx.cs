using ArtlyV1.Controllers;
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
    public partial class AddProductPage : System.Web.UI.Page
    {
        ProductPageController productPageController = new ProductPageController();
        ProductHandler productHandler = new ProductHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            var TypeList = productPageController.GetListType();
            var CategoryList = productPageController.GetListCategories();

            List<ListItem> RBList = new List<ListItem>();
            List<ListItem> categorys = new List<ListItem>();

            foreach (var gender in TypeList)
            {
                ListItem RB = new ListItem()
                {
                    Value = gender.IdProductType,
                    Text = gender.ProductTypeName
                };

                RBList.Add(RB);
            }

            foreach (var category in CategoryList)
            {
                ListItem cat = new ListItem()
                {
                    Value = category.IdProductCategory,
                    Text = category.ProductCategoryName
                };

                categorys.Add(cat);
            }

            if (!IsPostBack)
            {
                typeList.DataValueField = "Value";
                typeList.DataTextField = "Text";
                typeList.DataSource = RBList;
                typeList.DataBind();

                ddlCategory.DataValueField = "Value";
                ddlCategory.DataTextField = "Text";
                ddlCategory.DataSource = categorys;
                ddlCategory.DataBind();
            }
        }

        protected void addProductBtn_Click(object sender, EventArgs e)
        {

            bool check = false;

            if (productName.Text == null || productName.Text == "")
            {
                ErrorLabel.Text = "Product Name cannot be empty";
                check = true;
            }
            if (productDescription.Text == null || productDescription.Text == "")
            {
                ErrorLabel.Text = "Product Description cannot be empty";
                check = true;
            }
            if (productPrice.Text == null || productPrice.Text == "")
            {
                ErrorLabel.Text = "Product Price cannot be empty";
                check = true;
            }
            if (productStock.Text == null || productStock.Text == "")
            {
                ErrorLabel.Text = "Product Stock cannot be empty";
                check = true;
            }

            if (!check)
            {
                var productCategory = ddlCategory.SelectedValue;
                var productType = typeList.SelectedValue;

                if (this.productImageUpload.HasFile)
                {
                    String imageFilePath = "Images/Product/" + this.productImageUpload.FileName;
                    this.productImageUpload.SaveAs(Server.MapPath("~/Views/Images/Product/") + this.productImageUpload.FileName);
                    productHandler.InsertProduct(productName.Text, productCategory, productType, Session["user"].ToString(), decimal.Parse(productPrice.Text), int.Parse(productPrice.Text), productDescription.Text, imageFilePath);
                    Response.Redirect("ProductSeller.aspx");
                }
                ErrorLabel.Text = "Please upload an image";
            }
            else
            {
                ErrorLabel.DataBind();
            }
        }
    }
}