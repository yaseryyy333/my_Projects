using chatApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace chatApplication.Models
{
    public class TokenRequestModel
    {
        [Required(ErrorMessage = "يجب ادخال رقم الجوال")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "يجب أدخال كلمة المرور")]
        public string Password { get; set; }
    }
}