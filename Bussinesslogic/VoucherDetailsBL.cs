using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using BussinessObject;
using System.Data;


namespace Bussinesslogic
{
   public class VoucherDetailsBL
    {
       public int InsertVoucheDetailsBL(VoucherDetailsBO ObjBL) 
       {
           try
           {
               VoucherDetailsDA ObjDA = new VoucherDetailsDA();
               return ObjDA.AddVoucherDetails(ObjBL); 

           }
           catch
           {
               throw;
           }

       }

       public int DeleteVoucheDetailsBL(VoucherDetailsBO ObjBL)
       {
           try
           {
               VoucherDetailsDA ObjDA = new VoucherDetailsDA();
               return ObjDA.DeleteVoucherDetails(ObjBL);

           }
           catch
           {
               throw;
           }

       }

       public int UpdateVoucherDetailsBL(VoucherDetailsBO ObjBL)
       {
           try
           {
               VoucherDetailsDA ObjDA = new VoucherDetailsDA();
               return ObjDA.UpdateVoucherDetails(ObjBL);

           }
           catch
           {
               throw;
           }

       }

       public DataTable RetrieveVoucheDetailsBL(VoucherDetailsBO ObjBL)
       {
           try
           {
            VoucherDetailsDA ObjDA = new VoucherDetailsDA();
            return ObjDA.RetrieveVoucherDetails(ObjBL);

           }
           catch
           {
               throw;
           }

       }

     
    }
}
