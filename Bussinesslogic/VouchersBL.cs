using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using BussinessObject;

namespace Bussinesslogic
{
     public class VouchersBL
    {
         public int InsertVouchersBL(VouchersBO ObjBL) 
         {
             try
             {
                 VouchersDA ObjDA = new VouchersDA(); 
                 return ObjDA.AddVouchers(ObjBL); 

             }
             catch
             {
                 throw;
             }

         }

         public int DeleteVouchersBL(VouchersBO ObjBL)
         {
             try
             {
                 VouchersDA ObjDA = new VouchersDA();
                 return ObjDA.DeleteVouchers(ObjBL);

             }
             catch
             {
                 throw;
             }

         }

         public int UpdateVouchersBL(VouchersBO ObjBL)
         {
             try
             {
                 VouchersDA ObjDA = new VouchersDA();
                 return ObjDA.UpdateVouchers(ObjBL);

             }
             catch
             {
                 throw;
             }

         }

         public string Generate_NoBL(VouchersBO ObjBL)
         {
             try
             {
                 VouchersDA ObjDA = new VouchersDA();
                 return ObjDA.generate_no(ObjBL);

             }
             catch
             {
                 throw;
             }

         }
    }
}
