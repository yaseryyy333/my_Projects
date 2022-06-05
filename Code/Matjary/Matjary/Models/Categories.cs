using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Matjary.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Products = new HashSet<Products>();
        }

        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
