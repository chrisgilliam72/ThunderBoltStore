using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThunderBoltStore.Models;

namespace ThunderBoltStore.ViewModels
{
    public class ProductsList
    {
        public int CategoryID { get; set; }
        public List<Product> Products { get; set; }

        public ProductsList()
        {
            Products = new List<Product>();
        }
    }
}
