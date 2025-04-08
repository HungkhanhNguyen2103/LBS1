using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.BaseModel
{
    public class UserBookViewModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string? ChapterId { get; set; }
        public ChapterStatus Status { get; set; }
        public BookTypeStatus BookTypeStatus { get; set; }
        public string? CreateBy { get; set; }
        public string? UserId { get; set; }
    }

    public enum ChapterStatus
    {
        Open = 0,
        Close = 1,
    }
}
