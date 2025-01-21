using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.BaseModel
{
    public class EmailModel
    {
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public List<string>? To { get; set; } = new List<string>();
        public List<string>? CC { get; set; }
        public List<string>? BCC { get; set; }
    }
}
