using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.BaseModel
{
    public class UserTranscationBookModel
    {
        public int Id { get; set; }
        public string PaymentName { get; set; }
        public int Price { get; set; }
        public string CreateDate { get; set; }
        public DateTime CreateDateFormat { get; set; }
        public PaymentNameEnum PaymentNameEnum { get; set; }
    }

    public enum PaymentNameEnum
    {
        Deposit = 0,
        Pay = 1
    }
}
