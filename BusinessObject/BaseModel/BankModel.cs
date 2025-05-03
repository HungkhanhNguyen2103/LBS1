using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.BaseModel
{
    public class BankModel
    {
        public int Id { get; set; }
        public string BankId { get; set; }
        public string BankName { get; set; }
        public string? UserId { get; set; }
    }
}
