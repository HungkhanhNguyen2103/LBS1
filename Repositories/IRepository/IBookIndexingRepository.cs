using BusinessObject.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IBookIndexingRepository
    {
        Task<ReponderModel<string>> SyncMeilisearch();
    }
}
