using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThunderBoltDBLib.Models;

namespace ThunderBoltStore.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public String OrderDateString
        {
            get
            {
                return OrderDate.ToShortDateString();
            }
        }

        public String ShippedDateString
        {
            get
            {
                return ShippedDate.HasValue ? ShippedDate.Value.ToShortDateString() : "";
            }
        }

        public Double TotalPrice
        {
            get
            {
                var unitPrice = Product.UnitPrice;
                var quantprice = unitPrice * Quantity;
                var discountAmt = quantprice * Discount / 100.0;

                return (quantprice - discountAmt);
            }
        }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public Product Product { get; set; }



        public static explicit operator Order (OrderDetails orderDetails)
        {
            var order = new Order()
            {
                OrderID = orderDetails.PkOrderId,
                Quantity = orderDetails.Quantity,
                Discount = orderDetails.Discount,
                OrderDate=orderDetails.OrderDate,
                ShippedDate=orderDetails.ShippedDate,
                Product = (Product)orderDetails.FkProduct
            };

            return order;

        }
    }
}
