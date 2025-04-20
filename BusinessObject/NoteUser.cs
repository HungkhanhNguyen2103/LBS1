using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class NoteUser
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? UserId { get; set; }
        public string? ChapterId { get; set; }
        public int? BookId { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public string? SelectedText { get; set; }
        public string? NoteContent { get; set; }
        public string? Color { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
