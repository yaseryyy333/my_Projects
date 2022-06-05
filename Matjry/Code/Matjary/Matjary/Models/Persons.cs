using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Matjary.Models
{
    public partial class Persons
    {
        public Persons()
        {
            Invoices = new HashSet<Invoices>();
            Quotations = new HashSet<Quotations>();
            ProductPersons = new HashSet<ProductPersons>();
        }

        public int Id { get; set; }

        public DateTime Date { get; set; }
        [Required(ErrorMessage ="يجب ادخال الاسم")]
        [StringLength(maximumLength: 50, ErrorMessage = "لقد تجاوزة الحد المسموح من الكلمات")]
        public string Name { get; set; }
        [Required(ErrorMessage = "يجب ادخال العنوان")]
        [StringLength(maximumLength: 80, ErrorMessage = "لقد تجاوزة الحد المسموح من الكلمات")]
        public string Address { get; set; }
        [Required(ErrorMessage = "يجب ادخال رقم الهاتف")]
        [StringLength(maximumLength: 50, ErrorMessage = "لقد تجاوزة الحد المسموح من الأرقام")]
        public string Telephone { get; set; }
        [StringLength(maximumLength: 50, ErrorMessage = "لقد تجاوزة الحد المسموح من الأرقام")]
        [Required(ErrorMessage = "يجب ادخال رقم الجوال")]
        [DataType(DataType.PhoneNumber,ErrorMessage = "تم ادخال رقم الجوال بطريقة خاطئة")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "يجب ادخال البريد الإلكتروني")]
        [DataType(DataType.EmailAddress,ErrorMessage ="تم ادخال البريد بطريقة خاطئة")]
        public string Email { get; set; }
        [StringLength(maximumLength:250,ErrorMessage = "لقد تجاوزة الحد المسموح من الكلمات")]
        public string Note { get; set; }
        public accountType Type { get; set; }
        public enum accountType
        {
            مورد,
            زبون
        }

        public virtual ICollection<Invoices> Invoices { get; set; }
        public virtual ICollection<Quotations> Quotations { get; set; }
        public virtual ICollection<ProductPersons> ProductPersons { get; set; }

        

    }
}
