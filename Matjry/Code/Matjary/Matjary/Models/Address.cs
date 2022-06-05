using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Matjary.Models
{
    public partial class Address
    {
    
        public int Id { get; set; }
        public string City { get; set; }
        [StringLength(60,ErrorMessage ="اسم الشارع طويل جدا")]
        public string Street { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
