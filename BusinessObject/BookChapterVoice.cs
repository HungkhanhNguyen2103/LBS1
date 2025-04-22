using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class BookChapterVoice
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? FileName { get; set; }
        public string? ChapterId { get; set; }
        public string? ContentWithTime { get; set; }
        public int Price { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
