using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThunderBoltDBLib.Models;
using ThunderBoltStore.Models;

namespace ThunderBoltStore
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetAllCategories();

        public Task<bool> UpdateCategory(Category category);
    }
}
