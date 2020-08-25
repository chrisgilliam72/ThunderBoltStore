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

        private async Task<OrderDetails> GetOrder(int orderID)
        {
            var dbOrder = await _dbContext.OrderDetails.
                       Include("FkProduct").
                       Include("FkProduct.FkCategory").
                       Include("FkProduct.FkSupplier").FirstAsync(x => x.PkOrderId == orderID);
            return dbOrder;
        }

        public async Task<Order> ShipOrder(int orderID, DateTime dateShipped)
        {
            var dbOrder = await GetOrder(orderID);
            dbOrder.ShippedDate = dateShipped;
            await _dbContext.SaveChangesAsync();

            var order = (Order)dbOrder;
            return order;
        }

        public async Task<Order> CancelOrder(int orderID)
        {
            var dbOrder = await GetOrder(orderID);
            dbOrder.Canceled = true;
            await _dbContext.SaveChangesAsync();

            var order = (Order)dbOrder;
            return order;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            var dbOrders = await _dbContext.OrderDetails.
                                   Include("FkProduct").
                                   Include("FkProduct.FkCategory").
                                   Include("FkProduct.FkSupplier").Where(x=>x.Canceled==false).ToListAsync();
            var orders = dbOrders.Select(x => (Order)x).ToList();

            return orders;
        }
    }
}
