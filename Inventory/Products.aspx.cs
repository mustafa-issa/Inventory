using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using Bussinesslogic;
using BussinessObject;

namespace Inventory
{
    public partial class Products : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        double temp;

        string mgr = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
     
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {               
                BindGridViewShowRecords();                
            }
        }

        private void BindGridViewShowRecords()
        {

            grdProducts.DataSource = GridViewShowRecords();
            grdProducts.DataBind();
            DropDownList ddlCategory = grdProducts.FooterRow.FindControl("ddlCategory") as DropDownList;
            ddlCategory.DataSource = ddl();
            ddlCategory.DataBind();
        }

        public DataTable GridViewShowRecords()
        {

            DataTable dt = new DataTable();
            ProductsBL ObjBL = new ProductsBL();
            dt = ObjBL.RetrieveProductsBL();
            return dt;
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox ProductId = grdProducts.Rows[e.RowIndex].FindControl("txtProductId") as TextBox;
            TextBox tbTitle = grdProducts.Rows[e.RowIndex].FindControl("tbTitle") as TextBox;
            TextBox tbDescription = grdProducts.Rows[e.RowIndex].FindControl("tbDescription") as TextBox;
            TextBox tbPrice = grdProducts.Rows[e.RowIndex].FindControl("tbPrice") as TextBox;
            TextBox tbQuantity = grdProducts.Rows[e.RowIndex].FindControl("tbQuantity") as TextBox;
            TextBox tbStatus = grdProducts.Rows[e.RowIndex].FindControl("tbStatus") as TextBox;
            TextBox UpdateDate = grdProducts.Rows[e.RowIndex].FindControl("txtUpdateDate") as TextBox;
            DropDownList ddlCategory = grdProducts.Rows[e.RowIndex].FindControl("ddlCategory") as DropDownList;

            ProductsBO ObjBO = new ProductsBO();
            ObjBO.ProductId = Convert.ToInt32(ProductId.Text);
            ObjBO.Title = tbTitle.Text;
            ObjBO.Description = tbDescription.Text;
            ObjBO.Price = Convert.ToDecimal(tbPrice.Text);
            ObjBO.UpdateDate = DateTime.Now;
            ObjBO.CategoryId = Convert.ToInt32(ddlCategory.SelectedValue);

            ProductsBL ObjBL = new ProductsBL();
            ObjBL.UpdateProductsBL(ObjBO);

            grdProducts.EditIndex = -1;
            BindGridViewShowRecords();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            Label ProductId = grdProducts.Rows[e.RowIndex].FindControl("lblProductId") as Label;
            int id = Convert.ToInt32(ProductId.Text);

            ProductsBO ObjBO = new ProductsBO();
            ObjBO.ProductId = id;

            ProductsBL ObjBL = new ProductsBL();
            ObjBL.DeleteProductsBL(ObjBO);

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdProducts.EditIndex = e.NewEditIndex;
            BindGridViewShowRecords();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdProducts.EditIndex = -1;
            BindGridViewShowRecords();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            TextBox tbTitle = (TextBox)grdProducts.FooterRow.FindControl("tbTitle");
            TextBox tbDescription = (TextBox)grdProducts.FooterRow.FindControl("tbDescription");
            TextBox tbPrice = (TextBox)grdProducts.FooterRow.FindControl("tbPrice");
            TextBox tbQuantity = (TextBox)grdProducts.FooterRow.FindControl("tbQuantity");
            TextBox tbStatus = (TextBox)grdProducts.FooterRow.FindControl("tbStatus");
            TextBox InsertDate = (TextBox)grdProducts.FooterRow.FindControl("txtInsertDate");
            DropDownList ddlCategory = (DropDownList)grdProducts.FooterRow.FindControl("ddlCategory");



            ProductsBO ObjBO = new ProductsBO();

            if (double.TryParse(tbPrice.Text,out temp))
            {
                ObjBO.Price = Convert.ToDecimal(tbPrice.Text);
            }
            ObjBO.Title = tbTitle.Text;
            ObjBO.Description = tbDescription.Text;
            ObjBO.Quantity = Convert.ToInt32(tbQuantity.Text);
            ObjBO.Status = 0;
            ObjBO.InsertDate = DateTime.Now;
            ObjBO.CategoryId = Convert.ToInt32(ddlCategory.SelectedValue);

            ProductsBL ObjBL = new ProductsBL();
            ObjBL.InsertProductsBL(ObjBO);

            grdProducts.EditIndex = -1;
            BindGridViewShowRecords();
        }

        public string price { get; set; }

        public SortDirection dir
        {
            get
            {
                if (ViewState["dirState"] == null)
                {
                    ViewState["dirState"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["dirState"];
            }
            set
            {
                ViewState["dirState"] = value;
            }

        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {

            BindGridViewShowRecords();
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            {
                string SortDir = string.Empty;
                if (dir == SortDirection.Ascending)
                {
                    dir = SortDirection.Descending;
                    SortDir = "Desc";
                }
                else
                {
                    dir = SortDirection.Ascending;
                    SortDir = "Asc";
                }
                DataView sortedView = new DataView(dt);
                sortedView.Sort = e.SortExpression + " " + SortDir;
                grdProducts.DataSource = sortedView;
                grdProducts.DataBind();
            }
        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdProducts.PageIndex = e.NewPageIndex;
            BindGridViewShowRecords();
        }

        public DataTable ddl()
        {
            string ddl = "select * from Category ";
            SqlConnection con = new SqlConnection(mgr);
            SqlCommand cmd = new SqlCommand(ddl, con);

            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            con.Open();
            sda.Fill(dt);
            con.Close();
            return dt;


        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataRowView drv = e.Row.DataItem as DataRowView;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList ddlCategory = (DropDownList)e.Row.FindControl("ddlCategory");
                    ddlCategory.DataSource = ddl();
                    ddlCategory.DataBind();

                }
            }
        }
    }
}