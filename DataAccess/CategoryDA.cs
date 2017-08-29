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

              public int DeleteCategory(CategoryBO ObjBO)
              {
                  try
                  {
                      SqlCommand cmd = new SqlCommand("DeleteCategory", con);
                      cmd.CommandType = CommandType.StoredProcedure;

                      cmd.Parameters.AddWithValue("@CategoryId", ObjBO.CategoryId);
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

              public int UpdateCategory(CategoryBO ObjBO)
              {
                  try
                  {

                      SqlCommand cmd = new SqlCommand("UpdateCategory", con);
                      cmd.CommandType = CommandType.StoredProcedure;

                      cmd.Parameters.AddWithValue("@CategoryId", ObjBO.CategoryId);
                      cmd.Parameters.AddWithValue("@Name", ObjBO.Name);
                      cmd.Parameters.AddWithValue("@ParentId", ObjBO.ParentId);
                      cmd.Parameters.AddWithValue("@Status", ObjBO.Status);
                      cmd.Parameters.AddWithValue("@InsertDate", ObjBO.InsertDate);
                      cmd.Parameters.AddWithValue("@UpdateDate", ObjBO.UpdateDate);
                      cmd.Parameters.AddWithValue("@InsertBy", ObjBO.InsertBy);
                      cmd.Parameters.AddWithValue("@UpdateBy", ObjBO.UpdateBy);

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

              public DataTable RetrieveCategory(CategoryBO ObjBO)
              {
                  string str = "Select * from Category";
                  SqlDataAdapter da = new SqlDataAdapter(str, con);
                  da.SelectCommand.CommandType = CommandType.Text;
                  DataTable dt = new DataTable();

                  try
                  {
                      da.Fill(dt);
                      return dt;
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

              public DataTable DropDownListCategory(CategoryBO ObjBO)
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

