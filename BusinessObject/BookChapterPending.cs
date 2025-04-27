using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class BookChapterPending
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? ChapterId { get; set; }
        public string? ChapterName { get; set; }
        public int ChapterNumber { get; set; }
        public string? Summary { get; set; }
        public string? AudioUrl { get; set; }
        public string? Content { get; set; }
        public DateTime ModifyDate { get; set; }
        public int WordNo { get; set; }
        public int Price { get; set; }
        public string? CreateBy { get; set; }
        public string? UserId { get; set; }

        //[BsonIgnore]
        //public Account? User { get; set; }
        //public Book? Book { get; set; }
    }

}
