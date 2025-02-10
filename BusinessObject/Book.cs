using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Book
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string? Name { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Summary { get; set; }
        public int Price { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Poster { get; set; }
        public BookType BookType { get; set; }
        public BookStatus Status { get; set; }
        public int AgeLimitType { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? CreateBy { get; set; }
        public int CategoryId { get; set; }
        public string? UserId { get; set; }
        public Category? Category { get; set; }
        public Account? User { get; set; }
    }

    public enum BookType
    {
        Free = 0,
        Payment = 1,
    }

    public enum BookStatus
    {
        Done = 0,    
    }
}
