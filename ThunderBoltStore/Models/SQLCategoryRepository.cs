using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThunderBoltDBLib.Models;

namespace ThunderBoltStore.Models
{
    public class SQLCategoryRepository : ICategoryRepository
    {
        private readonly ThunderBoltContext _dbContext;
        public SQLCategoryRepository(ThunderBoltContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> UpdateCategory(Category category)
        {
            try
            {
                var categories = (Categories)category;
                _dbContext.Categories.Attach(categories);
                _dbContext.Entry(categories).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            try
            {
                var dbCategories = await _dbContext.Categories.ToListAsync();
                var categories = dbCategories.Select(x => (Category)x).ToList();
                return categories;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
