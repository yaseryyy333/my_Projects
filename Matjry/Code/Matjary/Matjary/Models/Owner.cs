using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Matjary.Models
{
    public partial class Owner
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage ="ادخل اسم المؤسسة")]
        [StringLength(maximumLength:60,ErrorMessage ="اسم المؤسسة طويل جدا")]
        public string Name { get; set; }
        [Required(ErrorMessage = "ادخل عنوان المؤسسة")]
        [StringLength(maximumLength: 60, ErrorMessage = "عنوان المؤسسة طويل جدا")]
        public string Title { get; set; }
        [Required(ErrorMessage = "ادخل تلفون المؤسسة")]
        [StringLength(maximumLength: 20, ErrorMessage = "اسم المؤسسة طويل جدا")]
        [DataType(DataType.PhoneNumber,ErrorMessage = "الرجاء ادخال رقم هاتف صحيح")]
        public string Telephone { get; set; }
        [Required(ErrorMessage = "ادخل جوال المؤسسة")]
        [StringLength(maximumLength: 20, ErrorMessage = "جوال المؤسسة طويل جدا")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "الرجاء ادخال رقم جوال صحيح")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "ادخل بريد المؤسسة")]
        [StringLength(maximumLength: 80, ErrorMessage = "بريد المؤسسة طويل جدا")]
        [DataType(DataType.EmailAddress, ErrorMessage = "الرجاء ادخال بريد  صحيح")]
        public string Email { get; set; }
        [Required(ErrorMessage = "ادخل السجل التجاري")]
        [StringLength(maximumLength: 100, ErrorMessage = "السجل التجاري طويل جدا")]
        public string Commercial { get; set; }
        [Required(ErrorMessage = "ادخل الرقم الضريبي للمؤسسة")]
        public int? NumberVat { get; set; }
        [DataType(DataType.Upload)]
        public string Logo { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "ادخل صورة المنشأة")]
        public IFormFile File { set; get; }
        //file

    }
}
