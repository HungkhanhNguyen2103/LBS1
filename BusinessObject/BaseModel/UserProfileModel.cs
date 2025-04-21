using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.BaseModel
{
    public class UserProfileModel
    {
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? Avatar { get; set; }
        public bool IsConfirm { get; set; }
        public string? PaymentName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public long ClamPoint { get; set; }
        public long MinuteRead { get; set; }
        public long MinuteListen { get; set; }
    }
}
