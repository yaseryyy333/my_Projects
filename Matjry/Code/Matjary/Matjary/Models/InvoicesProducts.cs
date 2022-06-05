using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Matjary.Models
{
  
    public partial class InvoicesProducts
    {


        public int ID { get; set; }
        public double Cost { get; set; }
        public double SellPrice { get; set; }
        public double Total_Vat { get; set; }
        public int Qty { get; set; }
        public double Discount { get; set; }
        public double Total { get; set; }
        public string Note { get; set; }

        public int InvoiceId { get; set; }
        public virtual Invoices Invoice { get; set; }
        public int ProductId { get; set; }
        public virtual Products Product { get; set; }
    }
}
