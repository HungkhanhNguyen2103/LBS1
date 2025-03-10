using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.BaseModel
{
    public class ReportModel
    {
        public int TotalAccount { get; set; }
        public int TotalCategory { get; set; }
        public int TotalBookPending { get; set; }
        public int TotalBookPublish { get; set; }
    }
}
