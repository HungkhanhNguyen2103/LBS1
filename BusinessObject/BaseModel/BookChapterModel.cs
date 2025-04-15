using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.BaseModel
{
    public class BookChapterModel
    {
        public string? Id { get; set; }
        public string? ChapterName { get; set; }
        public int ChaperId { get; set; }
        public string? Summary { get; set; }
        public string? FileName { get; set; }
        public string? Content { get; set; }
        public List<SummaryTime> ContentWithTime { get; set; } = new List<SummaryTime>();
        public string ModifyDate { get; set; }
        public BookType BookType { get; set; }
        //public int WordNo { get; set; }
        public int Price { get; set; }
        public string? CreateBy { get; set; }
        public int BookId { get; set; }
        
    }

    public class SummaryTime
    {
        public string Text { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
