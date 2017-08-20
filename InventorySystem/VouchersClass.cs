using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;

namespace InventorySystem
{
    public class VouchersClass
    {
        string mgr = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        public int VoucherId { get; set; }
        public int Number { get; set; }
        public int Type { get; set; }
        public DateTime Date { get; set; }
        public float TotalPrice { get; set; }
        public int Status { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int InsertBy { get; set; }
        public int UpdateBy { get; set; }

        public string Title { get; set; }
        public int ProductId { get; set; }

        public int addVouchers()
        {
            SqlConnection con = new SqlConnection(mgr);
        con.Open();
        SqlCommand cmd = new SqlCommand("AddVouchers", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Number", Number);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@TotalPrice", TotalPrice);
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

        public int deleteVoucher()
        {
            SqlConnection con = new SqlConnection(mgr);
            con.Open();
            SqlCommand cmd = new SqlCommand("DeleteVouchers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@VoucherId", VoucherId);
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

        public int updateVoucher()
        {
            SqlConnection con = new SqlConnection(mgr);
            con.Open();
            SqlCommand cmd = new SqlCommand("UpdateVouchers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@Number", Number);
                cmd.Parameters.AddWithValue("@Type", Type);
                cmd.Parameters.AddWithValue("@Date", Date);
                cmd.Parameters.AddWithValue("@TotalPrice", TotalPrice);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Parameters.AddWithValue("@UpdateDate", UpdateDate);
                cmd.Parameters.AddWithValue("@UpdateBy", UpdateBy);
                cmd.Parameters.AddWithValue("@VoucherId", VoucherId);


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

        public DataTable RetrieveRecordsVouchers()
        {
            string str = "Select Products.Title,Products.Price,((Products.Quantity+VoucherDetails.Quantity)*Price) As Total from Products Inner join VoucherDetails on Products.ProductId=VoucherDetails.ProductId Inner join Vouchers on Vouchers.VoucherId=VoucherDetails.VoucherId ";
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



        public string generate_no()
        {

            
            SqlConnection con = new SqlConnection(mgr);  
            string str = "select MAX(VoucherId)  from Vouchers ";
            SqlCommand cmd = new SqlCommand(str,con);
            con.Open();
            int result = 0;
            result = (int)cmd.ExecuteScalar();
           
            return result.ToString("D3") ;
        }












    }
}