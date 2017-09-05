using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data; // Required for using Dataset , Datatable and Sql
using System.Data.SqlClient; // Required for Using Sql 
using System.Configuration; // for Using Connection From Web.config
using BussinessObject;  // for acessing bussiness object class

namespace DataAccess
{

    public class UserDA
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());


        public int AddUserDetails(UserBO ObjBO) // passing Bussiness object Here 
        {
            try
            {
                /* 
                 * Because We will put all out values from our (Signup.aspx) cont....
                 * To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess
                 */

                SqlCommand cmd = new SqlCommand("AddUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", ObjBO.UserName);
                cmd.Parameters.AddWithValue("@Password", ObjBO.Password);
                cmd.Parameters.AddWithValue("@Email", ObjBO.Email);
                cmd.Parameters.AddWithValue("@FullName", ObjBO.FullName);
                cmd.Parameters.AddWithValue("@Status", ObjBO.Status);
                cmd.Parameters.AddWithValue("@InsertDate", ObjBO.InsertDate);
                con.Open();
                int Result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                return Result;

            }
            catch
            {
                throw;
            }
            finally
            {

                con.Close();
                con.Dispose();
            }
        }

        public int SelectUser(UserBO ObjBO)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Users where UserName=@UserName AND Password=@Password";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@UserName", ObjBO.UserName);
            cmd.Parameters.AddWithValue("@Password",ObjBO.Password);
            cmd.Parameters.AddWithValue("@UserId",ObjBO.UserId);

            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            da.SelectCommand = cmd;

            try
            {
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    int r = Convert.ToInt32(dt.Rows[0]["UserId"]);
                    return r;
                }

                else
                    return 0;

            }
            catch
            {
                throw;
            }
            finally
            {

                da.Dispose();
                con.Close();
                con.Dispose();
            }




        }
    }
}
