using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThunderBoltStore.Models;

namespace ThunderBoltStore.ViewModels
{
    public class OrdersList
    {
        public List<Order> OrderList { get; set; }

        public OrdersList()
        {
            OrderList = new List<Order>();
        }
    }
}
