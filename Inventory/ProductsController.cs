using Bussinesslogic;
using BussinessObject;
using System;
using System.Collections.Generic;
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
        public ProductsBO Get(int Id)
        {
            ProductsBL products = new ProductsBL();
            return products.SelectOneBL(Id);
    
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
            ProductsBL products = new ProductsBL();

        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {

        }
    }
}