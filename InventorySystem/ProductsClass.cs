using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;


/// <summary>
/// Summary description for ProductsClass
/// </summary>
public class ProductsClass 
{
    string mgr = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    public ProductsClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int ProductId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int Status { get; set; }
    public DateTime InsertDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public int CategoryId { get; set; }


    public int additems()
    {

        SqlConnection con = new SqlConnection(mgr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Add", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Price", Price);
            cmd.Parameters.AddWithValue("@Quantity", Quantity);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@InsertDate", InsertDate);
            cmd.Parameters.AddWithValue("@CategoryId", CategoryId);
            


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

    public int dltproduct()
    {
        SqlConnection con = new SqlConnection(mgr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Delete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ProductId", ProductId);
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
    public int upddProduct()
    {
        SqlConnection con = new SqlConnection(mgr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Upd", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Price", Price);
            cmd.Parameters.AddWithValue("@Quantity", Quantity);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@UpdateDate", UpdateDate);
            cmd.Parameters.AddWithValue("@ProductId", ProductId);
            cmd.Parameters.AddWithValue("@CategoryId", CategoryId);


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
    public DataTable RetrieveRecords()
    {
        string str = "Select Products.*,Category.Name from Products INNER JOIN Category ON Products.CategoryId=Category.CategoryId ";
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
    public int checkExistance(int ProductId)
    {
        SqlConnection con = new SqlConnection(mgr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from Products where ProductId=" + ProductId + "", con);
        SqlDataReader dr;
        try
        {
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return 1;
            }
            else
                return 0;
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
    public double SelectPrice()
    {
        string str = "Select Price from Products where ProductId=@ProductId  ";
        SqlConnection con = new SqlConnection(mgr);
        SqlCommand cmd = new SqlCommand(str, con);

        cmd.Parameters.AddWithValue("@ProductId", ProductId);
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
