using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ThunderBoltDBLib.Models;

namespace ThunderBoltStore.Models
{
    public class Product : PictureItem
    {
        [Required]
        public int ProductID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int QuantityPerUnit { get; set; }
        public int UnitPrice { get; set; }
        [Required]
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        [Required]
        public int ReorderLevel { get; set; }
        [Required]
        public bool Discontinued { get; set; }

        public int SupplierID { get; set; }
        public int CategoryID { get; set; }

        public Category Category { get; set; }

        public Supplier Supplier { get; set; }

        public bool IsNew
        {
            get
            {
                return ProductID < 1;
            }
        }

        public String SupplierName
        {
            get
            {
                return Supplier != null ? Supplier.Name : "";
            }
   
        }

        public static explicit operator Product(Products dbProduct)
        {
            var product = new Product()
            {
                ProductID = dbProduct.PkProductId,
                Name = dbProduct.ProductName,
                QuantityPerUnit = dbProduct.QuantityPerUnit,
                UnitPrice = dbProduct.UnitPrice,
                UnitsInStock = dbProduct.UnitsInStock,
                UnitsOnOrder = dbProduct.UnitsOnOrder,
                ReorderLevel = dbProduct.ReorderLevel,
                Discontinued = dbProduct.Discontinued,
                Supplier= (Supplier)dbProduct.FkSupplier,
                Category=(Category)dbProduct.FkCategory,
                SupplierID = dbProduct.FkSupplier != null ? dbProduct.FkSupplier.PkSupplierId : -1,
                CategoryID =   dbProduct.FkCategory != null ? dbProduct.FkCategory.PkCategoryId : -1,
                Picture =dbProduct.Picture
            };

            return product;
        }

        public static explicit operator Products(Product product)
        {
            var products = new Products()
            {
                PkProductId = product.ProductID,
                ProductName = product.Name,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                UnitsOnOrder = product.UnitsOnOrder,
                ReorderLevel = product.ReorderLevel,
                Discontinued = product.Discontinued,
                Picture=product.Picture,
                FkCategoryId=product.CategoryID,
                FkSupplierId=product.SupplierID
                
            };

            return products;
        }
    }
}
