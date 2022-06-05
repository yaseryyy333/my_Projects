using System;
using System.Collections.Generic;

namespace Matjary.Models
{
    public partial class QuotationsProducts
    {
        public int ID { get; set; }
        public int QuotationsId { get; set; }
        public int ProductId { get; set; }
        public double Cost { get; set; }
        public double SellPrice { get; set; }
        public double Total_Vat { get; set; }
        public int Qty { get; set; }
        public double Discount { get; set; }
        public double Total { get; set; }
        public string Note { get; set; }

        public virtual Products Product { get; set; }
        public virtual Quotations Quotations { get; set; }
    }
}
