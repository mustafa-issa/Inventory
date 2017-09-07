using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bussinesslogic;
using BussinessObject;


namespace Inventory
{
    public partial class Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    Label2.Text = "Welcome " + Session["User"].ToString();
                    ddlshowrec();
                }
                else
                {
                    Response.Redirect("Login.aspx");

                }
            }
        }


          private int ddlshowrec()
            {

            CategoryBO ObjBO = new CategoryBO();
            CategoryBL ObjBL = new CategoryBL();

            DropDownList2.DataSource = ObjBL.DropDownLIstBL();
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("None","NULL"));
            DropDownList2.SelectedIndex = 0;
            return 0;
           
        }


        protected void AddCategorybtn_ServerClick(object sender, EventArgs e)
        {
            CategoryBO ObjBO = new CategoryBO();
            string Name = EnterName.Value;
            ObjBO.Name = Name;
            if (DropDownList2.SelectedValue != "NULL")
            {
                ObjBO.ParentId = Convert.ToInt32(DropDownList2.SelectedValue);  
            }
            ObjBO.Status = 0;
            ObjBO.InsertDate = DateTime.Now;
            ObjBO.InsertBy = Convert.ToInt32(Session["UserId"]);

            CategoryBL ObjBL = new CategoryBL();
            if (ObjBL.InsertCategoryBL(ObjBO) != 0)
            {
                Label1.Text = "New Category was added successfully";
            }
            else
            {
                Label1.Text = "Error while adding , please try again later";
            }

            
        }
    }
}