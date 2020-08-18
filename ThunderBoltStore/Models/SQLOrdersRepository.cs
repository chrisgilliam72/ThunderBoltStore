using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThunderBoltDBLib.Models;
using ThunderBoltStore.Interfaces;

namespace ThunderBoltStore.Models
{
    public class SQLOrdersRepository : IOrdersRepository
    {
        private readonly ThunderBoltContext _dbContext;
        public SQLOrdersRepository(ThunderBoltContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            var dbOrders = await _dbContext.OrderDetails.
                                   Include("FkProduct").
                                   Include("FkProduct.FkCategory").
                                   Include("FkProduct.FkSupplier").ToListAsync();
            var orders = dbOrders.Select(x => (Order)x).ToList();

            return orders;
        }
    }
}
