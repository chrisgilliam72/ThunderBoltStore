using System;
using System.Collections.Generic;

namespace ThunderBoltDBLib.Models
{
    public partial class Products
    {
        public Products()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int PkProductId { get; set; }
        public string ProductName { get; set; }
        public int QuantityPerUnit { get; set; }
        public int UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public int ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        public byte[] Picture { get; set; }
        public int FkCategoryId { get; set; }
        public int FkSupplierId { get; set; }

        public virtual Categories FkCategory { get; set; }
        public virtual Suppliers FkSupplier { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
