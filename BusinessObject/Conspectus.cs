using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Conspectus
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Name { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Content { get; set; }
        public DateTime ModifyDate { get; set; }
        //public int BookId { get; set; }
        //public Book? Book { get; set; }
        public string? CreateBy { get; set; }
        public string? UserId { get; set; }
        public Account? User { get; set; }
    }
}
