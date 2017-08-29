using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;

namespace Inventory
{
    public class VoucherDetailsClass
    {
        string mgr = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        public int VoucherDetailId { get; set; }
        public int VoucherId { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int InsertBy { get; set; }
        public int UpdateBy { get; set; }


        public int addVouchersDetails()
        {
            SqlConnection con = new SqlConnection(mgr);
            con.Open();
            SqlCommand cmd = new SqlCommand("AddVoucherDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@VoucherId", VoucherId);
                cmd.Parameters.AddWithValue("@Quantity", Quantity);
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
        public int deleteVoucherDetails()
        {
            SqlConnection con = new SqlConnection(mgr);
            con.Open();
            SqlCommand cmd = new SqlCommand("DeleteVoucherDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@VoucherDetailId", VoucherDetailId);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
        public int updateVoucherDetails()
        {
            SqlConnection con = new SqlConnection(mgr);
            con.Open();
            SqlCommand cmd = new SqlCommand("UpdateVoucherDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@VoucherId", VoucherId);
                cmd.Parameters.AddWithValue("@Quantity", Quantity);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Parameters.AddWithValue("@UpdateDate", UpdateDate);
                cmd.Parameters.AddWithValue("@UpdateBy", UpdateBy);
                cmd.Parameters.AddWithValue("@VoucherDetailId", VoucherDetailId);


                return cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
        public DataTable RetrieveRecordsVouchersDetails()
        {
            string str = "Select * from VoucherDetails";
            SqlConnection con = new SqlConnection(mgr);
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
    }
}