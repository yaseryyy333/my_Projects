using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Matjary.Models
{
    public partial class Store
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="كمية المنتج مطلوبة")]
        [RegularExpression(@"\d+", ErrorMessage = "كمية المنتج مطلوبة")]
        public int Qty { get; set; }
        public int ProductId { get; set; }
        public virtual Products Product { get; set; }
    }
}
