using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.BaseModel
{
    public class CommentUserModel
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? Avatar { get; set; }
        public string? Content { get; set; }
        public string? ModifyDate { get; set; }
        public int? ParentId { get; set; }
        public int Level { get; set; }

    }
}
