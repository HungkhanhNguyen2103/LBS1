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
        public int BookId { get; set; }
        public ChapterStatus Status { get; set; }
        public BookTypeStatus BookTypeStatus { get; set; }
        public string? CreateBy { get; set; }
        public string? UserId { get; set; }
        public Account? User { get; set; }
        public Book? Book { get; set; }
        public DateTime ModifyDate { get; set; }
    }

    public enum ChapterStatus
    {
        Open = 0,
        Close = 1,
    }

    public enum BookTypeStatus
    {
        Read = 0,
        Voice = 1,
    }
}
