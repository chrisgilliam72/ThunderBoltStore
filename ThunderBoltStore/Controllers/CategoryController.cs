using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThunderBoltDBLib.Models;
using ThunderBoltStore.ViewModels;

namespace ThunderBoltStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
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
