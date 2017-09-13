using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using BussinessObject;
using System.Data;


namespace Bussinesslogic
{
   public class ProductsBL : ProductsBO
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

        public ProductsBO DeleteProductsBL(int ProductId)
        {
            try
            {
                ProductsDA ObjProductsDA = new ProductsDA();
                return ObjProductsDA.DeleteProducts(ProductId);
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

        public List<ProductsBO> RetrieveProductsBL()
        {
            try
            {
              ProductsDA ObjProductsDA = new ProductsDA();
             return ObjProductsDA.RetrieveRecords();    
            }
            catch
            {
                throw;
            }
        }

        public ProductsBO SelectOneBL(int Id)
        {
            try
            {
                ProductsDA ObjProductsDA = new ProductsDA();
                return ObjProductsDA.SelectOne(Id);
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


 





