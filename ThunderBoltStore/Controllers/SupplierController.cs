using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using ThunderBoltDBLib.Models;
using ThunderBoltStore.Interfaces;
using ThunderBoltStore.Models;
using ThunderBoltStore.ViewModels;

namespace ThunderBoltStore.Controllers
{
    [Authorize]
    public class SupplierController : Controller
    {
        private readonly ISuppliersRepository _suppliersRepository;
        private readonly ILogger<SupplierController> _logger;
        public SupplierController(ILogger<SupplierController> logger,ISuppliersRepository suppliersRepository)
        {
            _logger = logger;
            _suppliersRepository = suppliersRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        private async Task<SuppliersList> RefreshSuppliers()
        {
            var model = new SuppliersList();
            var suppliers = await _suppliersRepository.GetAllSuppliers();
            model.SupplierList.AddRange(suppliers);
            return model;
        }
        [HttpPost]
        public async Task<IActionResult> DeactivateSupplier(IFormCollection frmData)
        {
            var dataArray =frmData.ToArray();
            int supplierID = Convert.ToInt32(dataArray[0].Value);
            await _suppliersRepository.Activation(supplierID, false);
            var suppliersListModel =await RefreshSuppliers();
            suppliersListModel.ShowOperationSuccessful = true; ;
            suppliersListModel.LastOperation = "Supplier deactivated";
            return PartialView("/Views/Supplier/_SuppliersTable.cshtml", suppliersListModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> SaveSupplier(Supplier model)
        {
            await _suppliersRepository.UpdateSupplier(model);
            var suppliersListModel = await RefreshSuppliers();
            suppliersListModel.ShowOperationSuccessful = true; ;
            suppliersListModel.LastOperation = "Supplier updated";
            ModelState.Clear();
            var data = PartialView("/Views/Supplier/_SuppliersTable.cshtml", suppliersListModel);
            return data;
        }
        public async Task<IActionResult> AddSupplier(Supplier model)
        {
            await _suppliersRepository.AddSupplier(model);
            var suppliersListModel =await  RefreshSuppliers();
            suppliersListModel.ShowOperationSuccessful = true; ;
            suppliersListModel.LastOperation = "Supplier updated";
            return PartialView("/Views/Supplier/_SuppliersTable.cshtml", suppliersListModel);
        }

        public async Task<IActionResult> Suppliers()
        {
            var model = await RefreshSuppliers();
            return View("Suppliers", model);
        }
    }
}
