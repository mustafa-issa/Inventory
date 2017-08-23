using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessObject
{
   public class VouchersBO
    {
        public int VoucherId { get; set; }
        public int Number { get; set; }
        public int Type { get; set; }
        public DateTime Date { get; set; }
        public float TotalPrice { get; set; }
        public int Status { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int InsertBy { get; set; }
        public int UpdateBy { get; set; }
        public string Title { get; set; }
        public int ProductId { get; set; }
    }
}
