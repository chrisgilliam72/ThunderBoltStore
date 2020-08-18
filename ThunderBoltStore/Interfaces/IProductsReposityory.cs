using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThunderBoltStore.Models;

namespace ThunderBoltStore.Interfaces
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<IEnumerable<Product>> GetProducts(int categoryID);
        Task<Product> GetProduct(int productID);
        Task<Product> UpdateProduct(Product updatedProduct);
        Task<Product> AddProduct(Product newProduct);
        Task<Product> Activation(int productID, bool isActive);
    }
}
