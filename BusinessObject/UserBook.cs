using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class UserBook
    {
        public int Id { get; set; }
        public UserBookType BookType { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? UserName { get; set; }
        public string? UserId { get; set; }
        public int BookId { get; set; }
        public Account? User { get; set; }
        public Book? Book { get; set; }
    }

    public enum UserBookType
    {
        History = 0,
        Favourite = 1
    }
}
