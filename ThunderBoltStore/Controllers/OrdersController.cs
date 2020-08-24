using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        public async Task<IActionResult> Orders()
        {
            var model = new OrdersList();
            var orders= await  _ordersRepository.GetAllOrders();
            model.OrderList.AddRange(orders);
            return View(model);
        }
    }
}
