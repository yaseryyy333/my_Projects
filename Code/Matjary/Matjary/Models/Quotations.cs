using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Matjary.Models
{
    public partial class Quotations
    {
        public Quotations()
        {
            QuotationsProducts = new HashSet<QuotationsProducts>();
        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double VatRate { get; set; }
        public string Status { get; set; }
        public double TotalDiscount { get; set; }
        public double TotalCost { get; set; }
        public double TotalVat { get; set; }
        public double Total { get; set; }
        public int Duration { get; set; }
        public string Note { get; set; }
        public string UserId { get; set; }
        public int PersonId { get; set; }
        [NotMapped]
        public List<int> ProductIds { get; set; }
        [NotMapped]
        public List<double> Cost { get; set; }
        [NotMapped]
        public List<double> SellPrice { get; set; }
        [NotMapped]
        public List<double> Discount { get; set; }
        [NotMapped]
        public List<int> Qty { get; set; }
        [NotMapped]
        public List<double> Totals { get; set; }
        [NotMapped]
        public List<double> Totals_vat { get; set; }
        [NotMapped]
        public List<string> Notes { get; set; }
        public virtual Persons Person { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<QuotationsProducts> QuotationsProducts { get; set; }

    }
}
