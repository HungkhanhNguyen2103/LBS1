using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class UserReport
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Image { get; set; }
        public UserReportType ReportType { get; set; }
        public UserReportStatus UserReportStatus { get; set; }
        //public BookChapter? BookChapter { get; set; }
        public DateTime ModifyDate { get; set; }
        public string? CreateBy { get; set; }
        public string? Author { get; set; }
        public string? UserId { get; set; }
        public Account? User { get; set; }
    }
    public enum UserReportType
    {
        User,
        Author,
    }

    public enum UserReportStatus
    {
        Done,
        Pending,
    }
}
