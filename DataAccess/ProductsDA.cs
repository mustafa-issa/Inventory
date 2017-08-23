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
    public class ProductsDA
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());

        public int AddProducts(ProductsBO ObjBO)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("Add", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", ObjBO.Title);
                cmd.Parameters.AddWithValue("@Description", ObjBO.Description);
                cmd.Parameters.AddWithValue("@Price", ObjBO.Price);
                cmd.Parameters.AddWithValue("@Quantity", ObjBO.Quantity);
                cmd.Parameters.AddWithValue("@Status", ObjBO.Status);
                cmd.Parameters.AddWithValue("@InsertDate", ObjBO.InsertDate);
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

        public int DeleteProducts(ProductsBO Obj2BO)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductId", Obj2BO.ProductId);
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

        public int UpdateProducts(ProductsBO Obj3BO)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("Upd", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", Obj3BO.Title);
                cmd.Parameters.AddWithValue("@Description", Obj3BO.Description);
                cmd.Parameters.AddWithValue("@Price", Obj3BO.Price);
                cmd.Parameters.AddWithValue("@Quantity", Obj3BO.Quantity);
                cmd.Parameters.AddWithValue("@Status", Obj3BO.Status);
                cmd.Parameters.AddWithValue("@UpdateDate", Obj3BO.UpdateDate);
                cmd.Parameters.AddWithValue("@ProductId", Obj3BO.ProductId);
                cmd.Parameters.AddWithValue("@CategoryId", Obj3BO.CategoryId);

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

        public DataTable RetrieveRecords(ProductsBO ObjBO)
        {

            string str = "Select Products.*,Category.Name from Products INNER JOIN Category ON Products.CategoryId=Category.CategoryId ";
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

        public double SelectPrice(ProductsBO ObjBO)
        {

            string str = "Select Price from Products where ProductId=@ProductId  ";
            SqlCommand cmd = new SqlCommand(str, con);

            cmd.Parameters.AddWithValue("@ProductId", ObjBO.ProductId);
            SqlDataAdapter da = new SqlDataAdapter();
            con.Open();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {
                double r = double.Parse(dt.Rows[0]["Price"].ToString());
                return r;
            }

            else
                return 0;
        }


    }
}


   
