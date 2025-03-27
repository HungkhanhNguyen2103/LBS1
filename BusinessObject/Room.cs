using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Room
    {
        public int Id { get; set; }
        public string? RoomName { get; set; }
        public string? ManagerUser { get; set; }       
        public string? ManagerId { get; set; }
        public Account? Manager { get; set; }
        public string? AuthorUser { get; set; }
        public string? AuthorId { get; set; }
        public Account? Author { get; set; }
        public string? ChapterBookId { get; set; }
    }
}
