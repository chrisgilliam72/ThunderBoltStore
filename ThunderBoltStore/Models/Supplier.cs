using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ThunderBoltDBLib.Models;

namespace ThunderBoltStore.Models
{
    public class Supplier
    {
        public int SupplierID { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string ContactName { get; set; }

        [Required]
        public string ContactTitle { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }
        [Required]
        public string Region { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string HomePage { get; set; }

        public static explicit operator Supplier(Suppliers dbSupplier)
        {
            if (dbSupplier!=null)
            {
                var supplier = new Supplier()
                {
                    SupplierID = dbSupplier.PkSupplierId,
                    Name = dbSupplier.CompanyName,
                    ContactName = dbSupplier.ContactName,
                    ContactTitle = dbSupplier.ContactTitle,
                    Address = dbSupplier.Address,
                    City = dbSupplier.City,
                    Region = dbSupplier.Region,
                    PostalCode = dbSupplier.PostalCode,
                    Country = dbSupplier.Country,
                    Phone = dbSupplier.Phone,
                    HomePage = dbSupplier.HomePage,
                };

                return supplier;
            }

            return new Supplier();
         
        }


        public static explicit operator Suppliers(Supplier supplier)
        {
            var dbSupplier = new Suppliers()
            {
                PkSupplierId = supplier.SupplierID,
                CompanyName= supplier.Name,
                ContactName = supplier.ContactName,
                ContactTitle = supplier.ContactTitle,
                Address = supplier.Address,
                City = supplier.City,
                Region = supplier.Region,
                PostalCode = supplier.PostalCode,
                Country = supplier.Country,
                Phone = supplier.Phone,
                HomePage = supplier.HomePage,
            };

            return dbSupplier;
        }
    }
}
