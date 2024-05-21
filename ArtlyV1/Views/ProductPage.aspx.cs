using ArtlyV1.Controllers;
using ArtlyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ArtlyV1.Views
{
    public partial class ProductPage : System.Web.UI.Page
    {
        public List<LtProductType> ListTypes = new List<LtProductType>();
        public List<LtProductCategory> ListCategories = new List<LtProductCategory>();
        public List<MsProduct> Products = new List<MsProduct>();

        string search;
        List<string> IdTypeCheckeds = new List<string>();
        List<string> IdCategoryCheckeds = new List<string>();

        ProductPageController productPageController = new ProductPageController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                search = searchBox.Text;

                ListTypes = productPageController.GetListType();
                ListCategories = productPageController.GetListCategories();
                
                TypeFilter.DataSource = ListTypes;
                TypeFilter.DataBind();

                CategoryFilter.DataSource = ListCategories;
                CategoryFilter.DataBind();

                RestoreCheckBoxState();
                RefreshProduct();
            }
        }

        protected void ApplyFilter_Click(object sender, EventArgs e)
        {
            search = searchBox.Text;
            IdTypeCheckeds = GetFilterType();
            IdCategoryCheckeds = GetFilterCategories();
            RefreshProduct();
        }

        protected void SearchBox_TextChanged(object sender, EventArgs e)
        {
            search = searchBox.Text;
            IdTypeCheckeds = GetFilterType();
            IdCategoryCheckeds = GetFilterCategories();
            RefreshProduct();
        }

        protected void RefreshProduct()
        {
            Products = productPageController.GetListProductByFilter(search, IdCategoryCheckeds, IdTypeCheckeds);
            ProductList.DataSource = Products;
            ProductList.DataBind();
        }

        protected List<string> GetFilterType()
        {
            IdTypeCheckeds = new List<string>();
            foreach (RepeaterItem item in TypeFilter.Items)
            {
                HtmlInputCheckBox rb = (HtmlInputCheckBox)item.FindControl("typeCheckboxID");
                if (rb != null)
                {
                    var isChecked = Request.Form[rb.UniqueID];

                    if (!String.IsNullOrEmpty(isChecked))
                    {
                        string idProductType = rb.Attributes["data-id"];
                        IdTypeCheckeds.Add(idProductType);
                    }
                }
            }
            return IdTypeCheckeds;
        }

        protected List<string> GetFilterCategories()
        {
            IdCategoryCheckeds = new List<string>();
            foreach (RepeaterItem item in CategoryFilter.Items)
            {
                HtmlInputCheckBox rb = (HtmlInputCheckBox)item.FindControl("categoryCheckboxID");
                if (rb != null)
                {

                    var isChecked = Request.Form[rb.UniqueID];
                    if (!String.IsNullOrEmpty(isChecked))
                    {
                        string idProductType = rb.Attributes["data-id"];
                        IdCategoryCheckeds.Add(idProductType);
                    }
                }
            }

            return IdCategoryCheckeds;
        }

        protected void SaveCheckedFilter()
        {
            IdTypeCheckeds = GetFilterType();
            IdCategoryCheckeds = GetFilterCategories();

            ViewState["SelectedTypes"] = IdTypeCheckeds;
            ViewState["SelectedCategories"] = IdCategoryCheckeds;
        }

        private void RestoreCheckBoxState()
        {
            if (ViewState["SelectedTypes"] != null)
            {
                List<string> selectedTypes = (List<string>)ViewState["SelectedTypes"];

                foreach (RepeaterItem item in TypeFilter.Items)
                {
                    HtmlInputCheckBox rb = (HtmlInputCheckBox)item.FindControl("typeCheckboxID");
                    if (rb != null && selectedTypes.Contains(rb.Attributes["data-id"]))
                    {
                        rb.Checked = true;
                    }
                }
            }

            if (ViewState["SelectedCategories"] != null)
            {
                List<string> selectedCategories = (List<string>)ViewState["SelectedCategories"];

                foreach (RepeaterItem item in CategoryFilter.Items)
                {
                    HtmlInputCheckBox rb = (HtmlInputCheckBox)item.FindControl("categoryCheckboxID");
                    if (rb != null && selectedCategories.Contains(rb.Attributes["data-id"]))
                    {
                        rb.Checked = true;
                    }
                }
            }
        }
    }
}