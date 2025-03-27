using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.BaseModel
{
    public class RoomModel
    {
        public string? RoomName { get; set; }
        public string? AuthorUser { get; set; }
        public string? AuthorFullName { get; set; }
        public string? ManagerUser { get; set; }
        public string? ManagerFullName { get; set; }
        public List<Messenger>? Messagers { get; set; }
    }
}
