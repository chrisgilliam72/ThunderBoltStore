using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThunderBoltStore.Models;

namespace ThunderBoltStore.ViewModels
{
    public class SuppliersList : OperationalListBase
    {
        public List<Supplier> SupplierList { get; set; }

        public int SupplierCount
        {
            get
            {
                return SupplierList.Count();
            }
        }

        public SuppliersList()
        {
            SupplierList = new  List<Supplier>();
        }
    }
}
