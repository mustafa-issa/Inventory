using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using BussinessObject;

namespace Bussinesslogic
{
   public class CategoryBL
    {
       public int InsertCategoryBL(CategoryBO ObjBL) 
       {
           try
           {
               CategoryDA ObjDA = new CategoryDA(); 
               return ObjDA.AddCategory(ObjBL); 


           }
           catch
           {
               throw;
           }

       }

       public void DropDownLIstBL(CategoryBO ObjBL)
       {
           try
           {
               CategoryDA ObjDA = new CategoryDA();
               ObjDA.DropDownList(ObjBL);
           }
           catch
           {
               throw;
           }

       }


    }
}
