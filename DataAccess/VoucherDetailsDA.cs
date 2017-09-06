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

       public List<VoucherDetailsBO> RetrieveVoucherDetails()
       {
           List<VoucherDetailsBO> VoucherDetails = new List<VoucherDetailsBO>();
           string str = "Select * from VoucherDetailes";
           SqlCommand command = new SqlCommand(str, con);
           if (con.State != ConnectionState.Open)
               con.Open();
           SqlDataReader reader = command.ExecuteReader();
           while (reader.Read())
           {
               VoucherDetailsBO ObjBO = new  VoucherDetailsBO();
               ObjBO.VoucherDetailId = int.Parse(reader["VoucherDetailId"].ToString());
               ObjBO.VoucherId = int.Parse(reader["VoucherId"].ToString());
               ObjBO.ProductId = int.Parse(reader["ProductId"].ToString());
               ObjBO.Quantity = int.Parse(reader["Quantity"].ToString());
               ObjBO.Status = int.Parse(reader["Status"].ToString());
               ObjBO.InsertDate = DateTime.Parse(reader["InsertDate"].ToString());
               ObjBO.UpdateDate = DateTime.Parse(reader["UpdateDate"].ToString());
               ObjBO.InsertBy = int.Parse(reader["InsertBy"].ToString());
               ObjBO.UpdateBy = int.Parse(reader["UpdateBy"].ToString());

               VoucherDetails.Add(ObjBO);
           }

           try
           {
               return VoucherDetails;
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
