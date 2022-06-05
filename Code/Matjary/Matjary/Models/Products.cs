using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Matjary.Models
{
    public partial class Products
    {
        public Products()
        {
           
            ProductPhoto = new HashSet<ProductPhoto>();
            InvoicesProducts = new HashSet<InvoicesProducts>();
            QuotationsProducts = new HashSet<QuotationsProducts>();
            ProductPersons = new HashSet<ProductPersons>();
            OrderProducts = new HashSet<OrderProduct>();
            Files = new List<IFormFile>();
            Per_list = new List<ProductPersons>();
            Photo_list = new List<ProductPhoto>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage ="رمز المنتج مطلوب")]
        public string Sku { get; set; }
        [Required(ErrorMessage ="اسم المنتج مطلوب")]
        public string Name { get; set; }
        [Required(ErrorMessage ="تكلفة المنتج مطلوبة")]
        [RegularExpression(@"\d+",ErrorMessage = "تكلفة المنتج مطلوبة")]
        public double Cost { get; set; }
        [Required(ErrorMessage ="سعر المنتج مطلوب")]
        [RegularExpression(@"\d+", ErrorMessage = "سعر المنتج مطلوب")]
        public double SellPrice { get; set; }
        [Required(ErrorMessage ="وصف المنتج مطلوب")]
        public string Description { get; set; }
        [Required(ErrorMessage ="الخصم مطلوب")]
        [RegularExpression(@"\d+", ErrorMessage = "الخصم مطلوب")]
        public double DiscountRate { get; set; }
        [Required(ErrorMessage ="إختيار الفئة مطلوب")]
        public int CategoryId { get; set; }
        public virtual Categories Category { get; set; }
        
        public Store Store { get; set; }
        [NotMapped]
        public List<IFormFile> Files { get; set; }
        [NotMapped]
        public List<int> PersonIds { get; set; }
        [NotMapped]
        public List<ProductPersons> Per_list { get; set; }
        [NotMapped]
        public List<ProductPhoto> Photo_list { get; set; }
        public virtual ICollection<ProductPhoto> ProductPhoto { get; set; }
        public virtual ICollection<InvoicesProducts> InvoicesProducts { get; set; }
        public virtual ICollection<QuotationsProducts> QuotationsProducts { get; set; }
        public virtual ICollection<ProductPersons> ProductPersons { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
