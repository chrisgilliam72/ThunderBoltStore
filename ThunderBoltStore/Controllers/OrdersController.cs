using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ThunderBoltStore.Interfaces;
using ThunderBoltStore.ViewModels;

namespace ThunderBoltStore.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly ILogger<OrdersController> _logger;
        public OrdersController(ILogger<OrdersController> logger,IOrdersRepository ordersRepository)
        {
            _logger = logger;
            _ordersRepository = ordersRepository;
        }

        private async Task<OrdersList> RefreshOrders()
        {
            var model = new OrdersList();
            var orders = await _ordersRepository.GetAllOrders();
            model.OrderList.AddRange(orders);
            return model;
        }

        public async Task<IActionResult> CancelOrder(IFormCollection frmData)
        {
            var canceled = true;
            var frmDataArray = frmData.ToArray();
            var orderID = Convert.ToInt32(frmDataArray[0].Value);
            try
            {
                await _ordersRepository.CancelOrder(orderID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Order Cancel failure", new { Name = "OrderID", Value = orderID });
                canceled = false;
            }
            var model = await RefreshOrders();
            if (canceled)
            {
                model.LastOperation = "Order canceled";
                model.ShowOperationSuccessful = true;
            }

            else
                model.ShowOperationFail = true;
            return PartialView("/Views/Orders/_OrdersTable.cshtml", model);
        }

        public async Task<IActionResult> ShipOrder(IFormCollection frmData)
        {
            var shipped = true;
            var frmDataArray = frmData.ToArray();
            var orderID = Convert.ToInt32(frmDataArray[0].Value);
            try
            {
                await _ordersRepository.ShipOrder(orderID, DateTime.Today);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Order shipment failure", new { Name = "OrderID", Value = orderID });
                shipped = false;
            }
            var model = await RefreshOrders();
            if (shipped)
            {
                model.LastOperation = "Order marked as shipped";
                model.ShowOperationSuccessful = true;
            }

            else
                model.ShowOperationFail = true;
            return PartialView("/Views/Orders/_OrdersTable.cshtml", model);
        }

        public async Task<IActionResult> Orders()
        {
            var model = await RefreshOrders();
            model.ShowOperationSuccessful = true;
            return View(model);
        }
    }
}
