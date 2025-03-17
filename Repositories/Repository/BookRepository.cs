using Azure;
using BusinessObject;
using BusinessObject.BaseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using OpenAI.Chat;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LBSMongoDBContext _mongoContext;
        private readonly LBSDbContext _lBSDbContext;
        private ImageManager _imageManager;
        private AIGeneration _aIGeneration;
        private IAccountRepository _accountRepository;
        public BookRepository(LBSMongoDBContext mongoContext, LBSDbContext lBSDbContext,ImageManager imageManager, AIGeneration aIGeneration,IAccountRepository accountRepository)
        {
            _mongoContext = mongoContext;
            _lBSDbContext = lBSDbContext;
            _imageManager = imageManager;
            _aIGeneration = aIGeneration;
            _accountRepository = accountRepository;
        }

        public async Task<ReponderModel<string>> UpdateCategory(Category model)
        {
            var result = new ReponderModel<string>();
            if(string.IsNullOrEmpty(model.Name) || string.IsNullOrWhiteSpace(model.Name))
            {
                result.Message = "Hãy nhập thể loại";
                return result;
            }
            var cate = await _lBSDbContext.Categories.FirstOrDefaultAsync(c => c.Id == model.Id);
            if(cate == null) _lBSDbContext.Categories.Add(model);
            else
            {
                cate.Name = model.Name;
            }
            
            await _lBSDbContext.SaveChangesAsync();
            result.IsSussess = true;
            result.Message = "Cập nhật thành công";
            return result;
        }

        public async Task GetBookImages()
        {
            var bookImage = await _mongoContext.BookImages.Find(_ => true).ToListAsync();
            var s = await _mongoContext.BookChapters.Find(_ => true).ToListAsync();

            throw new NotImplementedException();
        }

        public async Task<ReponderModel<Category>> GetCategories()
        {
            var result = new ReponderModel<Category>();

            result.DataList = await _lBSDbContext.Categories.ToListAsync();
            result.IsSussess = true;
            return result;
        }

        public async Task<ReponderModel<string>> DeleteCategory(int id)
        {
            var result = new ReponderModel<string>();
            var cate = await _lBSDbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if(cate == null)
            {
                result.Message = "Không tồn tại dữ liệu";
                return result;
            }
             _lBSDbContext.Categories.Remove(cate);
            await _lBSDbContext.SaveChangesAsync();

            result.IsSussess = true;
            result.Message = "Xóa thành công";
            return result;
        }

        public async Task<ReponderModel<string>> UpdateBook(Book bookModel)
        {
            var result = new ReponderModel<string>();

            if (bookModel == null)
            {
                result.Message = "Dữ liệu không hợp lệ";
                return result;
            }

            if (string.IsNullOrEmpty(bookModel.Name))
            {
                result.Message = "Nhập tên truyện";
                return result;
            }

            if (string.IsNullOrEmpty(bookModel.Summary))
            {
                result.Message = "Nhập tóm tắt";
                return result;
            }

            //var memoryStream = new MemoryStream();
            //bookModel.FileUpload.CopyTo(memoryStream);
            //var base64Str = Convert.ToBase64String(memoryStream.ToArray());

            var book = await _lBSDbContext.Books.FirstOrDefaultAsync(c => c.Id == bookModel.Id);
            if(book == null)
            {
                result.Message = "Không tìm thấy truyện";
                return result;
            }

            book.Name = bookModel.Name;
            book.Summary = bookModel.Summary;
            book.CategoryId = bookModel.CategoryId;
            book.AgeLimitType = bookModel.AgeLimitType;
            book.BookType = bookModel.BookType;
            book.Price = bookModel.Price;
            book.Status = BookStatus.PendingPublication;
            //Poster = response.Data.Link,
            //CreateDate = DateTime.Now,
            book.ModifyDate = DateTime.Now;

            if (!string.IsNullOrEmpty(bookModel.Poster) && !bookModel.Poster.Contains("https://i.imgur.com"))
            {
                if (!bookModel.Poster.Contains("http"))
                {
                    bookModel.Poster = bookModel.Poster.Split("base64,")[1];
                    var response = await _imageManager.UploadImage(bookModel.Poster,"base64");
                    if (!response.Success)
                    {
                        result.Message = "Lỗi upload ảnh";
                        return result;
                    }
                    book.Poster = response.Data.Link;
                }
                else
                {
                    var response = await _imageManager.UploadImage(bookModel.Poster, "url");
                    if (!response.Success)
                    {
                        result.Message = "Lỗi upload ảnh";
                        return result;
                    }
                    book.Poster = response.Data.Link;
                }
            }
            else book.Poster = "https://i.imgur.com/KHD58yX.png";

            //_lBSDbContext.Books.Update(book);
            try
            {
                await _lBSDbContext.SaveChangesAsync();
                result.Message = "Cập nhật thành công";
                result.IsSussess = true;
            }
            catch (Exception ex)
            {
                result.Message = "Lỗi server";
            }
            return result;
        }

        public async Task<ReponderModel<string>> CreateBook(BookModel bookModel)
        {
            var result = new ReponderModel<string>();

            if(bookModel == null)
            {
                result.Message = "Dữ liệu không hợp lệ";
                return result;
            }

            if (string.IsNullOrEmpty(bookModel.Name))
            {
                result.Message = "Nhập tên truyện";
                return result;
            }

            if (string.IsNullOrEmpty(bookModel.Summary))
            {
                result.Message = "Nhập tóm tắt";
                return result;
            }

            //var memoryStream = new MemoryStream();
            //bookModel.FileUpload.CopyTo(memoryStream);
            //var base64Str = Convert.ToBase64String(memoryStream.ToArray());

            var book = new Book
            {
                Name = bookModel.Name,
                Summary = bookModel.Summary,
                CategoryId = bookModel.CategoryId,
                AgeLimitType = bookModel.AgeLimitType,
                BookType = bookModel.BookType,
                Price = bookModel.Price,
                CreateBy = bookModel.CreateBy,
                Status = BookStatus.PendingPublication,
                UserId = bookModel.UserId,
                //Poster = response.Data.Link,
                CreateDate = DateTime.Now,
                ModifyDate = DateTime.Now
            };

            if (!string.IsNullOrEmpty(bookModel.Poster) )
            {
                if (!bookModel.Poster.Contains("http"))
                {
                    bookModel.Poster = bookModel.Poster.Split("base64,")[1];
                    var response = await _imageManager.UploadImage(bookModel.Poster, "base64");
                    if (!response.Success)
                    {
                        result.Message = "Lỗi upload ảnh";
                        return result;
                    }
                    book.Poster = response.Data.Link;
                }
                else
                {
                    var response = await _imageManager.UploadImage(bookModel.Poster, "url");
                    if (!response.Success)
                    {
                        result.Message = "Lỗi upload ảnh";
                        return result;
                    }
                    book.Poster = response.Data.Link;
                }
            }
            else book.Poster = "https://i.imgur.com/KHD58yX.png";

            _lBSDbContext.Books.Add(book);
            try
            {
                await _lBSDbContext.SaveChangesAsync();
                result.Message = "Cập nhật thành công";
                result.IsSussess = true;
            }
            catch (Exception ex)
            {
                result.Message = "Lỗi server";
            }
            return result;
        }

        public async Task<ReponderModel<BookViewModel>> GetAllBookByUser(string userName)
        {
            var result = new ReponderModel<BookViewModel>();
            var roles = await _accountRepository.GetRolesByUserName(userName);

            var listBook = new List<Book>();

            if (roles.Contains(Role.Author))
            {
                listBook = await _lBSDbContext.Books.Where(c => c.CreateBy == userName).ToListAsync();
            }
            if (roles.Contains(Role.Manager))
            {
                listBook = await _lBSDbContext.Books.ToListAsync();
            }

            result.DataList = new List<BookViewModel>();
            foreach (var item in listBook)
            {
                var bookChapter = await GetNewChapterPulished(item);
                bookChapter.Id = item.Id;
                bookChapter.Name = item.Name;
                bookChapter.Poster = item.Poster;
                bookChapter.Author = item.CreateBy;
                bookChapter.Status = item.Status;
                result.DataList.Add(bookChapter);
            }

            result.IsSussess = true;

            return result;
        }

        public async Task<ReponderModel<string>> CreateBookChapter(BookChapter bookChapter)
        {
            var result = new ReponderModel<string>();
            if (bookChapter == null) {
                result.Message = "Data không hợp lệ";
                return result;
            }

            if (string.IsNullOrEmpty(bookChapter.ChapterName))
            {
                result.Message = "Tên chương không hợp lệ";
                return result;
            }

            if (string.IsNullOrEmpty(bookChapter.Content))
            {
                result.Message = "Nội dung không hợp lệ";
                return result;
            }

            if (!string.IsNullOrEmpty(bookChapter.Summary))
            {
                var res = await _aIGeneration.TextGenerateToSpeech(bookChapter.Summary);
                if (res.IsSussess) bookChapter.AudioUrl = res.Data;
            }

            bookChapter.ModifyDate = DateTime.Now;

            var listBookChapter = await GetListBookChapter(bookChapter.BookId);
            if(listBookChapter.IsSussess && listBookChapter.DataList.Count == 2)
            {
                var book = await _lBSDbContext.Books.FirstOrDefaultAsync(c => c.Id == bookChapter.BookId);
                if(book != null && book.Status == BookStatus.PendingPublication)
                {
                    book.Status = BookStatus.PendingApproval;
                    await _lBSDbContext.SaveChangesAsync();
                }
            }

            // chen chuong
            if (bookChapter.Type == 2)
            {
                var filter = Builders<BookChapter>.Filter.And(
                    Builders<BookChapter>.Filter.Where(p => p.ChaperId >= bookChapter.ChaperId),
                    Builders<BookChapter>.Filter.Where(p => p.BookId == bookChapter.BookId)
                    );

                var update = Builders<BookChapter>.Update.Inc("ChaperId", 1);

                await _mongoContext.BookChapters.UpdateManyAsync(filter, update);
            }
            await _mongoContext.BookChapters.InsertOneAsync(bookChapter);


            result.Message = "Cập nhật thành công";
            result.IsSussess = true;

            return result;
        }

        public async Task<ReponderModel<Book>> GetBook(int id)
        {
            var result = new ReponderModel<Book>();
            
            var book = await _lBSDbContext.Books.FirstOrDefaultAsync(c => c.Id == id);

            if (book == null) 
            {
                result.Message = "Data không hợp lệ";
                return result;
            }

            result.Data = book;
            result.IsSussess = true;
            return result;
        }

        public async Task<ReponderModel<BookChapter>> GetListBookChapter(int bookId)
        {
            var result = new ReponderModel<BookChapter>();
            var filter = Builders<BookChapter>.Filter.And(
                            Builders<BookChapter>.Filter.Where(p => p.BookId == bookId),
                            Builders<BookChapter>.Filter.Where(p => p.Type != 3)
                        );

            var sort = Builders<BookChapter>.Sort.Descending(x => x.ChaperId);

            var listBookChapter = await _mongoContext.BookChapters.Find(filter).Sort(sort).ToListAsync();

            var dataResult = listBookChapter.Select(c => new BookChapter
            {
                AudioUrl = c.AudioUrl,
                BookId = c.BookId,
                BookType = c.BookType,
                ChaperId = c.ChaperId,
                ChapterName = c.ChapterName,
                Content = c.Content,
                CreateBy = c.CreateBy,
                Id = c.Id,
                ModifyDate = c.ModifyDate,
                Price = c.Price,
                Summary = c.Summary,
                Type = c.Type,
                UserId = c.UserId,
                ViewNo = GetViewNo(c.Id),
                WordNo = c.WordNo
            }).ToList();

            result.IsSussess = true;
            result.DataList = dataResult;
            return result;
        }

        private int GetViewNo(string chapterId)
        {
            var data = _lBSDbContext.UserBookViews.Where(c => c.ChapterId == chapterId).Count();
            return data;
        }

        private async Task<BookViewModel> GetNewChapterPulished(Book book)
        {
            try
            {
                var filter = Builders<BookChapter>.Filter.And(
                                Builders<BookChapter>.Filter.Where(p => p.BookId == book.Id),
                                Builders<BookChapter>.Filter.Where(p => p.Type != 3)
                            );
                var sort = Builders<BookChapter>.Sort.Descending(x => x.ModifyDate);
                var listBookChapter = await _mongoContext.BookChapters.Find(filter).Sort(sort).ToListAsync();
                var lastedBookChapter = listBookChapter.FirstOrDefault();

                var bookViewModel = new BookViewModel
                {
                    //Author = lastedBookChapter != null ? lastedBookChapter.CreateBy : string.Empty,
                    BookStatus = BookStatusName.ListBookStatus[(int)book.Status],
                    NewPulished = lastedBookChapter != null && !string.IsNullOrEmpty(lastedBookChapter.ChapterName) ? lastedBookChapter.ChapterName : string.Empty,
                    NewPulishedDateTime = lastedBookChapter != null ? lastedBookChapter.ModifyDate.AddHours(7).ToString("HH:mm dd/MM/yyyy") : string.Empty,
                };

                return bookViewModel;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ReponderModel<string>> GenerateSummary(string input)
        {
            var result = await _aIGeneration.TextGenerate("Tạo tóm tắt tổi thiểu 200 từ được lấy dữ liệu từ đoạn text: " + input);
            return result;
        }

        public async Task<ReponderModel<string>> GeneratePoster(string input)
        {
            var result = await _aIGeneration.TextGenerateToImage("Tạo ảnh với dữ liệu từ tên truyện: " + input);
            return result;
        }

        public async Task<ReponderModel<string>> GenerateTextToAudio(string input)
        {
            var result = await _aIGeneration.TextGenerateToSpeech(input);
            return result;
        }

        public async Task<ReponderModel<string>> GenerateTextToImage(string input)
        {
            var result = await _aIGeneration.TextGenerateToImage(input);
            return result;
        }

        public async Task<ReponderModel<BookChapter>> GetBookChapter(string id)
        {
            var result = new ReponderModel<BookChapter>();
            var filter = Builders<BookChapter>.Filter.Eq(c => c.Id, id);
            result.Data = await _mongoContext.BookChapters.Find(filter).FirstOrDefaultAsync();
            result.IsSussess = true;
            return result;

        }

        public async Task<ReponderModel<string>> UpdateBookChapter(BookChapter bookChapter)
        {
            var filter = Builders<BookChapter>.Filter.Eq(c => c.Id, bookChapter.Id);
            var result = new ReponderModel<string>();
            if (bookChapter == null)
            {
                result.Message = "Data không hợp lệ";
                return result;
            }

            if (string.IsNullOrEmpty(bookChapter.ChapterName))
            {
                result.Message = "Tên chương không hợp lệ";
                return result;
            }

            if (string.IsNullOrEmpty(bookChapter.Content))
            {
                result.Message = "Nội dung không hợp lệ";
                return result;
            }

            var bookChapterRow = await _mongoContext.BookChapters.Find(filter).FirstOrDefaultAsync();
            if (bookChapterRow == null) 
            {
                result.Message = "Dữ liệu không tồn tại";
                return result;
            }
            if (!string.IsNullOrEmpty(bookChapter.Summary) && bookChapterRow.Summary != bookChapter.Summary)
            {
                //var res = await _aIGeneration.TextGenerateToSpeech(bookChapter.Summary);
                //if(res.IsSussess) bookChapter.AudioUrl = res.Data;
            }
            bookChapter.Type = 1;
            bookChapter.ModifyDate = DateTime.Now;


            var update = Builders<BookChapter>.Update
                        .Set(c => c.ChapterName, bookChapter.ChapterName)
                        .Set(c => c.ChaperId, bookChapter.ChaperId)
                        .Set(c => c.AudioUrl, bookChapter.AudioUrl)
                        .Set(c => c.Summary, bookChapter.Summary)
                        .Set(c => c.ModifyDate, bookChapter.ModifyDate)
                        .Set(c => c.Content, bookChapter.Content)
                        .Set(c => c.BookType, bookChapter.BookType)
                        .Set(c => c.WordNo, bookChapter.WordNo)
                        .Set(c => c.Price, bookChapter.Price)
                        .Set(c => c.Type, bookChapter.Type);

            await _mongoContext.BookChapters.UpdateOneAsync(filter,update);


            result.Message = "Cập nhật thành công";
            result.IsSussess = true;

            return result;
        }

        public async Task<ReponderModel<string>> DeleteChapterBook(string id)
        {
            var filter = Builders<BookChapter>.Filter.Eq(c => c.Id, id);
            var result = new ReponderModel<string>();
            await _mongoContext.BookChapters.DeleteOneAsync(filter);
            result.IsSussess = true;
            result.Message = "Xóa thành công";
            return result;
        }

        public async Task<ReponderModel<DraftModel>> GetDrafts(string userName)
        {
            var result = new ReponderModel<DraftModel>();
            var filter = Builders<BookChapter>.Filter.And(
                Builders<BookChapter>.Filter.Where(p => p.CreateBy == userName),
                Builders<BookChapter>.Filter.Where(p => p.Type == 3)
            );
            var sort = Builders<BookChapter>.Sort.Descending(x => x.ModifyDate);
            var res = await _mongoContext.BookChapters.Find(filter).Sort(sort).ToListAsync();

            foreach (var item in res)
            {
                var book = await _lBSDbContext.Books.FirstOrDefaultAsync(x => x.Id == item.BookId);
                var draft = new DraftModel
                {
                    BookChapterId = item.Id,
                    BookId = item.BookId,
                    BookName = book != null && !string.IsNullOrEmpty(book.Name) ? book.Name : string.Empty,
                    Content = item.Content,
                    ChapterName = item.ChapterName
                };
                result.DataList.Add(draft);
            }
            return result;
        }

        public async Task<ReponderModel<string>> ApproveBook(int bookId)
        {
            var result = new ReponderModel<string>();

            var book = await _lBSDbContext.Books.FirstOrDefaultAsync(c => c.Id == bookId);
            if(book == null || book.Status != BookStatus.PendingApproval)
            {
                result.Message = "Dữ liệu không chính xác";
                return result;
            }

            //var chapterBook = await GetListBookChapter(bookId);
            var filter = Builders<BookChapter>.Filter.And(
                            Builders<BookChapter>.Filter.Where(p => p.BookId >= bookId),
                            Builders<BookChapter>.Filter.Where(p => p.Type != 3)
                        );

            var sort = Builders<BookChapter>.Sort.Ascending(x => x.ChaperId);

            var listBookChapter = await _mongoContext.BookChapters.Find(filter).Sort(sort).ToListAsync();
            if (listBookChapter.Count < 3)
            {
                result.Message = "Dữ liệu chương truyện không chính xác";
                return result;
            }
            // duyet 3 chuong dau tien
            int i = 0;
            while (i < 3)
            {
                var item = listBookChapter[i];
                var resultChapter = await _aIGeneration.TextGenerate("Kiểm tra giúp tôi đoạn text có chứa từ ngữ không phù hợp không (format như sau: - Từ ngữ : 'A' => 'vị trí hiển thị câu chữa từ ấy' bạn chỉ cần trả lời theo format này): " + item.Content);
                var textRender = $@"<span> Tên chương: {item.ChapterName} <br></span>
                                    <span> Nội dung: <span style='cursor: pointer;color:blue' class='spContent' data-content='{item.Content}' data-toggle='modal' data-target='#exampleModal'>Chi tiết</span> <br></span>
                                    <span> Xác nhận AI: {resultChapter.Data} </span>";
                result.DataList.Add(textRender);
                i++;
            }

            result.IsSussess = true;
            result.Message = "Kết thúc quá trình duyệt";
            return result;
        }

        public async Task<ReponderModel<string>> UpdateApproveBook(int bookId)
        {
            var result = new ReponderModel<string>();

            var data = await _lBSDbContext.Books.FirstOrDefaultAsync(c => c.Id == bookId);
            if(data == null)
            {
                result.Message = "Data không hợp lệ";
                return result;
            }
            data.Status = BookStatus.Published;
            await _lBSDbContext.SaveChangesAsync();
            result.Message = "Duyệt thành công";
            result.IsSussess = true;
            return result; 
        }

        public async Task<ReponderModel<string>> UpdateBookChapterView(UserBookView model)
        {
            var result = new ReponderModel<string>();
            model.ModifyDate = DateTime.Now;
            _lBSDbContext.UserBookViews.Add(model);
            await _lBSDbContext.SaveChangesAsync();
            result.Message = "Cập nhật thành công";
            result.IsSussess = true;
            return result;
        }

        public async Task<ReponderModel<StatisticsChapterBook>> StatisticsChapterBook(int bookId)
        {
            var result = new ReponderModel<StatisticsChapterBook>();
            var listChapter = await GetListBookChapter(bookId);
            var listChapterBook = listChapter.DataList.OrderBy(c => c.ChaperId).ToList();

            var item = new StatisticsChapterBook
            {
                Title = "Lượt xem",
                Label = listChapterBook.Select(c => "Chương " + c.ChaperId).ToList(),
                Data = listChapterBook.Select(c => c.ViewNo.ToString()).ToList()
            };

            result.Data = item;
            result.IsSussess = true;
            return result;
        }

        public async Task<ReponderModel<StatisticsChapterBook>> StatisticsBook(string username)
        {
            var result = new ReponderModel<StatisticsChapterBook>();

            var listBook = await _lBSDbContext.Books.Where(c => c.CreateBy == username).ToListAsync();
            var item1 = new StatisticsChapterBook
            {
                Title = "Tổng lượt xem"
            };

            foreach (var item in listBook)
            {
                var listChapter = await GetListBookChapter(item.Id);
                var totalView = listChapter.DataList.Sum(c => c.ViewNo);
                item1.Label.Add(item.Name);
                item1.Data.Add(totalView.ToString());
            }
            result.Data = item1;
            result.IsSussess = true;
            return result;
        }
    }
}
