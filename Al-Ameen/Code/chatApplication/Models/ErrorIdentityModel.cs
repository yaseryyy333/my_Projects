using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chatApplication.Models
{

    public class ErrorIdentityModel : IdentityErrorDescriber
    {
        public override IdentityError DuplicateUserName(string username)
        {
            return new IdentityError
            {
                Code = nameof(DuplicateUserName),
                Description = "هذا الإسم مكرر"
            };
        }
        //other method in IdentityErrorDescriber,you can see below

        public override IdentityError PasswordTooShort(int number)
        {
            return new IdentityError
            {
                Code = nameof(PasswordTooShort),
                Description = string.Format("يجب أن تتكلون كلمة المرور من {0} أحرف على الأقل", number)
            };
        }
    }
}
        
