using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.BaseModel
{
    public class StatisticsChapterBook
    {
        public List<string> Label { get; set; } = new List<string>();
        public List<string> Data { get; set; } = new List<string>();
        public string? Title { get; set; }
    }
}
