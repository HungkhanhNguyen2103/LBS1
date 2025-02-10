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
        public int ChaperId { get; set; }
        public string? Content { get; set; }
        public DateTime CreateDate { get; set; }
        public int BookType { get; set; }
        public string? CreateBy { get; set; }
        public string? UserId { get; set; }
        public int BookId { get; set; }
        public Account? User { get; set; }
        public Book? Book { get; set; }
    }
}
