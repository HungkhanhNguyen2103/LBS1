using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public class Account : IdentityUser
    {
        [Column(TypeName = "nvarchar(100)")]
        public string? FullName { get; set; }
        public string? Avatar { get; set; }
        public int Gender { get; set; }
        public string? Address { get; set; }
        public int ResetPassword { get; set; }
        public bool AccountActive { get; set; }
        public bool SocialAccount { get; set; }
    }
}
