using System;
using System.Collections.Generic;

namespace ThunderBoltDBLib.Models
{
    public partial class OrderDetails
    {
        public int PkOrderId { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public int FkProductId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public bool Canceled { get; set; }

        public virtual Products FkProduct { get; set; }
    }
}
