using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class UserTranscationBook
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime CreateDate { get; set; }
        public string ChapterId { get; set; }
        public string? UserName { get; set; }
        public string? UserId { get; set; }
        public Account? User { get; set; }
    }

    //public enum PaymentStatus
    //{

    //}
}
