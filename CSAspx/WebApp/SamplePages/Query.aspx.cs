
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


#region Additional Namespaces
using NorthwindSystem.BLL;
using Northwind.Data.Entities;
// use Manage NuGet Packages to add EntityFramework
// add the reference assembly System.Data.Entity
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;
#endregion

namespace WebApp.SamplePages
{
    public partial class Query : System.Web.UI.Page
    {
        List<string> errormsgs = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Message.DataSource = null;
            Message.DataBind();
            if (!Page.IsPostBack)
            {
                BindProductList();
                //TODO: Code the methods for these calls
                BindSupplierList();
                BindCategoryList();
            }
        }

        public void BindProductList()
        {
            try
            {
                CategoryController sysmgr = new CategoryController();
                List<Category> info = sysmgr.Products_List();
                info.Sort((x, y) => x.ProductName.CompareTo(y.ProductName));
                ProductList.DataSource = info;
                ProductList.DataTextField = nameof(Category.ProductName);
                ProductList.DataValueField = nameof(Category.ProductID);
                ProductList.DataBind();
                ProductList.Items.Insert(0, "select ...");
            }
            catch(Exception ex)
            {
                errormsgs.Add("File Error: " + GetInnerException(ex).Message);
                LoadMessageDisplay(errormsgs, "alert alert-warning");
            }
        }

        public void BindSupplierList()
        {
            //TODO: code the method to load the SupplierList control
            try
            {
                SupplierController sysmgr = new SupplierController();
                List<Supplier> info = sysmgr.Suppliers_List();
                info.Sort((x, y) => x.CompanyName.CompareTo(y.CompanyName));
                ProductList.DataSource = info;
                ProductList.DataTextField = nameof(Category.CompanyName);
                ProductList.DataValueField = nameof(Category.SupplierID);
                ProductList.DataBind();
                ProductList.Items.Insert(0, "select ...");
            }
            catch (Exception ex)
            {
                errormsgs.Add("File Error: " + GetInnerException(ex).Message);
                LoadMessageDisplay(errormsgs, "alert alert-warning");
            }
        }

        public void BindCategoryList()
        {
            //TODO: code the method to load the CategoryList control
            try
            {
                CategoryController sysmgr = new CategoryController();
                List<Category> info = sysmgr.Categories_List;
                info.Sort((x, y) => x.CategoryName.CompareTo(y.CategoryName));
                ProductList.DataSource = info;
                ProductList.DataTextField = nameof(Category.CategoryName);
                ProductList.DataValueField = nameof(Category.CategoryID);
                ProductList.DataBind();
                ProductList.Items.Insert(0, "select ...");
            }
            catch (Exception ex)
            {
                errormsgs.Add("File Error: " + GetInnerException(ex).Message);
                LoadMessageDisplay(errormsgs, "alert alert-warning");
            }
        }

        //use this method to discover the inner most error message.
        //this routine  has been created by the user
        protected Exception GetInnerException(Exception ex)
        {
            //drill down to the inner most exception
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }
        //use this method to load a DataList with a variable
        //number of message lines.
        //each line is a string
        //the strings (lines) are passed to this routine in
        //   a List<string>
        //second parameter is the bootstrap cssclass
        protected void LoadMessageDisplay(List<string> errormsglist, string cssclass)
        {
            Message.CssClass = cssclass;
            Message.DataSource = errormsglist;
            Message.DataBind();
        }

        protected void SearchProduct_Click(object sender, EventArgs e)
        {
            //TODO: code this method to lookup and display the selected product

            //do you have something to search for
            //the dropdownlist has a prompt line in index 0
            if (ProductList.SelectedIndex == 0)
            {
                errormsgs.Add("File Error: " + GetInnerException(ex).Message);
                LoadMessageDisplay(errormsgs, "alert alert-warning");
            }
            else
            {

            }
            //  user-friendly error handling
            try
            {
                //to use an object create an instance of the object
                CategoryController sysmgr = new CategoryController();

                //call the appropriate method within your instance
                Product info = sysmgr.Products_GetProduct(int.Parse(ProductList.SelectedValue));

                //check that a product is checked against null
                //single record data is checked against null
                //multirecord data is checked against .count
                if(info == null)
                {
                    //the product was not found
                    //message to the user
                    //refresh the incorrect dropdownlist to reflect the accurate current productlist
                    errormsgs.Add("Product was not found. Select and try again.");
                    LoadMessageDisplay(errormsgs, "alert alert-warning");
                    BindProductList();
                }
                else
                {
                    //product was found, display
                    ProductID.Text = info.ProductID.ToString();
                    ProductName.Text = info.ProductName;
                    SupplierList.SelectedValue = info.SupplierID == null ? "select....." : 
                                                info.SupplierID.ToString();
                    CategoryList.SelectedValue = info.CategoryID == null ? "select....." :
                                                info.CategoryID.ToString();
                    QuantityPerUnit.Text = info.QuantityPerUnit == null ? "" : info.QuantityPerUnit;
                    UnitPrice.Text = info.UnitPrice == null ? "" : string.Format("0:0.00"),
                    info.UnitPrice);
                    UnitsInStock.Text = info.UnitsInStock == null ? "" : info.UnitsInStock
                }
              
            }
            catch(Exception ex)
            {
                errormsgs.Add("File Error: " + GetInnerException(ex).Message);
                LoadMessageDisplay(errormsgs, "alert alert-warning");
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {

        }

        protected void Delete_Click(object sender, EventArgs e)
        {

        }

        protected void Update_Click(object sender, EventArgs e)
        {

        }

        protected void Add_Click(object sender, EventArgs e)
        {

        }
    }
}