using System;
using System.Collections.Generic;

namespace Matjary.Models
{
    public partial class OrderProduct
    {
        public int ID { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public double Cost { get; set; }
        public double SellPrice { get; set; }
        public double Total_Vat { get; set; }
        public double Qty { get; set; }
        public double Discount { get; set; }
        public double Total { get; set; }

        public virtual Order Order { get; set; }
        public virtual Products Product { get; set; }
    }
}
