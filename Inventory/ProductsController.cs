using Bussinesslogic;
using BussinessObject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace Inventory
{
    public class ProductsController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<ProductsBO> Get()
        {
           
            ProductsBL products = new ProductsBL();

            List<ProductsBO> aList = products.RetrieveProductsBL();

            return aList;


        }



        // GET api/<controller>/5
        public ProductsBO Get(int ProductId)
        {
            ProductsBL products = new ProductsBL();
            return products.SelectOneBL(ProductId);
    
        }

        // POST api/<controller>
        public void Post(ProductsBO product)
        {
            ProductsBL products = new ProductsBL();
            products.InsertProductsBL(product);
        }

        // PUT api/<controller>/5
        public void Put(ProductsBO product)
        {
            ProductsBL products = new ProductsBL();
            products.UpdateProductsBL(product);




        }

        // DELETE api/<controller>/5
        public void Delete(int ProductId)
        {
            ProductsBL products = new ProductsBL();
            products.DeleteProductsBL(ProductId);


        }
    }
}