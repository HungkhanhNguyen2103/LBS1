using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.BaseModel
{
    public class BookChapterVoiceModel
    {
        public string? ChapterId { get; set; }
        public string? FileUrl { get; set; }
        public List<SegmentModel> ContentWithTimes { get; set; } = new List<SegmentModel>();
        public string? Summary { get; set; }
        public string? ChapterName { get; set; }
        public int Price { get; set; }

    }
}
