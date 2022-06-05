using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Matjary.Models
{
    public partial class Invoices
    {
        public Invoices()
        {
            Payment = new HashSet<Payment>();
            InvoicesProducts = new HashSet<InvoicesProducts>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Invoice_Type { get; set; }
        public int Vat_Rate { get; set; }
        public int TotalDiscount { get; set; }
        public int TotalCost { get; set; }
        public double TotalVat { get; set; }
        public double Total { get; set; }
        public double Payments { get; set; }
        public string Note { get; set; }
        public int PersonId { get; set; }
        public string UserId { get; set; }
        public virtual Persons Person { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
        public virtual ICollection<InvoicesProducts> InvoicesProducts { get; set; }
    }
}
