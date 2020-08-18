using System;
using System.Collections.Generic;

namespace ThunderBoltDBLib.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Products = new HashSet<Products>();
        }

        public int PkCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
