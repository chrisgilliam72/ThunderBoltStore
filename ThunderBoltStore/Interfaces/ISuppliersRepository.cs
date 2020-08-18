using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThunderBoltStore.Models;

namespace ThunderBoltStore.Interfaces
{
    public interface ISuppliersRepository
    {
        Task<IEnumerable<Supplier>> GetAllSuppliers();
        Task<Supplier> AddSupplier(Supplier newSupplier);
        Task<Supplier> UpdateSupplier(Supplier editedSupplier);
        Task<Supplier> Activation(int supplierID,bool iSActive);
    }
}
