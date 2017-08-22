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
   public class VoucherDetailsDA
    {
       SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());


       public int AddVoucherDetails(VoucherDetailsBO ObjBO)
       {
           try
           {

               SqlCommand cmd = new SqlCommand("AddVoucherDetails",con);
               cmd.CommandType = CommandType.StoredProcedure;


               cmd.Parameters.AddWithValue("@VoucherId",ObjBO.VoucherId);
               cmd.Parameters.AddWithValue("@Quantity",ObjBO.Quantity);
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

       public int DeleteVoucherDetails(VoucherDetailsBO ObjBO)
       {
           try
           {
               SqlCommand cmd = new SqlCommand("DeleteVoucherDetails",con);
               cmd.CommandType = CommandType.StoredProcedure;

               cmd.Parameters.AddWithValue("@VoucherDetailId", ObjBO.VoucherDetailId);
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

       public int UpdateVoucherDetails(VoucherDetailsBO ObjBO)
       {
           try
           {

               SqlCommand cmd = new SqlCommand("UpdateVoucherDetails",con);
               cmd.CommandType = CommandType.StoredProcedure;

               cmd.Parameters.AddWithValue("@VoucherId",ObjBO.VoucherId);
               cmd.Parameters.AddWithValue("@Quantity",ObjBO.Quantity);
               cmd.Parameters.AddWithValue("@Status",ObjBO.Status);
               cmd.Parameters.AddWithValue("@UpdateDate",ObjBO.UpdateDate);
               cmd.Parameters.AddWithValue("@UpdateBy",ObjBO.UpdateBy);
               cmd.Parameters.AddWithValue("@VoucherDetailId",ObjBO.VoucherDetailId);

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

       public DataTable RetrieveVoucherDetails(VoucherDetailsBO ObjBO)
       {
           string str = "Select * from VoucherDetails";
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
