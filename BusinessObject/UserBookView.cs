using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class UserBookView
    {
        public int Id { get; set; }
        public string? ChapterId { get; set; }
        public string? CreateBy { get; set; }
        public string? UserId { get; set; }
        public Account? User { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
