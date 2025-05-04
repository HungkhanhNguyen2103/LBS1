using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class BookChapter
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? ChapterName { get; set; }
        public int ChapterNumber { get; set; }
        public string? Summary { get; set; }
        public string? AudioUrl { get; set; }
        public string? Content { get; set; }
        public DateTime ModifyDate { get; set; }
        public BookType BookType { get; set; }
        public int WordNo { get; set; }
        [BsonIgnore]
        public int ViewNo { get; set; }
        [BsonIgnore]
        public int RatingNo { get; set; }
        [BsonIgnore]
        public string? InappropriateWords { get; set; }
        [BsonIgnore]
        public string? CommentAI { get; set; }
        [BsonIgnore]
        public int Revenue { get; set; }
        public int Price { get; set; }
        public string? CreateBy { get; set; }
        public string? UserId { get; set; }
        public int BookId { get; set; }

        // 1- dang binh thuong
        // 2- Chen chuong
        // 3- Ban thao
        //[BsonIgnore]
        public int Type { get; set; }
        //public Account? User { get; set; }
        //public Book? Book { get; set; }
    }

}
