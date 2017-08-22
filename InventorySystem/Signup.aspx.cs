using Bussinesslogic;
using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace InventorySystem
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void signupbtn_Click(object sender, EventArgs e)
        {


            UserBO sign = new UserBO();
            string UserName = exampleInputUN1.Value;
            string Email = Emailtxt.Value;
            string FullName = FN.Value;
            string Password = exampleInputPassword1.Value;
            //......

            MD5 md5Hash = MD5.Create();
            string hash = GetMd5Hash(md5Hash, Password);
            //.....

            sign.UserName = UserName;
            sign.Password = hash;
            sign.Email = Email;
            sign.FullName = FullName;
            sign.Status = 0;
            sign.InsertDate = DateTime.Now;
            UserBL objUBL = new UserBL();
            objUBL.SaveUserRegisrationBL(sign);
            //if (sign.checkUser())
            //{
            //    Label2.Text = "User alredy exists";
            //}
            //else if (sign.signin()!=0)
            //{
            //    Session["User"] = UserName;
            //    Response.Redirect("Products1.aspx");
            //}
            //else
            //{
            //    Label1.Text = "Error , Try Again";
            //}
            
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