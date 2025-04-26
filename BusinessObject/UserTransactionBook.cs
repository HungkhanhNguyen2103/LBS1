using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class UserTransactionBook
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime CreateDate { get; set; }
        public TranscationBookType Type { get; set; }
        public string? ChapterId { get; set; }
        public int? BookId { get; set; }
        public Book? Book { get; set; }
        public string? UserName { get; set; }
        public string? UserId { get; set; }
        public Account? User { get; set; }
    }

    public enum TranscationBookType
    {
        Read = 0,
        Voice = 1,
    }

    //public enum PaymentStatus
    //{

    //}
}
