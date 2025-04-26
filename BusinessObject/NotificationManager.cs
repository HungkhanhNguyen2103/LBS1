using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class NotificationManager
    {
        public int Id { get; set; }
        public string? NotifitiType { get; set; }
        public string? Message { get; set; }
        public string? Data { get; set; }
        public string? OptionData { get; set; }
        //public string Data2 { get; set; }
    }

    public enum NotifitiType
    {
        Payment = 0,
        ApproveBook = 1,

    }
}
