using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThunderBoltStore.Models;

namespace ThunderBoltStore.ViewModels
{
    public enum OrderOperation { None, Ship, Cancel }
    public class OrdersList
    {
        public List<Order> OrderList { get; set; }
        public bool ShowOperationSuccessful { get; set; }
        public bool ShowOperationFail { get; set; }

        public OrderOperation LastOperation { get; set; } = OrderOperation.None;
        public OrdersList()
        {
            OrderList = new List<Order>();
        }
    }
}
