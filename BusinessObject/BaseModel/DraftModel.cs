using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.BaseModel
{
    public class DraftModel
    {
        public string BookChapterId { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string ChapterName { get; set; }
        public string Content { get; set; }
    }
}
