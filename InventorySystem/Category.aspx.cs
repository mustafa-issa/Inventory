using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventorySystem
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
            
            CategoryClass C = new CategoryClass();
            DropDownList2.DataSource = C.ddl();
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("None",  "NULL"));
            DropDownList2.SelectedIndex = 0;
            return 0;
           
        }
        protected void AddCategorybtn_ServerClick(object sender, EventArgs e)
        {

           

            CategoryClass CAT = new CategoryClass();
            string Name = EnterName.Value;
            
            CAT.Name = Name;
            if (DropDownList2.SelectedValue != "NULL")
            {
              CAT.ParentId = Convert.ToInt32(DropDownList2.SelectedValue);  
            }
            
            CAT.Status = 0;
            CAT.InsertDate = DateTime.Now;
            CAT.InsertBy = Convert.ToInt32(Session["UserId"]);
            if (CAT.AddNewCategory()!=0)
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