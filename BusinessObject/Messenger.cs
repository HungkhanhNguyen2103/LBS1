using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Messenger
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Content { get; set; }
        public DateTime ModifyDate { get; set; }
        public string? RoomId { get; set; }
        public string? CreateBy { get; set; }
        public string? To { get; set; }
    }
}
