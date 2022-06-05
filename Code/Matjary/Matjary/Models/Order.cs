using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Matjary.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double TotalDiscount { get; set; }
        public double TotalCost { get; set; }
        public double Total { get; set; }
        public double TotalVat { get; set; }
        public string PaymentPhoto { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }



    }
}
