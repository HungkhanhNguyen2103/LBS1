using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class LBSMongoDBContext
    {
        private readonly IMongoDatabase _mongoDatabase;
        public LBSMongoDBContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _mongoDatabase = client.GetDatabase(databaseName);
            //BookImages = GetCollection<BookImage>(typeof(BookImage).Name);
            BookChapters = GetCollection<BookChapter>(typeof(BookChapter).Name);
            //BookChapters = GetCollection<BookChapter>("BookChapterBackUp");
            Messengers = GetCollection<Messenger>(typeof(Messenger).Name);
            BookChapterVoices = GetCollection<BookChapterVoice>(typeof(BookChapterVoice).Name);
            BookChapterLogs = GetCollection<BookChapterLog>(typeof(BookChapterLog).Name);
            BookChapterPendings = GetCollection<BookChapterPending>(typeof(BookChapterPending).Name);
        }

        //public IMongoCollection<BookImage> BookImages { get; set; }
        public IMongoCollection<BookChapter> BookChapters { get; set; }
        public IMongoCollection<Messenger> Messengers { get; set; }
        public IMongoCollection<BookChapterVoice> BookChapterVoices { get; set; }
        public IMongoCollection<BookChapterPending> BookChapterPendings { get; set; }
        public IMongoCollection<BookChapterLog> BookChapterLogs { get; set; }

        private IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _mongoDatabase.GetCollection<T>(collectionName);
        }
    }
}
