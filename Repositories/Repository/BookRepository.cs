using BusinessObject;
using MongoDB.Driver;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LBSMongoDBContext _mongoContext;
        public BookRepository(LBSMongoDBContext mongoContext)
        {
            _mongoContext = mongoContext;
        }

        public async Task GetBookImages()
        {
            var bookImage = await _mongoContext.BookImages.Find(_ => true).ToListAsync();
            var s = await _mongoContext.BookChapters.Find(_ => true).ToListAsync();

            throw new NotImplementedException();
        }
    }
}
