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
        public BookType BookType { get; set; }
        public BookStatus Status { get; set; }
        public int AgeLimitType { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public string? CreateBy { get; set; }
        public int CategoryId { get; set; }
        public string? UserId { get; set; }
        //public IFormFile? FileUpload { get; set; }
    }
}
