using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThunderBoltStore.Interfaces;
using ThunderBoltStore.ViewModels;

namespace ThunderBoltStore.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersRepository _ordersRepository;
        public OrdersController(IOrdersRepository ordersRepository)
        {
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
