using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThunderBoltDBLib.Models;

namespace ThunderBoltStore.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        public String ImageType { get; set; } = "jpeg";



        public static explicit operator Categories (Category category)
        {
            var categories = new Categories()
            {
                PkCategoryId= category.CategoryID,
                Name=category.Name,
                Description=category.Description,
                Picture= category.Picture,
            };


            return categories;
        }

        public static explicit operator Category(Categories dbCategory)
        {
            if (dbCategory!=null)
            {
                var category = new Category()
                {
                    CategoryID = dbCategory.PkCategoryId,
                    Name = dbCategory.Name,
                    Description = dbCategory.Description,
                    Picture = dbCategory.Picture
                };

                return category;
            }

            return new Category();
        }
    }
}
