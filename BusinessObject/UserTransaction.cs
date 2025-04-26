using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class UserTransaction
    {
        public int Id { get; set; }
        public PaymentItemType Type { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public long OrderId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int PaymentItemId { get; set; }
        public PaymentItem? PaymentItem { get; set; }
        //public PaymentType PaymentType { get; set; }
        public string? UserName { get; set; }
        public string? UserId { get; set; }
        public Account? User { get; set; }
    }

    //public enum PaymentType
    //{
    //    MOMO = 0,
    //}
}
