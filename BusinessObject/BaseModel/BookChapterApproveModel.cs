using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.BaseModel
{
    public class BookChapterApproveModel
    {
        public string ChapterId { get; set; }
        public int BookId { get; set; }
        public string ChapterName { get; set; }
        public string Content { get; set; }
        public string AiFeedback { get; set; }
        public string InappropriateWords { get; set; }
        public int TotalChapterApprove { get; set; }
        public int ChapterApprove { get; set; }
        public int ChapterUnApprove { get; set; }
    }
}
