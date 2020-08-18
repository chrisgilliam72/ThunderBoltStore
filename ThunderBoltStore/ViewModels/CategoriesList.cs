using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThunderBoltStore.Models;

namespace ThunderBoltStore.ViewModels
{
    public class CategoriesList
    {
        public List<Category> CategoryList { get; set; }

        public CategoriesList()
        {
            CategoryList = new List<Category>();
        }
    }
}
