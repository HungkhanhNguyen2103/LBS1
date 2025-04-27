using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.BaseModel
{
    public class AccountModel
    {
        public string? UserName { get; set; }
        public string? OldPassword { get; set; }
        public string? Password { get; set; }
        public string? PasswordConfirm { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Avatar { get; set; }
        //public int Gender { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Status { get; set; }
        public string? ReturnUrl { get; set; }
        public bool AccountActive { get; set; }
        public bool? EmailConfirm { get; set; }
        public int GrantPermission { get; set; }

        // 0 - User
        // 1 - Author
        public int RegisterType { get; set; }
        public string? DeviceToken { get; set; }
    }

    public class AccountViewModel : AccountModel
    {
        public bool LockoutEnabled { get; set; }
    }


    public class EmailConfirm
    {
        public string? Token { get; set; }
    }
}
