using System;
using System.Collections.Generic;

namespace Matjary.Models
{
    public partial class Payment
    {
        public int Id { get; set; }
        public double? Value { get; set; }
        public DateTime Date { get; set; }
        public int? InvoiceId { get; set; }

        public virtual Invoices Invoice { get; set; }
    }
}
