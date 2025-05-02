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
        public BookTypePrice BookTypePrice { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string? Poster { get; set; }
        public BookType BookType { get; set; }
        public BookStatus Status { get; set; }
        public int AgeLimitType { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public string? SubCategory { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? CreateBy { get; set; }
        //public int CategoryId { get; set; }
        public string? UserId { get; set; }
        //public Category? Category { get; set; }
        public Account? User { get; set; }
        public ICollection<BookCategory>? BookCategories { get; set; }
    }

    public enum BookType
    {
        Free = 0,
        Payment = 1,
        //ChapterBook
        PendingApproval = 2,
        Decline = 3,
        Hidden = 4,

        //cap nhat lai chuong
        AwaitApproval = 5,
        //dang cap nhat
        LoadingEdit = 6,

        // Ban thao
        Draft = 7
    }

    public enum BookTypePrice
    {
        PayByChapter = 0,
        PayByBook = 1
    }

    public enum BookStatus
    {
        Done = 0,
        Continue = 1,
        Pause = 2,
        PendingPublication = 3,
        Published = 4,
        PendingApproval = 5
    }

    public class BookStatusName
    {
        public static List<string> ListBookStatus = new List<string> { "Hoàn thành", "Còn tiếp" , "Tạm dừng" , "Chờ xuất bản" , "Đã xuất bản","Chờ duyệt" };
    }
}
