using System;
using System.Collections.Generic;

namespace ThunderBoltDBLib.Models
{
    public partial class Suppliers
    {
        public Suppliers()
        {
            Products = new HashSet<Products>();
        }

        public int PkSupplierId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string HomePage { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
