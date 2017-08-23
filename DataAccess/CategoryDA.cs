using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BussinessObject;

namespace DataAccess
{
   public class CategoryDA
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());

              public int AddCategory(CategoryBO ObjBO)
              {
                 try
                     {

                SqlCommand cmd = new SqlCommand("AddCategory",con);
                cmd.CommandType = CommandType.StoredProcedure;

              
                cmd.Parameters.AddWithValue("@Name",ObjBO.Name);
                cmd.Parameters.AddWithValue("@ParentId",ObjBO.ParentId == null ? (Object)DBNull.Value : ObjBO.ParentId);
                cmd.Parameters.AddWithValue("@Status",ObjBO.Status);
                cmd.Parameters.AddWithValue("@InsertDate",ObjBO.InsertDate);
                cmd.Parameters.AddWithValue("@InsertBy",ObjBO.InsertBy);
                
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


              public DataTable DropDownList(CategoryBO ObjBO)
              {
                  string ddl = "select * from Category where ParentId is null";
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
        }
    }

