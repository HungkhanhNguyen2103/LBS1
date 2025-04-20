using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class PaymentItem
    {
        public int Id { get; set; }
        public string? PaymentName { get; set; }
        // gia xu
        public int Amount { get; set; }
        public string? Description { get; set; }
        public PaymentItemType Type { get; set; }
        // gia tien
        public int AmountMoney { get; set; }
        public int ExpiredMinute { get; set; }
    }

    public enum PaymentItemType
    {
        Regular = 0,
        Membership = 1,
    }
}
