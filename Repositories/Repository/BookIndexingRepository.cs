using BusinessObject;
using BusinessObject.BaseModel;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class BookIndexingRepository : IBookIndexingRepository
    {
        private readonly LBSDbContext LBSDbContext;
        public BookIndexingRepository() { 
        
        }

        public Task<ReponderModel<string>> SyncMeilisearch()
        {
            throw new NotImplementedException();
        }
    }
}
