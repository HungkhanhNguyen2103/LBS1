using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.BaseModel
{
    public class BookModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Summary { get; set; }
        public int Price { get; set; }
        public string? Poster { get; set; }
        public BookTypePrice BookTypePrice { get; set; }
        public BookType BookType { get; set; }
        public BookStatus Status { get; set; }
        public int AgeLimitType { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public string? CreateBy { get; set; }
        public List<Category> ListCategories { get; set; } = new List<Category>();
        public List<string> Categories { get; set; } = new List<string>();
        public List<int> CategoryIds { get; set; } = new List<int>();
        public string? SubCategory { get; set; }
        public string? UserId { get; set; }
        public bool IsNewPublishedChapter { get; set; }
        public NewPublishedChapterModel? NewPublishedChapter { get; set; }
        //public IFormFile? FileUpload { get; set; }
    }

    public class NewPublishedChapterModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NewPulishedDateTime { get; set; }
    }
}
