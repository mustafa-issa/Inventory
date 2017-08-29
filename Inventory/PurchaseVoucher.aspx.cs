using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bussinesslogic;
using BussinessObject;


namespace Inventory
{
    public partial class PurchaseVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VouchersBO ObjBO = new VouchersBO();
            VouchersBL ObjBL = new VouchersBL();
            inputNumber.Value = ObjBL.Generate_NoBL(ObjBO).ToString();
            if (!IsPostBack)
            {
                BindGridViewShowRecords();
            }

        }

        private void BindGridViewShowRecords()
        {

            GridView2.DataSource = GridViewShowRecords();
            GridView2.DataBind();


        }

        private DataTable GridViewShowRecords()
        {
            VouchersBO ObjBO = new VouchersBO();
            VouchersBL ObjBL = new VouchersBL();

            DataTable dt = new DataTable();
            dt.Columns.Add("Title");
            dt.Columns.Add("Price");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("TotalPrice");
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            return dt;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow GrdRow = (GridViewRow)btn.Parent.Parent;
            DropDownList Title = (DropDownList)GrdRow.Cells[0].FindControl("ddlTitle");
            TextBox Quantity = (TextBox)GrdRow.Cells[0].FindControl("txtQuantity");
            Label TotalPrice = (Label)GrdRow.Cells[0].FindControl("lblTotalPrice");

            VouchersBO ObjBO = new VouchersBO();
            ObjBO.Number = Convert.ToInt32(inputNumber.Value);
            ObjBO.Date = Convert.ToDateTime(txtFoo.Value);
            ObjBO.Title = Title.SelectedValue;

            ProductsBO ObjBO1 = new ProductsBO();
            ObjBO1.Quantity = Convert.ToInt32(Quantity.Text);

            ObjBO.TotalPrice = Convert.ToInt32(TotalPrice.Text);
            ObjBO.Status = 0;
            ObjBO.InsertDate = DateTime.Now;
            ObjBO.InsertBy = 1;
            VouchersBL ObjBL = new VouchersBL();
            ObjBL.InsertVouchersBL(ObjBO);
        }

        public DataTable ddl()
        {
            string ddl = "SELECT * FROM Products ";
            string mgr = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
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

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            DataRowView drv = e.Row.DataItem as DataRowView;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                DropDownList Title = (DropDownList)e.Row.FindControl("ddlTitle");
                Title.DataSource = ddl();
                Title.DataBind();
            }
        }

        protected void ddlTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList list = (DropDownList)sender;
            int x = int.Parse(list.SelectedValue);

            ProductsBO ObjBO2 = new ProductsBO();
            ObjBO2.ProductId = x;

            ProductsBL ObjBL1 = new ProductsBL();
            double y = ObjBL1.SelectPriceBL(ObjBO2); 

            Label Price = (Label)this.GridView2.Rows[0].FindControl("lblPrice");
            TextBox Qty = (TextBox)this.GridView2.Rows[0].FindControl("txtQuantity");
            Price.Text = y.ToString();
            Label Total = (Label)this.GridView2.Rows[0].FindControl("lblTotal");
            if(Qty.Text != "")
                Total.Text = (int.Parse(Qty.Text) * double.Parse(Price.Text)).ToString();
           
       }

        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            
            
            TextBox txtQuantity = (TextBox)sender;
            int x = Convert.ToInt32(txtQuantity.Text);
            Label Price = (Label)this.GridView2.Rows[0].FindControl("lblPrice");
            Label Total = (Label)this.GridView2.Rows[0].FindControl("lblTotal");
            double y = Convert.ToDouble(x)*Convert.ToDouble(Price.Text);
            Total.Text = y.ToString(); 
            
           } 
            
        
    }
}