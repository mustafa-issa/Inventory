using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Bussinesslogic;
using BussinessObject;

namespace Inventory
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsignin_Click(object sender, EventArgs e)
        {
            {
                UserBO ObjBO = new UserBO();
                string Email = email.Value;
                string Password = password.Value;
               
                MD5 md5Hash = MD5.Create();
                string hash = GetMd5Hash(md5Hash, Password);

                ObjBO.Email = Email;
                ObjBO.Password = hash;

                UserBL ObjBL = new UserBL();
                if (ObjBL.SelectUserBL(ObjBO) > 0)
                {

                    Session["UserId"] = ObjBL.SelectUserBL(ObjBO);
                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    lblsignin.Text = "Wrong User/Password";

                }


            }
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}