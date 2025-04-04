using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.BaseModel
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Rating { get; set; }
        public string CreateDate { get; set; }
        public string Content { get; set; }
        public string Avatar { get; set; }
        public int BookId { get; set; }
    }
}
