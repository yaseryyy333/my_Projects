using System;
using System.Collections.Generic;

namespace Matjary.Models
{
    public partial class ProductPhoto
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public int ProductId { get; set; }
        public virtual Products Product { get; set; }
    }
}
