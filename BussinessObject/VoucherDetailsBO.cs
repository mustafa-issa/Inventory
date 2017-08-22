using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessObject
{
    public class VoucherDetailsBO
    {
        public int VoucherDetailId { get; set; }
        public int VoucherId { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int InsertBy { get; set; }
        public int UpdateBy { get; set; }

    }
}
