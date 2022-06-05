using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Matjary.Models
{
    public partial class VatTable
    {
        public int Id { get; set; }
        [Required]
        public int VatRate { get; set; }
    }
}
