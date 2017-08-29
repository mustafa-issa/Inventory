using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using BussinessObject;
using System.Data;


namespace Bussinesslogic
{
   public class ProductsBL
    {
        public int InsertProductsBL(ProductsBO ObjProductsBL) // passing Bussiness object Here 
        {
            try
            {
                ProductsDA ObjProductsDA = new ProductsDA(); // Creating object of Dataccess
                return ObjProductsDA.AddProducts(ObjProductsBL); // calling Method of DataAccess 

            }
            catch
            {
                throw;
            }

        }

        public int DeleteProductsBL(ProductsBO ObjProductsBL)
        {
            try
            {
                ProductsDA ObjProductsDA = new ProductsDA();
                return ObjProductsDA.DeleteProducts(ObjProductsBL);
            }
            catch
            {
                throw;
            }
        }

        public int UpdateProductsBL(ProductsBO ObjProductsBL)
        {
            try
            {
                ProductsDA ObjProductsDA = new ProductsDA();
                return ObjProductsDA.UpdateProducts(ObjProductsBL);
            }
            catch
            {
                throw;
            }
        }

        public DataTable RetrieveProductsBL(ProductsBO Obj1ProductsBL)
        {
            try
            {
              ProductsDA ObjProductsDA = new ProductsDA();
             return ObjProductsDA.RetrieveRecords(Obj1ProductsBL);    
            }
            catch
            {
                throw;
            }
        }

        public double SelectPriceBL(ProductsBO ObjProductsBL)
        {
            try
            {
                ProductsDA ObjProductsDA = new ProductsDA();
                return  ObjProductsDA.SelectPrice(ObjProductsBL);
            }
            catch
            {
                throw;
            }
        }

    }
}


 





