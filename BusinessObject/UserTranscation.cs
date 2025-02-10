using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class UserTranscation
    {
        public int Id { get; set; }
        public int Payment { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime CreateDate { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? UserName { get; set; }
        public string? UserId { get; set; }
        public Account? User { get; set; }
    }

    public enum PaymentType
    {
        MOMO = 0,
    }
}
