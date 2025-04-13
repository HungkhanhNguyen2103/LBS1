using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.BaseModel
{
    public class PaymentRequestModel
    {
        //public int orderCode { get; set; }
        public int amount { get; set; }
        public string description { get; set; }
        public string domain { get; set; }
        //public string returnUrl { get; set; }
        //public string cancelUrl { get; set; }
        public List<PaymentItemModel> items { get; set; } = new List<PaymentItemModel>();
        public string buyerEmail { get; set; }
        //public string buyerPhone { get; set; }
        public int type { get; set; } // 0: nap goi, 1: dang ky hoi vien
        public string paymentKey { get; set; }
    }

    public class PaymentItemModel
    {
        public string name { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
    }
}
