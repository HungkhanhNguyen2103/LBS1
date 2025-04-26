using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class CommentUser
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public int? ParentId { get; set; }
        public DateTime ModifyDate { get; set; }
        public int BookId { get; set; }
        public string? UserId { get; set; }
        public Account? User { get; set; }
    }
}
