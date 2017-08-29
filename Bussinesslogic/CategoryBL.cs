using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using BussinessObject;
using System.Data;


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

       public int DeleteCategoryBL(CategoryBO ObjBL)
       {
           try
           {
               CategoryDA ObjDA = new CategoryDA();
               return ObjDA.DeleteCategory(ObjBL);

           }
           catch
           {
               throw;
           }

       }

       public int UpdateCategoryBL(CategoryBO ObjBL)
       {
           try
           {
               CategoryDA ObjDA = new CategoryDA();
               return ObjDA.UpdateCategory(ObjBL);

           }
           catch
           {
               throw;
           }

       }

       public DataTable RetrieveCategoryBL(CategoryBO ObjBL)
       {
           try
           {
               CategoryDA ObjDA = new CategoryDA();
               return ObjDA.RetrieveCategory(ObjBL);

           }
           catch
           {
               throw;
           }

       }

       public DataTable DropDownLIstBL(CategoryBO ObjBL)
       {
           try
           {
              CategoryDA ObjDA = new CategoryDA();
              return ObjDA.DropDownListCategory(ObjBL);
           }
           catch
           {
               throw;
           }

       }


    }
}
