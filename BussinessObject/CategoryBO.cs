using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessObject
{
   public class CategoryBO
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public int Status { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int InsertBy { get; set; }
        public int UpdateBy { get; set; }
    }
}
