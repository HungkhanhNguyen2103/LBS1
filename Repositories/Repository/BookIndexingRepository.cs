using BusinessObject;
using BusinessObject.BaseModel;
using Meilisearch;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
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
        private readonly IConfiguration _configuration;
        public BookIndexingRepository(LBSDbContext lBSDbContext, IConfiguration configuration) {
            LBSDbContext = lBSDbContext;
            _configuration = configuration;
        }

        public async Task<ReponderModel<string>> SyncMeilisearch()
        {
            var result = new ReponderModel<string>();
            var key = _configuration["Meilisearch:Key"];
            var books = await (from b in LBSDbContext.Books where b.Status == BookStatus.Done || b.Status == BookStatus.Published || b.Status == BookStatus.Continue 
                         select new BookIndexModel
                         {
                             Id = b.Id,
                             Name = b.Name,
                             Poster = b.Poster,
                             Author = b.CreateBy,
                             Categories = (from bc in LBSDbContext.BookCategories
                                           join c in LBSDbContext.Categories on bc.CategoryId equals c.Id
                                           where bc.BookId == b.Id
                                           select c.Name).ToList()
                         }).ToListAsync();
            try
            {
                //http://ireading.store:7700/
                var client = new MeilisearchClient("https://ireading.store/search/", key);
                var index = client.Index("books");

                await index.DeleteAllDocumentsAsync();
                await index.AddDocumentsAsync(books);
                var log = new MeilisearchLog
                {
                    CreateDate = DateTime.UtcNow,
                    Message = "Đã đồng bộ thành công",
                    Status = true
                };
                LBSDbContext.MeilisearchLogs.Add(log);
                await LBSDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var log = new MeilisearchLog
                {
                    CreateDate = DateTime.UtcNow,
                    Message = ex.Message,
                    Status = false
                };
                LBSDbContext.MeilisearchLogs.Add(log);
                await LBSDbContext.SaveChangesAsync();
                result.Message = ex.Message;
                return result;
            }

            result.Message = "Thành công";
            result.IsSussess = true;
            return result;
        }
    }
}
