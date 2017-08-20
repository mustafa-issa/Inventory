using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace InventorySystem
{
    public class CategoryClass
    {
        string mgr = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;


        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public int Status { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int InsertBy { get; set; }
        public int UpdayeBy { get; set; }

        public DataTable ddl()
        {
            string ddl = "select * from Category where ParentId is null";
            SqlConnection con = new SqlConnection(mgr);
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

        public int AddNewCategory()
        {
            SqlConnection con = new SqlConnection(mgr);

            con.Open();
            SqlCommand cmd = new SqlCommand("AddCategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@ParentId", ParentId == null ? (Object)DBNull.Value : ParentId);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Parameters.AddWithValue("@InsertDate", InsertDate);
                cmd.Parameters.AddWithValue("@InsertBy", InsertBy);
                



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
    }
}