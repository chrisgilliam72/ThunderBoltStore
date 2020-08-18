using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThunderBoltDBLib.Models;
using ThunderBoltStore.Interfaces;

namespace ThunderBoltStore.Models
{
    public class SQLSuppliersRepository : ISuppliersRepository
    {
        private readonly ThunderBoltContext _dbContext;
        public SQLSuppliersRepository(ThunderBoltContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliers()
        {
            var dbSuppliers = await _dbContext.Suppliers.Where(x=>x.IsActive).ToListAsync();
            var suppliers = dbSuppliers.Select(x => (Supplier)x).ToList();
            return suppliers;
        }
        public async Task<Supplier> Activation(int supplierID,bool isActive)
        {
            var supppliers = await _dbContext.Suppliers.FirstAsync(x => x.PkSupplierId == supplierID);
            supppliers.IsActive = isActive;
            await _dbContext.SaveChangesAsync();

            return (Supplier)supppliers;
        }

        public async Task<Supplier> AddSupplier(Supplier newSupplier)
        {
            var suppliers = (Suppliers)newSupplier;
            _dbContext.Suppliers.Add(suppliers);
            await _dbContext.SaveChangesAsync();
            newSupplier.SupplierID = suppliers.PkSupplierId;
            return newSupplier;
        }

        public async Task<Supplier> UpdateSupplier(Supplier updatedSupplier )
        {
            var suppliers = (Suppliers)updatedSupplier;
            _dbContext.Suppliers.Attach(suppliers);
            _dbContext.Entry(suppliers).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return updatedSupplier;
        }

    }
}
