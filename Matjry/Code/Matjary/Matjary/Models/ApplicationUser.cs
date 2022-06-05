using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Matjary.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {

        }
        public string Name { get; set; }

        public string Photo { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
        public virtual ICollection<Invoices> Invoices { get; set; }
        public virtual ICollection<Quotations> Quotations { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
