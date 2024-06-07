using ArtlyV1.Controllers;
using ArtlyV1.Handlers;
using ArtlyV1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtlyV1.Views
{
    public partial class UpdateProductPage : System.Web.UI.Page
    {
        ProductHandler productHandler = new ProductHandler();
        ProductPageController productPageController = new ProductPageController();
        protected void Page_Load(object sender, EventArgs e)
        {
            var productID = Request.QueryString["productId"];

            MsProduct product = productHandler.GetProductByProductId(productID);

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

                productImage.ImageUrl = product.ProductImage;
                productName.Text = product.ProductName;
                productDescription.Text = product.Description;
                productPrice.Text = product.Price.ToString();
                productStock.Text = product.Stock.ToString();
                ddlCategory.SelectedValue = product.IdProductCategory;
                typeList.SelectedValue = product.IdProductType;
            }
        }
        protected void UpdateProductBtn_Click(object sender, EventArgs e)
        {
            String productCategory = ddlCategory.SelectedValue;
            String productType = typeList.SelectedValue;
            decimal price;
            int stock;
            if (productName.Text == null || productName.Text == "")
            {
                ErrorLabel.Text = "Product Name cannot be empty";
                return;
            }
            if (productDescription.Text == null || productDescription.Text == "")
            {
                ErrorLabel.Text = "Product Description cannot be empty";
                return;
            }
            if (productPrice.Text == null || productPrice.Text == "")
            {
                ErrorLabel.Text = "Product Price cannot be empty";
                return;
            }
            if (!decimal.TryParse(productPrice.Text, out price))
            {
                ErrorLabel.Text = "Product Price must be a decimal";
                return;
            }
            if (productStock.Text == null || productStock.Text == "")
            {
                ErrorLabel.Text = "Product Stock cannot be empty";
                return;
            }
            if (!int.TryParse(productStock.Text, out stock))
            {
                ErrorLabel.Text = "Product Stock must be an integer";
                return;
            }
            if (productCategory == null)
            {
                ErrorLabel.Text = "Product Category must be selected";
                return;
            }

            if (productType == "")
            {
                ErrorLabel.Text = "Product Type must be selected";
                return;
            }

            String productID = Request.QueryString["productId"];

            if (productImageUpload.HasFile)
            {

                String uploadImageFileExtension = Path.GetExtension(productImageUpload.FileName);
                String imageFilePath = "Images/Product/Product-" + productID + uploadImageFileExtension;
                productImageUpload.SaveAs(Server.MapPath("~/Views/Images/Product/") + "Product-" + productID + uploadImageFileExtension);
                productHandler.UpdateProduct(productID, productName.Text, productCategory, productType, Session["user"].ToString(), price, stock, productDescription.Text, imageFilePath);

                Response.Redirect("ProductSeller.aspx");
            }
            else
            {
                productHandler.UpdateProduct(productID, productName.Text, productCategory, productType, Session["user"].ToString(), price, stock, productDescription.Text, productImage.ImageUrl);
                Response.Redirect("ProductSeller.aspx");
            }
        }
    }
}