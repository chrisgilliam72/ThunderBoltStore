using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ThunderBoltDBLib.Models;
using ThunderBoltStore.Interfaces;

namespace ThunderBoltStore.Models
{
    public class SQLProductsRepository : IProductsRepository
    {
        private readonly ThunderBoltContext _dbContext;

        public SQLProductsRepository(ThunderBoltContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> Activation(int productID, bool isActive)
        {
            var dbproduct = await _dbContext.Products.FirstOrDefaultAsync(x => x.PkProductId == productID);
            if (dbproduct!=null)
            {
                dbproduct.Discontinued = !isActive;
                await _dbContext.SaveChangesAsync();
                return (Product)dbproduct;
            }

            return null;
        }

        public async Task<IEnumerable<Product>> GetProducts(int categoryID)
        {
            var dbproducts = await _dbContext.Products.Include("FkCategory").Include("FkSupplier").
                                      Where(x=>x.FkCategoryId==categoryID && x.Discontinued==false).ToListAsync();
            var products = dbproducts.Select(x => (Product)x).ToList();
            return products;
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var dbproducts = await _dbContext.Products.ToListAsync();
            var products = dbproducts.Select(x => (Product)x).ToList();
            return products;
        }

        public async Task<Product> GetProduct(int productID)
        {
            var dbproducts = await _dbContext.Products.FirstAsync(x => x.PkProductId == productID);
            return (Product)dbproducts;
        }

        public async Task<Product> AddProduct(Product newProduct)
        {
            var products = (Products)newProduct;
            _dbContext.Add(products);
            await _dbContext.SaveChangesAsync();
            newProduct.ProductID = products.PkProductId;
            return newProduct;
        }

        public async Task<Product> UpdateProduct(Product updatedProduct)
        {
                var products = (Products)updatedProduct;
                _dbContext.Products.Attach(products);
                _dbContext.Entry(products).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return updatedProduct;
        }
    }
}
