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

                SqlCommand cmd = new SqlCommand("AddCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", ObjBO.Name);
                cmd.Parameters.AddWithValue("@ParentId", ObjBO.ParentId == null ? (Object)DBNull.Value : ObjBO.ParentId);
                cmd.Parameters.AddWithValue("@Status", ObjBO.Status);
                cmd.Parameters.AddWithValue("@InsertDate", ObjBO.InsertDate);
                cmd.Parameters.AddWithValue("@InsertBy", ObjBO.InsertBy);
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

        public int DeleteCategory(int CategoryId)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DeleteCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CategoryId",CategoryId);
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

        public List<CategoryBO> RetrieveCategory()
        {
            List<CategoryBO> Categories = new List<CategoryBO>();

            string str = "Select * from Category";
            SqlCommand command = new SqlCommand(str, con);
            if (con.State != ConnectionState.Open)
                con.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                CategoryBO ObjBO = new CategoryBO();
                ObjBO.CategoryId = int.Parse(reader["CategoryId"].ToString());
                ObjBO.Name = reader["Name"].ToString();

                if (reader["ParentId"] == System.DBNull.Value)
                    ObjBO.ParentId = null;
                else
                ObjBO.ParentId = Int32.Parse(reader["ParentId"].ToString());
                //ObjBO.ParentId = (reader["ParentId"] == System.DBNull.Value ? null : Int32.Parse(reader["ParentId"].ToString()));
                ObjBO.Status = int.Parse(reader["Status"].ToString());
                ObjBO.InsertDate = DateTime.Parse(reader["InsertDate"].ToString());

                if (reader["UpdateDate"] == System.DBNull.Value)
                    ObjBO.UpdateDate = null;
                else
                    ObjBO.UpdateDate = DateTime.Parse(reader["UpdateDate"].ToString());

     
                ObjBO.InsertBy = int.Parse(reader["InsertBy"].ToString());

                if (reader["UpdateBy"] == System.DBNull.Value)
                    ObjBO.UpdateBy = null;
                else
                    ObjBO.UpdateBy = Int32.Parse(reader["UpdateBy"].ToString());


                Categories.Add(ObjBO);
            }

            try
            {
                return Categories;
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

        public CategoryBO SelectOne(int Id)
        {

            string str = "Select * from Category where CategoryId=@CategoryId";
            SqlCommand command = new SqlCommand(str, con);
            if (con.State != ConnectionState.Open)
             con.Open();
            SqlDataReader reader = command.ExecuteReader();
            CategoryBO ObjBO = new CategoryBO();
            while (reader.Read())
            {
                
                ObjBO.CategoryId = int.Parse(reader["CategoryId"].ToString());
                ObjBO.Name = reader["Name"].ToString();
                if (reader["ParentId"] == System.DBNull.Value)
                    ObjBO.ParentId = null;
                else
                    ObjBO.ParentId = Int32.Parse(reader["ParentId"].ToString());
                ObjBO.Status = int.Parse(reader["Status"].ToString());
                ObjBO.InsertDate = DateTime.Parse(reader["InsertDate"].ToString());
                if (reader["UpdateDate"] == System.DBNull.Value)
                    ObjBO.UpdateDate = null;
                else
                 ObjBO.UpdateDate = DateTime.Parse(reader["UpdateDate"].ToString());
                ObjBO.InsertBy = int.Parse(reader["InsertBy"].ToString());

                if (reader["UpdateBy"] == System.DBNull.Value)
                    ObjBO.UpdateBy = null;
                else
                    ObjBO.UpdateBy = Int32.Parse(reader["UpdateBy"].ToString());
            }

            try
            {
                return ObjBO;
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

        public List<CategoryBO> GetParentCategories()
        {

            List<CategoryBO> ddlCategories = new List<CategoryBO>();
            string ddl = "select * from Category where ParentId is null";
            SqlCommand command = new SqlCommand(ddl, con);
            if (con.State != ConnectionState.Open)
                con.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                CategoryBO ObjBO = new CategoryBO();
                ObjBO.CategoryId = int.Parse(reader["CategoryId"].ToString());
                ObjBO.Name = reader["Name"].ToString();

                if (reader["ParentId"] == System.DBNull.Value)
                    ObjBO.ParentId = null;
                else
                ObjBO.Status = int.Parse(reader["Status"].ToString());
                ObjBO.InsertDate = DateTime.Parse(reader["InsertDate"].ToString());
                if (reader["UpdateDate"] == System.DBNull.Value)
                    ObjBO.UpdateDate = null;
                else
                    ObjBO.UpdateDate = DateTime.Parse(reader["UpdateDate"].ToString());
                ObjBO.InsertBy = int.Parse(reader["InsertBy"].ToString());

                if (reader["UpdateBy"] == System.DBNull.Value)
                    ObjBO.UpdateBy = null;
                else
                    ObjBO.UpdateBy = Int32.Parse(reader["UpdateBy"].ToString());

                ddlCategories.Add(ObjBO);
            }

            try
            {
                return ddlCategories;
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
    }
}