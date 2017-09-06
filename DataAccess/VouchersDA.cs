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
   public class VouchersDA
    {
       SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());


       public int AddVouchers(VouchersBO ObjBO)
       {
           try
           {

               SqlCommand cmd = new SqlCommand("AddVoucher",con);
               cmd.CommandType = CommandType.StoredProcedure;

               cmd.Parameters.AddWithValue("@Number",ObjBO.Number);
               cmd.Parameters.AddWithValue("@Type",ObjBO.Type);
               cmd.Parameters.AddWithValue("@Date",ObjBO.Date);
               cmd.Parameters.AddWithValue("@TotalPrice",ObjBO.TotalPrice);
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

       public int DeleteVouchers(VouchersBO ObjBO)
       {
           try
           {
               SqlCommand cmd = new SqlCommand("DeleteVoucher",con);
               cmd.CommandType = CommandType.StoredProcedure;

               cmd.Parameters.AddWithValue("@VoucherId", ObjBO.VoucherId);
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

       public int UpdateVouchers(VouchersBO ObjBO)
       {
           try
           {

               SqlCommand cmd = new SqlCommand("UpdateVoucher", con);
               cmd.CommandType = CommandType.StoredProcedure;

               cmd.Parameters.AddWithValue("@Number",ObjBO.Number);
               cmd.Parameters.AddWithValue("@Type",ObjBO.Type);
               cmd.Parameters.AddWithValue("@Date",ObjBO.Date);
               cmd.Parameters.AddWithValue("@TotalPrice",ObjBO.TotalPrice);
               cmd.Parameters.AddWithValue("@Status",ObjBO.Status);
               cmd.Parameters.AddWithValue("@UpdateDate",ObjBO.UpdateDate);
               cmd.Parameters.AddWithValue("@UpdateBy",ObjBO.UpdateBy);
               cmd.Parameters.AddWithValue("@VoucherId", ObjBO.VoucherId);


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

       public List<VouchersBO> RetrieveVoucher()
       {
           List<VouchersBO> Vouchers = new List<VouchersBO>();
           string str = "Select * from Vouchers";
           SqlCommand command = new SqlCommand(str, con);
           if (con.State != ConnectionState.Open)
               con.Open();
           SqlDataReader reader = command.ExecuteReader();
           while (reader.Read())
           {
               VouchersBO ObjBO = new VouchersBO();
               ObjBO.VoucherId = int.Parse(reader["VoucherDetailId"].ToString());
               ObjBO.Number = int.Parse(reader["Number"].ToString());
               ObjBO.Type = int.Parse(reader["Type"].ToString());
               ObjBO.Date = DateTime.Parse(reader["Date"].ToString());
               ObjBO.TotalPrice = int.Parse(reader["TotalPrice"].ToString());
               ObjBO.Status = int.Parse(reader["Status"].ToString());
               ObjBO.InsertBy = int.Parse(reader["InsertBy"].ToString());
               ObjBO.UpdateBy = int.Parse(reader["UpdateBy"].ToString());

               ObjBO.InsertDate = DateTime.Parse(reader["InsertDate"].ToString());
               ObjBO.UpdateDate = DateTime.Parse(reader["UpdateDate"].ToString());
               Vouchers.Add(ObjBO);
           }

           try
           {
               return Vouchers;
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


       public string generate_no(VouchersBO ObjBO)
       {
           string str = "select MAX(VoucherId)  from Vouchers ";
           SqlCommand cmd = new SqlCommand(str, con);
           con.Open();
           int result = 0;
           result = (int)cmd.ExecuteScalar();
           return result.ToString("D3");
       }

    }
}
