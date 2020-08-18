using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThunderBoltStore.Models;

namespace ThunderBoltStore.Interfaces
{
    public interface IOrdersRepository
    {
        Task<IEnumerable<Order>> GetAllOrders();
    }
}
