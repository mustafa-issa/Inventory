using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace InventorySystem
{
    public class LinSupClass
    {
        string mgr = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;


        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public int Status { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }

       
public bool checkUser()
        {
            int result = 0;
    SqlConnection con = new SqlConnection(mgr);
    con.Open();
    SqlCommand cmd = new SqlCommand("select count(*) from [Users] where UserName = @UserName", con);
    cmd.Parameters.AddWithValue("UserName",UserName);
    result= (int)cmd.ExecuteScalar() ;
    con.Close();
    return result > 0;

        }

        public int signin()
        {

            if (! checkUser())
            {
                
            
            SqlConnection con = new SqlConnection(mgr);
           
            con.Open();
            SqlCommand cmd = new SqlCommand("AddUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@FullName", FullName);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Parameters.AddWithValue("@InsertDate", InsertDate);



                return cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw;
            }
             
            finally
            {
                con.Close();
            }

            }
            else
            {
                return 0;
            }

        }
        public int DeleteAcc()
        {
            SqlConnection con = new SqlConnection(mgr);
            con.Open();
            SqlCommand cmd = new SqlCommand("DeleteUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@UserId", UserId);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
                
            }
        }

        public int updateUserinfo()
        {
            SqlConnection con = new SqlConnection(mgr);
            con.Open();
            SqlCommand cmd = new SqlCommand("UpdateUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@FullName", FullName);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Parameters.AddWithValue("@UpdateDate", UpdateDate);
                cmd.Parameters.AddWithValue("@UserId", UserId);


                return cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
                
            }
        }

        public int login()
        {
            
            SqlConnection con = new SqlConnection(mgr);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Users where UserName=@UserName AND Password=@Password";
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("@UserName", UserName );
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@UserId", UserId);
            
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