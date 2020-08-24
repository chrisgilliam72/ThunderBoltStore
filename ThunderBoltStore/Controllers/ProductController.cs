using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ThunderBoltStore.Interfaces;
using ThunderBoltStore.Models;
using ThunderBoltStore.ViewModels;

namespace ThunderBoltStore.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductsRepository _productsRepository;

        public ProductController(ILogger<ProductController> logger,IProductsRepository productsRepository)
        {
            _logger = logger;
            _productsRepository = productsRepository;
        }

        public async Task<IActionResult> Products(int CategoryID)
        {
            var model = new ProductsList();
            var products = await _productsRepository.GetProducts(CategoryID);
            model.Products.AddRange(products);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeactivateProduct(IFormCollection frmData)
        {
            var frmDataArray = frmData.ToArray();
            var productID = Convert.ToInt32(frmDataArray[0].Value);
            var categoryID = Convert.ToInt32(frmDataArray[1].Value);

            await _productsRepository.Activation(productID, false);
            return RedirectToAction("Products", new { CategoryID = categoryID });
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product model)
        {
            await model.UpdatePictureArray();
            await _productsRepository.AddProduct(model);

            return RedirectToAction("Products", new { CategoryID = model.CategoryID });
        }

        [HttpPost]
        public async Task<IActionResult> SaveProduct(Product model)
        {
            await model.UpdatePictureArray();

            await _productsRepository.UpdateProduct(model);

            return RedirectToAction("Products", new { CategoryID = model.CategoryID });
        }
    }

}
