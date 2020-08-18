using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using ThunderBoltDBLib.Models;
using ThunderBoltStore.Interfaces;
using ThunderBoltStore.Models;
using ThunderBoltStore.ViewModels;

namespace ThunderBoltStore.Controllers
{
    public class SupplierController : Controller
    {
        ISuppliersRepository _suppliersRepository;

        public SupplierController(ISuppliersRepository suppliersRepository)
        {
            _suppliersRepository = suppliersRepository;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> DeactivateSupplier(IFormCollection frmData)
        {
            var dataArray =frmData.ToArray();
            int supplierID = Convert.ToInt32(dataArray[0].Value);
            await _suppliersRepository.Activation(supplierID, false);
            return RedirectToAction("Suppliers");
        }


        public async Task<IActionResult> SaveSupplier(Supplier model)
        {
            await _suppliersRepository.UpdateSupplier(model);
            return RedirectToAction("Suppliers");
        }
        public async Task<IActionResult> AddSupplier(Supplier model)
        {
            await _suppliersRepository.AddSupplier(model);
            return RedirectToAction("Suppliers");
        }

        public async Task<IActionResult> Suppliers()
        {
            var model = new SuppliersList();
            var suppliers = await _suppliersRepository.GetAllSuppliers();
            model.SupplierList.AddRange(suppliers);
            return View("Suppliers", model);
        }
    }
}
