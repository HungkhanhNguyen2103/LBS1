using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.BaseModel
{
    public class UserReportCommentModel
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public string? ModifyDate { get; set; }
        public DateTime ModifyDateValue { get; set; }
        public string? Image { get; set; }
        public int? UserReportId { get; set; }
        public string? CreateBy { get; set; }
    }
}
