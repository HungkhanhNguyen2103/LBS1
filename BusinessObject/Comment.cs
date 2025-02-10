using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Comment
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Content { get; set; }
        public int Rating { get; set; }
        public DateTime CreateDate { get; set; }
        public int BookId { get; set; }
        public string? CreateBy { get; set; }
        public string? UserId { get; set; }
        public Account? User { get; set; }
        public Book? Book { get; set; }
    }
}
