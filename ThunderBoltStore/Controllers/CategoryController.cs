using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ThunderBoltDBLib.Models;
using ThunderBoltStore.ViewModels;

namespace ThunderBoltStore.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryController> _logger;
        public CategoryController(ILogger<CategoryController>logger, ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Categories()
        {
            var model = new CategoriesList();
            var categories= await _categoryRepository.GetAllCategories();
            model.CategoryList.AddRange(categories);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveCategory(CategoryViewModel model)
        {

            if (model.ImageFile!=null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.ImageFile.CopyToAsync(memoryStream);
                    model.CategoryItem.Picture = memoryStream.ToArray();
                    var ImageType = model.ImageFile.ContentType;
                }
            }

          
            await _categoryRepository.UpdateCategory(model.CategoryItem);

            return  RedirectToAction("Categories");
        }
    }
}
