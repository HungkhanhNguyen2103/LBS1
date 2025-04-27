using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class AuthorTransaction
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public TransactionStatus Status { get; set; }
        public string? UserId { get; set; }
        public Account? User { get; set; }
    }

    public enum TransactionStatus
    {
        Success = 0,
        Failed = 1,
        Pending = 2,
        Cancelled = 3
    }
}
