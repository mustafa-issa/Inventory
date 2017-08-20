using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace InventorySystem
{
    public partial class Products1 : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        double temp;
        string mgr = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!this.IsPostBack)
            {
                if (Session["User"] != null)
                {
                    Label1.Text = "Welcome " + Session["User"].ToString();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }

                BindGridViewShowRecords();
                DropDownList ddlCategory = GridView1.FooterRow.FindControl("ddlCategory") as DropDownList;
                ddlCategory.DataSource = ddl();
                ddlCategory.DataBind();
            }
        }

        private void BindGridViewShowRecords()
        {

            GridView1.DataSource = GridViewShowRecords();
            GridView1.DataBind();
        }
        private DataTable GridViewShowRecords()
        {
            ProductsClass pr = new ProductsClass();
            DataTable dt = new DataTable();

            dt = pr.RetrieveRecords();
            return dt;
        }


        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox ProductId = GridView1.Rows[e.RowIndex].FindControl("txtProductId") as TextBox;
            TextBox Title = GridView1.Rows[e.RowIndex].FindControl("txtTitle") as TextBox;
            TextBox Description = GridView1.Rows[e.RowIndex].FindControl("txtDesc") as TextBox;
            TextBox Price = GridView1.Rows[e.RowIndex].FindControl("txtPrice") as TextBox;
            TextBox Quantity = GridView1.Rows[e.RowIndex].FindControl("txtQuantity") as TextBox;
            TextBox Status = GridView1.Rows[e.RowIndex].FindControl("txtStatus") as TextBox;
            TextBox UpdateDate = GridView1.Rows[e.RowIndex].FindControl("txtUpdateDate") as TextBox;
         DropDownList ddlCategory = GridView1.Rows[e.RowIndex].FindControl("ddlCategory") as DropDownList;
 
            


            ProductsClass pp = new ProductsClass();
            pp.ProductId = Convert.ToInt32(ProductId.Text);


            pp.Title = Title.Text;
            pp.Description = Description.Text;
            pp.Price = Convert.ToDecimal(Price.Text);
            pp.UpdateDate = DateTime.Now;
            pp.CategoryId = Convert.ToInt32(ddlCategory.SelectedValue);
            pp.upddProduct();

            GridView1.EditIndex = -1;
            BindGridViewShowRecords();






        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            Label ProductId = GridView1.Rows[e.RowIndex].FindControl("lblProductId") as Label;
            int id = Convert.ToInt32(ProductId.Text);
            ProductsClass pp = new ProductsClass();
            pp.ProductId = id;
            pp.dltproduct();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGridViewShowRecords();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridViewShowRecords();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow GrdRow = (GridViewRow)btn.Parent.Parent;
            TextBox Title = (TextBox)GrdRow.Cells[0].FindControl("txtTitle");
            TextBox Description = (TextBox)GrdRow.Cells[0].FindControl("txtDesc");
            TextBox Price = (TextBox)GrdRow.Cells[0].FindControl("txtPrice");
            TextBox Quantity = (TextBox)GrdRow.Cells[0].FindControl("txtQuantity");
            TextBox Status = (TextBox)GrdRow.Cells[0].FindControl("txtStatus");
            TextBox InsertDate = (TextBox)GrdRow.Cells[0].FindControl("txtInsertDate");
            DropDownList CategoryId = (DropDownList)GrdRow.Cells[0].FindControl("ddlCategory") ;







            ProductsClass pp = new ProductsClass();

            if (double.TryParse(Price.Text, out temp))
            {
                pp.Price = Convert.ToDecimal(Price.Text);
            }





            pp.Title = Title.Text;
            pp.Description = Description.Text;

            pp.Quantity = Convert.ToInt32(Quantity.Text);
            pp.Status = 0;
            pp.InsertDate = DateTime.Now;
            pp.CategoryId = Convert.ToInt32(CategoryId.SelectedValue);



            pp.additems();

            GridView1.EditIndex = -1;
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
                GridView1.DataSource = sortedView;
                GridView1.DataBind();
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGridViewShowRecords();
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Category.aspx");
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