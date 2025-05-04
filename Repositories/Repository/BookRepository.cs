using Azure;
using BusinessObject;
using BusinessObject.BaseModel;
using HtmlAgilityPack;
using Meilisearch;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace Repositories.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LBSMongoDBContext _mongoContext;
        private readonly LBSDbContext _lBSDbContext;
        private ImageManager _imageManager;
        private AIGeneration _aIGeneration;
        private readonly IConfiguration _configuration;
        private IAccountRepository _accountRepository;
        public BookRepository(LBSMongoDBContext mongoContext, 
            LBSDbContext lBSDbContext, ImageManager imageManager, 
            AIGeneration aIGeneration, IAccountRepository accountRepository,
            IConfiguration configuration)
        {
            _mongoContext = mongoContext;
            _lBSDbContext = lBSDbContext;
            _imageManager = imageManager;
            _aIGeneration = aIGeneration;
            _accountRepository = accountRepository;
            _configuration = configuration;
        }

        public async Task<ReponderModel<string>> UpdateCategory(Category model)
        {
            var result = new ReponderModel<string>();
            if (string.IsNullOrEmpty(model.Name) || string.IsNullOrWhiteSpace(model.Name))
            {
                result.Message = "Hãy nhập danh mục";
                return result;
            }

            var cateExist = await _lBSDbContext.Categories.FirstOrDefaultAsync(c => c.Name == model.Name);
            if (cateExist != null)
            {
                result.Message = "Danh mục đã được tạo trước đó";
                return result;
            }

            var cate = await _lBSDbContext.Categories.FirstOrDefaultAsync(c => c.Id == model.Id);
            if (cate == null) _lBSDbContext.Categories.Add(model);
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
            //var bookImage = await _mongoContext.BookImages.Find(_ => true).ToListAsync();
            //var s = await _mongoContext.BookChapters.Find(_ => true).ToListAsync();

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
            if (cate == null)
            {
                result.Message = "Không tồn tại dữ liệu";
                return result;
            }


            var listCateBook = await _lBSDbContext.BookCategories.Where(c => c.CategoryId == id).ToListAsync();

            _lBSDbContext.Categories.Remove(cate);
            _lBSDbContext.BookCategories.RemoveRange(listCateBook);
            await _lBSDbContext.SaveChangesAsync();

            result.IsSussess = true;
            result.Message = "Xóa thành công";
            return result;
        }

        public async Task<ReponderModel<string>> UpdateBook(BookModel bookModel)
        {
            var result = new ReponderModel<string>();

            if (bookModel == null)
            {
                result.Message = "Dữ liệu không hợp lệ";
                return result;
            }

            if (string.IsNullOrEmpty(bookModel.Name))
            {
                result.Message = "Nhập tên sách";
                return result;
            }

            if (string.IsNullOrEmpty(bookModel.Summary))
            {
                result.Message = "Nhập giới thiệu";
                return result;
            }


            if (bookModel.CategoryIds == null || bookModel.CategoryIds.Count == 0)
            {
                result.Message = "Chọn danh mục";
                return result;
            }

            //var memoryStream = new MemoryStream();
            //bookModel.FileUpload.CopyTo(memoryStream);
            //var base64Str = Convert.ToBase64String(memoryStream.ToArray());

            var book = await _lBSDbContext.Books.FirstOrDefaultAsync(c => c.Id == bookModel.Id);
            if (book == null)
            {
                result.Message = "Không tìm thấy truyện";
                return result;
            }

            var listOldBookCategory = await _lBSDbContext.BookCategories.Where(c => c.BookId == book.Id && c.CategoryId.HasValue).Select(c => c.CategoryId.Value).ToListAsync();

            // category book remove
            var listIdsRemove = listOldBookCategory.Except(bookModel.CategoryIds).ToList();
            var listBookCateRemove = await _lBSDbContext.BookCategories.Where(c => listIdsRemove.Contains(c.CategoryId.Value)).ToListAsync();
            _lBSDbContext.BookCategories.RemoveRange(listBookCateRemove);

            // category book add
            var listIdsAdd = bookModel.CategoryIds.Except(listOldBookCategory).ToList();
            var listBookCateAdd = listIdsAdd.Select(c => new BookCategory
            {
                CategoryId = c,
                BookId = book.Id
            }).ToList();
            _lBSDbContext.BookCategories.AddRange(listBookCateAdd);

            book.Name = bookModel.Name;
            book.Summary = bookModel.Summary;
            //book.CategoryId = bookModel.CategoryId;
            book.AgeLimitType = bookModel.AgeLimitType;
            book.BookType = bookModel.BookType;
            book.Price = bookModel.Price;
            book.SubCategory = bookModel.SubCategory;
            //book.Status = BookStatus.PendingPublication;
            //Poster = response.Data.Link,
            //CreateDate = DateTime.Now,
            book.ModifyDate = DateTime.UtcNow;

            if (!string.IsNullOrEmpty(bookModel.Poster))
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
                else if (book.Poster != bookModel.Poster)
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

            if (bookModel == null)
            {
                result.Message = "Dữ liệu không hợp lệ";
                return result;
            }

            if (string.IsNullOrEmpty(bookModel.Name))
            {
                result.Message = "Nhập tên sách";
                return result;
            }

            if (string.IsNullOrEmpty(bookModel.Summary))
            {
                result.Message = "Nhập giới thiệu";
                return result;
            }

            if (bookModel.CategoryIds == null || bookModel.CategoryIds.Count == 0)
            {
                result.Message = "Chọn danh mục";
                return result;
            }

            //var memoryStream = new MemoryStream();
            //bookModel.FileUpload.CopyTo(memoryStream);
            //var base64Str = Convert.ToBase64String(memoryStream.ToArray());

            var book = new Book
            {
                Name = bookModel.Name,
                Summary = bookModel.Summary,
                //CategoryId = bookModel.CategoryId,
                AgeLimitType = bookModel.AgeLimitType,
                BookType = bookModel.BookType,
                Price = bookModel.Price,
                CreateBy = bookModel.CreateBy,
                Status = BookStatus.PendingPublication,
                UserId = bookModel.UserId,
                SubCategory = bookModel.SubCategory,
                BookTypePrice = bookModel.BookTypePrice,
                //BookCategories = bookModel.CategoryIds.Select(c => new BookCategory
                //{
                //    CategoryId = c
                //}).ToList(),
                //Poster = response.Data.Link,
                CreateDate = DateTime.UtcNow,
                ModifyDate = DateTime.UtcNow,

            };

            if (!string.IsNullOrEmpty(bookModel.Poster))
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
            await _lBSDbContext.SaveChangesAsync();
            try
            {
                // create category book
                foreach (var categoryId in bookModel.CategoryIds)
                {
                    _lBSDbContext.BookCategories.Add(new BookCategory
                    {
                        BookId = book.Id,
                        CategoryId = categoryId
                    });
                }

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
            try
            {
                var roles = await _accountRepository.GetRolesByUserName(userName);

                if (roles.Count == 0)
                {
                    roles = new List<string> { Role.Visitor };
                }

                var listBook = new List<Book>();

                if (roles.Contains(Role.Author))
                {
                    listBook = await _lBSDbContext.Books.Where(c => c.CreateBy == userName).ToListAsync();
                }
                else if (roles.Contains(Role.Manager))
                {
                    listBook = await _lBSDbContext.Books.ToListAsync();
                }
                else if (roles.Contains(Role.Admin))
                {
                    listBook = await _lBSDbContext.Books.ToListAsync();
                }
                else if (roles.Contains(Role.Visitor))
                {
                    listBook = await _lBSDbContext.Books.Where(c => c.Status == BookStatus.Done || c.Status == BookStatus.Published || c.Status == BookStatus.Continue).ToListAsync();
                }


                result.DataList = new List<BookViewModel>();
                foreach (var item in listBook)
                {
                    try
                    {
                        var bookChapter = await GetNewChapterPulished(item);
                        bookChapter.Id = item.Id;
                        bookChapter.Name = item.Name;
                        bookChapter.Poster = item.Poster;
                        bookChapter.Author = item.CreateBy;
                        bookChapter.Status = item.Status;
                        //bookChapter.
                        result.DataList.Add(bookChapter);
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                }
                result.DataList = result.DataList.OrderByDescending(c => c.NewPulishedDateTimeFormat).ToList();

                result.IsSussess = true;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }


            return result;
        }

        public async Task<ReponderModel<string>> CreateBookChapter(BookChapter bookChapter)
        {
            bookChapter.Id = null;
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

            if (string.IsNullOrEmpty(bookChapter.Content) || !HasContent(bookChapter.Content))
            {
                result.Message = "Nội dung không hợp lệ";
                return result;
            }

            if (string.IsNullOrEmpty(bookChapter.Summary))
            {
                var res = await GenerateSummary(bookChapter.Content);
                if (res.IsSussess) bookChapter.Summary = res.Data;
            }

            if(bookChapter.Price < 0)
            {
                result.Message = "Giá tiền không hợp lệ";
                return result;
            }

            bookChapter.Content = await UploadImageContent(bookChapter.Content);
            bookChapter.BookType = BookType.PendingApproval;
            bookChapter.ModifyDate = DateTime.Now;

            var book = await _lBSDbContext.Books.FirstOrDefaultAsync(c => c.Id == bookChapter.BookId);
            if(book == null)
            {
                result.Message = "Không có thông tin sách";
                return result;
            }
            if (book.BookTypePrice == BookTypePrice.PayByChapter)
            {
                var listBookChapter = await GetListBookChapter(bookChapter.BookId);
                if (listBookChapter.IsSussess && listBookChapter.DataList.Count == 2)
                {
                    if (book != null && book.Status == BookStatus.PendingPublication)
                    {
                        book.Status = BookStatus.PendingApproval;
                        await _lBSDbContext.SaveChangesAsync();
                    }
                }
            }


            // chen chuong
            if (bookChapter.Type == 2)
            {
                var filter = Builders<BookChapter>.Filter.And(
                    Builders<BookChapter>.Filter.Where(p => p.ChapterNumber == bookChapter.ChapterNumber),
                    Builders<BookChapter>.Filter.Where(p => p.BookId == bookChapter.BookId)
                    );

                var update = Builders<BookChapter>.Update.Inc("ChaperId", 1);

                await _mongoContext.BookChapters.UpdateManyAsync(filter, update);
            }

            if(bookChapter.Type == 3) bookChapter.BookType = BookType.Draft;

            //if (bookChapter.Type == 3 && (book.Status == BookStatus.PendingPublication || book.Status == BookStatus.PendingApproval)) bookChapter.BookType = BookType.Draft;

            //insert to book chapter


            try
            {
                await _mongoContext.BookChapters.InsertOneAsync(bookChapter);
                var bookChapterLog = new BookChapterLog
                {
                    ChapterId = bookChapter.Id,
                    CommentAI = bookChapter.CommentAI,
                    InappropriateWords = bookChapter.InappropriateWords
                };
                await _mongoContext.BookChapterLogs.InsertOneAsync(bookChapterLog);

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }



            result.Message = "Cập nhật thành công";
            result.IsSussess = true;

            return result;
        }

        private async Task<string> UploadImageContent(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var imgNodes = doc.DocumentNode.SelectNodes("//img");
            //var srcList = new List<string>();

            if (imgNodes != null)
            {
                foreach (var img in imgNodes)
                {
                    var src = img.GetAttributeValue("src", null);
                    if (!string.IsNullOrEmpty(src))
                    {
                        //srcList.Add(src);
                        if (src.Contains("base64"))
                        {
                            var src1 = src.Split("base64,")[1];
                            var result = await _imageManager.UploadImage(src1, "base64");
                            if (result.Success)
                            {
                                html = html.Replace(src, result.Data.Link);
                            }
                        }
                        
                    }
                }
            }
            return html;
        }

        private bool HasContent(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var text = doc.DocumentNode.InnerText;
            return !string.IsNullOrWhiteSpace(text);
        }

        public async Task<ReponderModel<BookModel>> GetBook(int id)
        {
            var result = new ReponderModel<BookModel>();

            var book = await _lBSDbContext.Books.Include(c => c.BookCategories).ThenInclude(c => c.Category).FirstOrDefaultAsync(c => c.Id == id);

            if (book == null)
            {
                result.Message = "Data không hợp lệ";
                return result;
            }

            var bookModel = new BookModel
            {
                Id = book.Id,
                Name = book.Name,
                AgeLimitType = book.AgeLimitType,
                BookType = book.BookType,
                CreateBy = book.CreateBy,
                CreateDate = book.CreateDate,
                ModifyDate = book.ModifyDate,
                Poster = book.Poster,
                Price = book.Price,
                Status = book.Status,
                SubCategory = book.SubCategory,
                Summary = book.Summary,
                UserId = book.UserId,
                BookTypePrice = book.BookTypePrice,
                //ViewNo = await _lBSDbContext.UserBookViews.Where(c => c.Status == ChapterStatus.Open && c.).CountAsync(),
                ListCategories = book.BookCategories != null ? book.BookCategories.Select(c => c.Category).ToList() : new List<Category>(),
                CategoryIds = book.BookCategories != null ? book.BookCategories.Select(c => c.CategoryId.Value).ToList() : new List<int>(),
            };

            var newChapterModel = await GetNewChapterPulished(book);
            bookModel.IsNewPublishedChapter = string.IsNullOrEmpty(newChapterModel.NewPulished) ? false : true;
            bookModel.NewPublishedChapter = new NewPublishedChapterModel
            {
                Id = newChapterModel.ChapterId,
                Name = newChapterModel.NewPulished,
                NewPulishedDateTime = newChapterModel.NewPulishedDateTime,
            };

            result.Data = bookModel;
            result.IsSussess = true;
            return result;
        }

        public async Task<ReponderModel<BookChapter>> GetListBookChapter(int bookId)
        {
            var result = new ReponderModel<BookChapter>();
            var filter = Builders<BookChapter>.Filter.And(
                            Builders<BookChapter>.Filter.Where(p => p.BookId == bookId)
                            //Builders<BookChapter>.Filter.Where(p => p.Type != 3)
                        );

            var sort = Builders<BookChapter>.Sort.Descending(x => x.ChapterNumber);

            var listBookChapter = await _mongoContext.BookChapters.Find(filter).Sort(sort).ToListAsync();

            var dataResult = listBookChapter.Select(c => new BookChapter
            {
                AudioUrl = c.AudioUrl,
                BookId = c.BookId,
                BookType = c.BookType,
                ChapterNumber = c.ChapterNumber,
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
                Revenue = GetRevenueChapter(c.Id),
                WordNo = c.WordNo
            }).ToList();

            result.IsSussess = true;
            result.DataList = dataResult;
            return result;
        }

        private int GetRevenueChapter(string chapterId)
        {
            var data = _lBSDbContext.UserTranscationBooks.Where(c => c.ChapterId == chapterId).Sum(c => c.Amount);
            return data;
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
                    Price = book.Price,
                    BookTypePrice = book.BookTypePrice,
                    BookStatus = BookStatusName.ListBookStatus[(int)book.Status],
                    ChapterId = lastedBookChapter != null && !string.IsNullOrEmpty(lastedBookChapter.Id)  ? lastedBookChapter.Id : string.Empty,    
                    NewPulished = lastedBookChapter != null && !string.IsNullOrEmpty(lastedBookChapter.ChapterName) ? lastedBookChapter.ChapterName : string.Empty,
                    NewPulishedDateTime = lastedBookChapter != null ? lastedBookChapter.ModifyDate.AddHours(7).ToString("HH:mm dd/MM/yyyy") : string.Empty,
                    NewPulishedDateTimeFormat = lastedBookChapter != null ? lastedBookChapter.ModifyDate.AddHours(7) : DateTime.MinValue,
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
            var result = await _aIGeneration.TextGenerate("Tạo tóm tắt tổi thiểu 200 từ được lấy dữ liệu từ đoạn text (bỏ qua phần hình ảnh hay url hình ảnh, chỉ tập trung vào text): " + input);
            return result;
        }

        public async Task<ReponderModel<string>> GeneratePoster(string name, string summary)
        {
            var result = await _aIGeneration.TextGenerateToImage("Tạo ảnh với dữ liệu từ tên sách: " + name + " và (hoặc) giới thiệu: " + summary);
            return result;
        }

        public async Task<ReponderModel<string>> GenerateTextToAudio(string input,string filename)
        {
            var result = await _aIGeneration.TextGenerateToSpeech(input, filename);
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

            var resultChapterLog = await _mongoContext.BookChapterLogs.Find(c => c.ChapterId == id).FirstOrDefaultAsync();
            if(resultChapterLog != null)
            {
                result.Data.CommentAI = resultChapterLog.CommentAI;
                result.Data.InappropriateWords = resultChapterLog.InappropriateWords;
            }

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

            if (string.IsNullOrEmpty(bookChapter.Content) || !HasContent(bookChapter.Content))
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

            if (bookChapter.Price < 0)
            {
                result.Message = "Giá tiền không hợp lệ";
                return result;
            }

            if (string.IsNullOrEmpty(bookChapter.Summary))
            {
                var res = await GenerateSummary(bookChapter.Content);
                if (res.IsSussess) bookChapter.Summary = res.Data;
                // comment sua lai logic
                //var res = await _aIGeneration.TextGenerateToSpeech(bookChapter.Summary);
                //if (res.IsSussess) bookChapter.AudioUrl = res.Data;
            }


            //else bookChapter.AudioUrl = bookChapterRow.AudioUrl;
            //bookChapter.Type = 1;
            bookChapter.Content = await UploadImageContent(bookChapter.Content);
            bookChapter.ModifyDate = DateTime.Now;

            //if(bookChapterRow.BookType )
            //bookChapter.BookType = BookType.PendingApproval;

            var book = await _lBSDbContext.Books.FirstOrDefaultAsync(c => c.Id == bookChapter.BookId);
            if(book == null)
            {
                result.Message = "Sách không tồn tại";
                return result;
            }

            bookChapter.BookType = BookType.PendingApproval;

            // chuyen trang thai dang cap nhat
            //if (bookChapter.Type == 3)
            //{
            //    if (book.Status != BookStatus.PendingPublication && book.Status != BookStatus.PendingPublication && (bookChapterRow.BookType == BookType.Free || bookChapterRow.BookType == BookType.Payment))
            //    {
            //        bookChapter.BookType = BookType.LoadingEdit;

            //        var bookChapterPending = new BookChapterPending
            //        {
            //            ChapterId = bookChapter.Id,
            //            ChapterNumber = bookChapter.ChapterNumber,
            //            ChapterName = bookChapter.ChapterName,
            //            Content = bookChapter.Content,
            //            ModifyDate = DateTime.UtcNow,
            //            Summary = bookChapter.Summary,
            //            WordNo = bookChapter.WordNo
            //        };

            //        await _mongoContext.BookChapterPendings.InsertOneAsync(bookChapterPending);

            //        var bookChapterLog1 = await _mongoContext.BookChapterLogs.Find(c => c.ChapterId == bookChapter.Id).FirstOrDefaultAsync();
            //        if (bookChapterLog1 == null)
            //        {
            //            bookChapterLog1 = new BookChapterLog
            //            {
            //                ChapterId = bookChapter.Id,
            //                CommentAI = bookChapter.CommentAI,
            //                InappropriateWords = bookChapter.InappropriateWords
            //            };
            //            await _mongoContext.BookChapterLogs.InsertOneAsync(bookChapterLog1);
            //        }
            //        else
            //        {
            //            var filterLog1 = Builders<BookChapterLog>.Filter.Eq(c => c.ChapterId, bookChapter.Id);

            //            var updateLog1 = Builders<BookChapterLog>.Update
            //                    .Set(c => c.CommentAI, bookChapter.CommentAI)
            //                    .Set(c => c.InappropriateWords, bookChapter.InappropriateWords);

            //            await _mongoContext.BookChapterLogs.UpdateOneAsync(filterLog1, updateLog1);
            //        }

            //        var updateChapterType = Builders<BookChapter>.Update
            //                .Set(c => c.BookType, bookChapter.BookType);

            //        await _mongoContext.BookChapters.UpdateOneAsync(filter, updateChapterType);

            //        result.Message = "Cập nhật thành công";
            //        result.IsSussess = true;

            //        return result;
            //    }

            //    else bookChapter.BookType = BookType.Draft;
            //}

            // chuyen trang thai dang cap nhat
            //if (bookChapter.Type == 3 && (bookChapterRow.BookType == BookType.Free || bookChapterRow.BookType == BookType.Payment))
            //{

            //}
            if (bookChapter.Type == 3) bookChapter.BookType = BookType.Draft;
            var update = Builders<BookChapter>.Update
                        .Set(c => c.ChapterName, bookChapter.ChapterName)
                        .Set(c => c.ChapterNumber, bookChapter.ChapterNumber)
                        .Set(c => c.AudioUrl, bookChapter.AudioUrl)
                        .Set(c => c.Summary, bookChapter.Summary)
                        .Set(c => c.ModifyDate, bookChapter.ModifyDate)
                        .Set(c => c.Content, bookChapter.Content)
                        .Set(c => c.BookType, bookChapter.BookType)
                        .Set(c => c.WordNo, bookChapter.WordNo)
                        .Set(c => c.Price, bookChapter.Price)
                        .Set(c => c.Type, bookChapter.Type);

            await _mongoContext.BookChapters.UpdateOneAsync(filter, update);

            var bookChapterLog = await _mongoContext.BookChapterLogs.Find(c => c.ChapterId == bookChapter.Id).FirstOrDefaultAsync();
            if(bookChapterLog == null)
            {
                bookChapterLog = new BookChapterLog
                {
                    ChapterId = bookChapter.Id,
                    CommentAI = bookChapter.CommentAI,
                    InappropriateWords = bookChapter.InappropriateWords
                };
                await _mongoContext.BookChapterLogs.InsertOneAsync(bookChapterLog);
            }
            else
            {
                var filterLog = Builders<BookChapterLog>.Filter.Eq(c => c.ChapterId, bookChapter.Id);

                var updateLog = Builders<BookChapterLog>.Update
                        .Set(c => c.CommentAI, bookChapter.CommentAI)
                        .Set(c => c.InappropriateWords, bookChapter.InappropriateWords);

                await _mongoContext.BookChapterLogs.UpdateOneAsync(filterLog, updateLog);
            }


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

            //var resultBookChapterPending = new ReponderModel<DraftModel>();
            //var filterBcp = Builders<BookChapterPending>.Filter.And(
            //    Builders<BookChapterPending>.Filter.Where(p => p.CreateBy == userName)
            //);
            ////var sort = Builders<BookChapter>.Sort.Descending(x => x.ModifyDate);
            //var resBcp = await _mongoContext.BookChapterPendings.Find(filterBcp).ToListAsync();

            //for

            return result;
        }

        public async Task<ReponderModel<BookChapterApproveModel>> ApproveBook(int bookId)
        {
            var result = new ReponderModel<BookChapterApproveModel>();

            var resultData = new BookChapterApproveModel();

            var book = await _lBSDbContext.Books.FirstOrDefaultAsync(c => c.Id == bookId);
            if (book == null || (book.Status != BookStatus.PendingApproval && book.Status != BookStatus.Continue && book.Status != BookStatus.Pause && book.Status != BookStatus.Published))
            {
                result.Message = "Dữ liệu không chính xác";
                return result;
            }

            //var chapterBook = await GetListBookChapter(bookId);
            var filter = Builders<BookChapter>.Filter.And(
                            Builders<BookChapter>.Filter.Where(p => p.BookId == bookId),
                            Builders<BookChapter>.Filter.Where(p => p.Type != 3),
                            Builders<BookChapter>.Filter.Where(p => p.BookType == BookType.PendingApproval)
                        );

            var sort = Builders<BookChapter>.Sort.Ascending(x => x.ChapterNumber);

            var listBookChapter = await _mongoContext.BookChapters.Find(filter).Sort(sort).ToListAsync();
            //if (listBookChapter.Count < 3)
            //{
            //    result.Message = "Dữ liệu chương sách không chính xác";
            //    return result;
            //}
            resultData.TotalChapterApprove = listBookChapter.Count;
            if(listBookChapter.Count > 10)
            {
                listBookChapter = listBookChapter.Take(10).ToList();
            }
            resultData.ChapterApprove = listBookChapter.Count;
            var doc = new HtmlDocument();
            foreach (var bookChapter in listBookChapter)
            {

                doc.LoadHtml(bookChapter.Content);
                string textContent = doc.DocumentNode.InnerText;
                var promp = $@"Bạn là công cụ kiểm duyệt nội dung. Kiểm tra và phân tích đoạn văn dưới đây giúp tôi đoạn text có chứa từ ngữ hoặc cụm từ không phù hợp (tục tĩu, thù hằn, phân biệt, kích động, bạo lực, tình dục,sai tôn giáo, từ ngữ thuộc chế độ cũ ,v.v.): 
                            (
                               - Có xuất hiện: format như sau: <li style='color:red'>'A' => giải thích</li>
                               - Không xuất hiện từ ngữ: format như sau: <li style='color:green'>Nội dung không chứa từ ngữ không phù hợp</li>
                            ) 
                             Bạn chỉ cần trả lời theo format này, Đây là nội dung đoạn văn: {textContent}";
                if (bookChapter == null)
                {
                    result.Message = "Dữ liệu chương sách không tồn tại";
                    return result;
                }
                var chapterApprove = new BookChapterApproveModel
                {
                    ChapterId = bookChapter.Id,
                    ChapterName = bookChapter.ChapterName,
                    Content = bookChapter.Content,
                    BookId = bookId,
                };
                //var resultChapter = await _aIGeneration.TextGenerate(promp);
                //var resultChapter = await _aIGeneration.TextGenerate(promp);
                var bookChapterLog = await _mongoContext.BookChapterLogs.Find(c => c.ChapterId == bookChapter.Id).FirstOrDefaultAsync();
                if(bookChapterLog == null || string.IsNullOrEmpty(bookChapterLog.CommentAI))
                {
                    var resultChapter = await _aIGeneration.TextGenerate(promp);
                    chapterApprove.AiFeedback = resultChapter.Data;

                    doc.LoadHtml(resultChapter.Data);
                    var listItems = doc.DocumentNode.SelectNodes("//li");
                    var htmlLi = string.Empty;
                    if(listItems != null)
                    {
                        foreach (var item in listItems)
                        {
                            htmlLi += item.OuterHtml;
                        }
                        bookChapterLog = new BookChapterLog
                        {
                            ChapterId = bookChapter.Id,
                            CommentAI = htmlLi,

                        };

                        await _mongoContext.BookChapterLogs.InsertOneAsync(bookChapterLog);
                    }


                }
                else 
                {
                    chapterApprove.AiFeedback = bookChapterLog.CommentAI;
                    chapterApprove.InappropriateWords = bookChapterLog.InappropriateWords;
                }


                result.DataList.Add(chapterApprove);
            }
            result.Data = resultData;
            result.IsSussess = true;
            result.Message = "Kết thúc quá trình duyệt";
            return result;
        }

        public async Task<ReponderModel<string>> UpdateApproveBook(int bookId, string chapterIds)
        {
            var result = new ReponderModel<string>();

            if (string.IsNullOrEmpty(chapterIds))
            {
                result.Message = "Không có dữ liệu duyệt";
                return result;
            }
            
            var listChapterIds = chapterIds.Split(",").ToList();

            var book = await _lBSDbContext.Books.FirstOrDefaultAsync(c => c.Id == bookId);
            if (book == null)
            {
                result.Message = "Không có dữ liệu sách";
                return result;
            }

            var data = await _lBSDbContext.Books.FirstOrDefaultAsync(c => c.Id == bookId);
            if (data == null)
            {
                result.Message = "Data không hợp lệ";
                return result;
            }

            if (data.Status == BookStatus.PendingApproval && book.BookTypePrice == BookTypePrice.PayByChapter) data.Status = BookStatus.Published;

            var filter = Builders<BookChapter>.Filter.And(
                Builders<BookChapter>.Filter.Where(p => p.BookId == bookId),
                Builders<BookChapter>.Filter.In(p => p.Id,listChapterIds),
                Builders<BookChapter>.Filter.Where(p => p.Type != 3),
                Builders<BookChapter>.Filter.Where(p => p.BookType == BookType.PendingApproval)
            );

            var listBookChapter = await _mongoContext.BookChapters.Find(filter).ToListAsync();

            var filterFree = Builders<BookChapter>.Filter.And(
                                Builders<BookChapter>.Filter.Where(p => p.BookId == bookId),
                                Builders<BookChapter>.Filter.Where(p => p.Type != 3),
                                Builders<BookChapter>.Filter.In(p => p.Id, listChapterIds),
                                Builders<BookChapter>.Filter.Where(p => p.BookType == BookType.PendingApproval),
                                Builders<BookChapter>.Filter.Eq(p => p.Price,0)
                            );
            var updateFree = Builders<BookChapter>.Update
                .Set(c => c.BookType, BookType.Free);
            await _mongoContext.BookChapters.UpdateManyAsync(filterFree, updateFree);

            var filterPaid = Builders<BookChapter>.Filter.And(
                    Builders<BookChapter>.Filter.Where(p => p.BookId == bookId),
                    Builders<BookChapter>.Filter.Where(p => p.Type != 3),
                    Builders<BookChapter>.Filter.In(p => p.Id, listChapterIds),
                    Builders<BookChapter>.Filter.Where(p => p.BookType == BookType.PendingApproval),
                    Builders<BookChapter>.Filter.Ne(p => p.Price, 0)
                );
            var updatePaid = Builders<BookChapter>.Update
                .Set(c => c.BookType, BookType.Payment);
            await _mongoContext.BookChapters.UpdateManyAsync(filterPaid, updatePaid);

            //foreach (var item in listBookChapter)
            //{
            //    if(item == null)
            //    {
            //        result.Message = "Dữ liệu chương sách không tồn tại";
            //        return result;
            //    }
            //    var result1 = await UpdateApproveChapterBook(bookId,item.Id);
            //    if(!result1.IsSussess)
            //    {
            //        result.Message = "Duyệt không thành công";
            //        return result;
            //    }
            //}

            if (book.BookTypePrice == BookTypePrice.PayByBook)
            {
                var filterChapter = Builders<BookChapter>.Filter.And(
                                    Builders<BookChapter>.Filter.Where(p => p.BookId == bookId),
                                    Builders<BookChapter>.Filter.Where(p => p.Type != 3),
                                    Builders<BookChapter>.Filter.Where(p => p.BookType == BookType.PendingApproval || p.BookType == BookType.Hidden || p.BookType == BookType.Decline)
                                );

                var listBookChapterCount = await _mongoContext.BookChapters.Find(filterChapter).ToListAsync();
                if (listBookChapterCount.Count == 0) book.Status = BookStatus.Done;
            }
            await _lBSDbContext.SaveChangesAsync();

            await _lBSDbContext.SaveChangesAsync();
            result.Message = "Duyệt thành công";
            result.IsSussess = true;
            return result;
        }

        public async Task<ReponderModel<string>> UpdateBookChapterView(UserBookView model)
        {
            var result = new ReponderModel<string>();
            model.CreateDate = DateTime.UtcNow;
            model.EndDate = DateTime.UtcNow;
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
            var listChapterBook = listChapter.DataList.OrderBy(c => c.ChapterNumber).ToList();

            var item = new StatisticsChapterBook
            {
                Title = "Lượt xem",
                Label = listChapterBook.Select(c => c.ChapterName).ToList(),
                Data = listChapterBook.Select(c => c.ViewNo.ToString()).ToList()
            };

            var itemRating = new StatisticsChapterBook
            {
                Title = "Đánh giá",
                //Label = listChapterBook.Select(c => c.ChapterName).ToList(),
                Data = listChapterBook.Select(c => c.ViewNo.ToString()).ToList()
            };

            result.DataList.Add(item);
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

        public async Task<ReponderModel<string>> QuicklyApproveChapterContent(string input)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(input);
            var input2 = doc.DocumentNode.InnerText;
            var promp = $@"Bạn là công cụ kiểm duyệt nội dung. Kiểm tra và phân tích đoạn văn dưới đây giúp tôi đoạn text có chứa từ ngữ hoặc cụm từ không phù hợp (tục tĩu, thù hằn, phân biệt, kích động, bạo lực, tình dục,sai tôn giáo, từ ngữ thuộc chế độ cũ ,v.v.): 
                            (
                               - Có xuất hiện: format như sau: <li style='color:red'>'A' => giải thích</li>
                               - Không xuất hiện từ ngữ: format như sau: <li style='color:green'>Nội dung không chứa từ ngữ không phù hợp</li>
                            ) 
                             Bạn chỉ cần trả lời theo format này, Đây là nội dung đoạn văn: {input2}";
            var result = new ReponderModel<string>();
            var resultChapter = await _aIGeneration.TextGenerate(promp);
            result.IsSussess = true;
            result.Data = resultChapter.Data;
            return result;
        }

        public async Task<ReponderModel<BookViewModel>> GetAllBookByCategory(string categories)
        {
            var result = new ReponderModel<BookViewModel>();
            var listCategory = categories.Split(",").ToList();
            var listBook = await _lBSDbContext.BookCategories.Include(c => c.Book)
                            .Include(c => c.Category)
                            .Where(c => c.Category != null && !string.IsNullOrEmpty(c.Category.Name) && listCategory.Contains(c.Category.Name))
                            .Select(c => c.Book)
                            .Where(c => c != null && (c.Status == BookStatus.Done || c.Status == BookStatus.Published || c.Status == BookStatus.Continue))
                            .ToListAsync();
            result.DataList = listBook.Select(c => new BookViewModel
            {
                Id = c.Id,
                Author = c.CreateBy,
                Name = c.Name,
                Poster = c.Poster,
                Status = c.Status,
                Price = c.Price
            }).DistinctBy(c => c.Id).ToList();
            result.IsSussess = true;
            return result;
        }

        public async Task<ReponderModel<string>> DeleteBook(int id)
        {
            try
            {
                var result = new ReponderModel<string>();
                var model = await _lBSDbContext.Books.Include(c => c.BookCategories).FirstOrDefaultAsync(c => c.Id == id);
                if (model == null)
                {
                    result.Message = "Data không hợp lệ";
                    return result;
                }
                _lBSDbContext.Books.Remove(model);
                await _lBSDbContext.SaveChangesAsync();

                //delete all chapter
                var filter = Builders<BookChapter>.Filter.Eq(c => c.BookId, id);
                await _mongoContext.BookChapters.DeleteManyAsync(filter);

                result.IsSussess = true;
                result.Message = "Xóa thành công";
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ReponderModel<string>> UpdateApproveChapterBook(int bookId, string chapterId)
        {
            var result = new ReponderModel<string>();
            var book = await _lBSDbContext.Books.FirstOrDefaultAsync(c => c.Id == bookId);
            if(book == null)
            {
                result.Message = "Không có dữ liệu sách";
                return result;
            }
            string audioWithTimeData = string.Empty;
            string audioFileName = string.Empty;
            var data = await _lBSDbContext.Books.FirstOrDefaultAsync(c => c.Id == bookId);
            if (data == null)
            {
                result.Message = "Data không hợp lệ";
                return result;
            }
            if (data.Status == BookStatus.PendingApproval && book.BookTypePrice == BookTypePrice.PayByChapter) data.Status = BookStatus.Published;
            //await _lBSDbContext.SaveChangesAsync();

            var filter = Builders<BookChapter>.Filter.And(
                            Builders<BookChapter>.Filter.Where(p => p.BookId == bookId),
                            Builders<BookChapter>.Filter.Where(p => p.Id == chapterId),
                            Builders<BookChapter>.Filter.Where(p => p.Type != 3),
                            Builders<BookChapter>.Filter.Where(p => p.BookType == BookType.PendingApproval)
                        );

            var bookChapter = await _mongoContext.BookChapters.Find(filter).FirstOrDefaultAsync();
            if (bookChapter == null)
            {
                result.Message = "Dữ liệu không tồn tại";
                return result;
            }

            //if (string.IsNullOrEmpty(bookChapter.Summary))
            //{
            //    var summaryResult = await GenerateSummary(bookChapter.Content);
            //    if (summaryResult.IsSussess)
            //    {
            //        var update2 = Builders<BookChapter>.Update
            //                .Set(c => c.Summary, summaryResult.Data);
            //        await _mongoContext.BookChapters.UpdateOneAsync(filter, update2);
            //        bookChapter.Summary = summaryResult.Data;
            //    }
            //}
            //try
            //{
            //    var audioResult = await GenerateTextToAudio(bookChapter.Summary);
            //    audioFileName = audioResult.Data;

            //    var audioWithTime = await CreateContentWithTimeStamp(bookChapter.Summary);
            //    audioWithTimeData = audioWithTime.Data.Replace("```json","").Replace("```","").Trim();

            //    var resultChapterVoice = await InsertOrUpdateChapterVoice(chapterId, audioWithTimeData, audioFileName);
            //    if (!resultChapterVoice)
            //    {
            //        result.Message = "Lỗi tạo file âm thanh";
            //        return result;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    result.Message = ex.Message;
            //    return result;
            //}

            var update = Builders<BookChapter>.Update
                .Set(c => c.BookType, bookChapter.Price != 0 ? BookType.Payment : BookType.Free);

            await _mongoContext.BookChapters.UpdateOneAsync(filter, update);

            if(book.BookTypePrice == BookTypePrice.PayByBook)
            {
                var filterChapter = Builders<BookChapter>.Filter.And(
                                    Builders<BookChapter>.Filter.Where(p => p.BookId == bookId),
                                    Builders<BookChapter>.Filter.Where(p => p.Type != 3),
                                    Builders<BookChapter>.Filter.Where(p => p.BookType == BookType.PendingApproval || p.BookType == BookType.Hidden || p.BookType == BookType.Decline)
                                );

                var listBookChapterCount = await _mongoContext.BookChapters.Find(filterChapter).ToListAsync();
                if (listBookChapterCount.Count == 0) book.Status = BookStatus.Done;
            }
            await _lBSDbContext.SaveChangesAsync();

            result.Message = "Duyệt thành công";
            result.IsSussess = true;
            return result;
        }


        public async Task<ReponderModel<string>> DeclineChapterBook(int bookId, string chapterId)
        {
            var result = new ReponderModel<string>();

            var data = await _lBSDbContext.Books.FirstOrDefaultAsync(c => c.Id == bookId);
            if (data == null)
            {
                result.Message = "Data không hợp lệ";
                return result;
            }
            //if (data.Status == BookStatus.PendingPublication) data.Status = BookStatus.Published;

            var filter = Builders<BookChapter>.Filter.And(
                Builders<BookChapter>.Filter.Where(p => p.BookId == bookId),
                Builders<BookChapter>.Filter.Where(p => p.Id == chapterId),
                Builders<BookChapter>.Filter.Where(p => p.Type != 3),
                Builders<BookChapter>.Filter.Where(p => p.BookType == BookType.PendingApproval)
            );

            var update = Builders<BookChapter>.Update
                .Set(c => c.BookType, BookType.Decline);

            await _mongoContext.BookChapters.UpdateOneAsync(filter, update);

            await _lBSDbContext.SaveChangesAsync();
            result.Message = "thành công";
            result.IsSussess = true;
            return result;
        }

        public async Task<ReponderModel<CommentModel>> GetCommentByBook(int bookId)
        {
            var result = new ReponderModel<CommentModel>();
            var comments = await _lBSDbContext.Comments.Include(c => c.User).Where(c => c.BookId == bookId).ToListAsync();

            result.DataList = comments.Select(c => new CommentModel
            {
                Id = c.Id,
                BookId = c.BookId,
                Content = c.Content,
                FullName = c.User.FullName,
                Avatar = string.IsNullOrEmpty(c.User.Avatar) ? "https://i.imgur.com/XHyiaIf.png" : c.User.Avatar,
                CreateDate = GetRelativeTime(c.CreateDate),
                Rating = c.Rating
            }).ToList();
            result.IsSussess = true;
            return result;
        }

        private string GetRelativeTime(DateTime inputTime)
        {
            var now = DateTime.UtcNow;
            var diff = now - inputTime;

            if (diff.TotalSeconds < 60)
                return $"{(int)diff.TotalSeconds} giây trước";

            if (diff.TotalMinutes < 60)
                return $"{(int)diff.TotalMinutes} phút trước";

            if (diff.TotalHours < 24)
                return $"{(int)diff.TotalHours} giờ trước";

            return inputTime.ToString("dd/MM/yyyy");
        }

        public async Task<ReponderModel<string>> UpdateComment(Comment comment)
        {
            var result = new ReponderModel<string>();
            if (comment == null)
            {
                result.Message = "Data không hợp lệ";
                return result;
            }
            var commentRow = await _lBSDbContext.Comments.FirstOrDefaultAsync(c => c.CreateBy == comment.CreateBy && c.BookId == comment.BookId);
            if (commentRow == null)
            {
                commentRow = new Comment
                {
                    BookId = comment.BookId,
                    CreateDate = DateTime.UtcNow,
                    Content = comment.Content,
                    CreateBy = comment.CreateBy,
                    UserId = comment.UserId,
                    Rating = comment.Rating,
                };
                _lBSDbContext.Comments.Add(commentRow);

            }
            else
            {
                commentRow.Content = comment.Content;
                commentRow.Rating = comment.Rating;
                commentRow.CreateDate = DateTime.UtcNow;
            }

            await _lBSDbContext.SaveChangesAsync();
            result.IsSussess = true;
            result.Message = "Cập nhật thành công";
            return result;
        }

        public async Task<ReponderModel<int>> CreateViewBook(UserBookViewModel model)
        {
            var result = new ReponderModel<int>();
            if (model == null)
            {
                result.Message = "Dữ liệu không hợp lệ";
                return result;
            }
            if (int.TryParse(model.ChapterId, out int e))
            {
                result.Message = "Id chương không hợp lệ";
                return result;
            }
            if (string.IsNullOrEmpty(model.CreateBy))
            {
                result.Message = "Username không hợp lệ";
                return result;
            }
            if (model.Status == ChapterStatus.Open)
            {
                if (model.Id != 0)
                {
                    var item = await _lBSDbContext.UserBookViews.FirstOrDefaultAsync(c => c.Id == model.Id);
                    if (item == null)
                    {
                        result.Message = "Dữ liệu không hợp lệ";
                        return result;
                    }
                    item.EndDate = DateTime.UtcNow.AddHours(7);
                }
                var data = new UserBookView
                {
                    BookId = model.BookId,
                    BookTypeStatus = model.BookTypeStatus,
                    ChapterId = model.ChapterId,
                    CreateBy = model.CreateBy,
                    UserId = model.UserId,
                    CreateDate = DateTime.UtcNow.AddHours(7),
                    EndDate = DateTime.MinValue
                };

                _lBSDbContext.UserBookViews.Add(data);
                await _lBSDbContext.SaveChangesAsync();
                result.Data = data.Id;
            }
            else if (model.Status == ChapterStatus.Close)
            {
                var resultData = await _lBSDbContext.UserBookViews.FirstOrDefaultAsync(c => c.Id == model.Id);
                if (resultData == null)
                {
                    result.Message = "Dữ liệu không hợp lệ";
                    return result;
                }
                resultData.EndDate = DateTime.UtcNow.AddHours(7);
                await _lBSDbContext.SaveChangesAsync();
                result.Data = resultData.Id;
            }
            result.IsSussess = true;
            result.Message = "Thành công";
            return result;
        }

        public async Task<ReponderModel<int>> GetViewNo(int bookId, BookTypeStatus type)
        {
            var result = new ReponderModel<int>();
            var viewNo = await _lBSDbContext.UserBookViews.Where(c => c.BookTypeStatus == type && c.BookId == bookId).CountAsync();
            result.Data = viewNo;
            result.IsSussess = true;
            return result;
        }

        public async Task<ReponderModel<UserMinuteModel>> GetListMinuteViewByUser(string userName)
        {
            var result = new ReponderModel<UserMinuteModel>();

            var now = DateTime.UtcNow.AddHours(7);
            var dayOfweek = now.DayOfWeek;
            var dateNow = now.Date;
            var startOfWeek = dateNow.AddDays(-(int)dayOfweek + 1);  
            if (dayOfweek == DayOfWeek.Sunday)
            {
                startOfWeek = dateNow.AddDays(-7);
            }
            var endOfWeek = startOfWeek.AddDays(7);

            var asQuery = _lBSDbContext.UserBookViews.Where(c => c.CreateBy == userName && c.EndDate != DateTime.MinValue && c.CreateDate >= startOfWeek && c.CreateDate < endOfWeek).AsQueryable();
            var readMinute = await asQuery.Where(c => c.BookTypeStatus == BookTypeStatus.Read).ToListAsync();
            var voiceMinute = await asQuery.Where(c => c.BookTypeStatus == BookTypeStatus.Voice).ToListAsync();

            var i = startOfWeek;
            while (i < endOfWeek)
            {
                var readMinuteInt = readMinute.Where(c => c.CreateDate.Date.CompareTo(i.Date) == 0 && c.EndDate.Date.CompareTo(i.Date) == 0).Sum(c => (int)c.EndDate.Subtract(c.CreateDate).TotalMinutes)
                    + readMinute.Where(c => c.CreateDate.Date.CompareTo(i.Date) == 0 && c.EndDate.Date.CompareTo(i.Date) > 0).Sum(c => (int)c.EndDate.Date.Subtract(c.CreateDate).TotalMinutes)
                    + readMinute.Where(c => c.CreateDate.Date.CompareTo(i.Date) == -1 && c.EndDate.Date.CompareTo(i.Date) == 0).Sum(c => (int)c.EndDate.Subtract(c.EndDate.Date).TotalMinutes);

                var listenMinuteInt = voiceMinute.Where(c => c.CreateDate.Date.CompareTo(i.Date) == 0 && c.EndDate.Date.CompareTo(i.Date) == 0).Sum(c => (int)c.EndDate.Subtract(c.CreateDate).TotalMinutes)
                    + voiceMinute.Where(c => c.CreateDate.Date.CompareTo(i.Date) == 0 && c.EndDate.Date.CompareTo(i.Date) > 0).Sum(c => (int)c.EndDate.Date.Subtract(c.CreateDate).TotalMinutes)
                    + voiceMinute.Where(c => c.CreateDate.Date.CompareTo(i.Date) == -1 && c.EndDate.Date.CompareTo(i.Date) == 0).Sum(c => (int)c.EndDate.Subtract(c.EndDate.Date).TotalMinutes);

                var item = new UserMinuteModel
                {
                    Day = i,
                    IsToday = dateNow.CompareTo(i) == 0 ? true : false,
                    DayOfWeek = i.DayOfWeek,
                    DayOfWeekStr = GetDayOfWeekStr(i.DayOfWeek),
                    UserName = userName,
                    ReadMinute = readMinuteInt,
                    ListenMinute = listenMinuteInt,
                };
                result.DataList.Add(item);
                i = i.AddDays(1);
            }
            result.IsSussess = true;
            return result;
        }

        public async Task<ReponderModel<string>> AddOrRemoveFavouriteBook(string userName, int bookId)
        {
            var reponse = new ReponderModel<string>();
            var account = await _lBSDbContext.Users.FirstOrDefaultAsync(c => c.UserName == userName);
            if (account == null)
            {
                reponse.Message = "Tài khoản không tồn tại";
                return reponse;
            }
            var favouriteBook = await _lBSDbContext.UserBooks.FirstOrDefaultAsync(c => c.UserName == userName && c.BookId == bookId && c.BookType == UserBookType.Favourite);
            if(favouriteBook == null)
            {
                favouriteBook = new UserBook
                {
                    UserName = userName,
                    UserId = account.Id,
                    BookType = UserBookType.Favourite,
                    BookId = bookId
                };
                _lBSDbContext.UserBooks.Add(favouriteBook);
            }
            else
            {
                _lBSDbContext.UserBooks.Remove(favouriteBook);
            }
            await _lBSDbContext.SaveChangesAsync();
            reponse.IsSussess = true;
            reponse.Message = "Cập nhật thành công";
            return reponse;
        }

        public async Task<ReponderModel<UserBook>> ListFavouriteBook(string userName)
        {
            var reponse = new ReponderModel<UserBook>();
            reponse.DataList = await _lBSDbContext.UserBooks.Include(c => c.Book).Where(c => c.UserName == userName && c.BookType == UserBookType.Favourite).ToListAsync();
            reponse.IsSussess = true;
            return reponse;
        }

        public async Task<ReponderModel<string>> InsertOrUpdateChapterVoice(string chapterId, string contentWithTime,string fileName, int price = 1000)
        {
            var result = new ReponderModel<string>();
            var filter = Builders<BookChapterVoice>.Filter.Eq(c => c.ChapterId, chapterId);
            var bookChapterVoice = await _mongoContext.BookChapterVoices.Find(filter).FirstOrDefaultAsync();
            if(bookChapterVoice == null)
            {
                bookChapterVoice = new BookChapterVoice
                {
                    ChapterId = chapterId,
                    ContentWithTime = contentWithTime,
                    FileName = fileName,
                    ModifyDate = DateTime.UtcNow,
                    Price = price,
                };
                await _mongoContext.BookChapterVoices.InsertOneAsync(bookChapterVoice);

                var filterChapter = Builders<BookChapter>.Filter.Eq(c => c.Id, chapterId);
                var update = Builders<BookChapter>.Update
                            .Set(c => c.AudioUrl, "Audio");
                await _mongoContext.BookChapters.UpdateOneAsync(filterChapter, update);

            }

            result.IsSussess = true;
            result.Message = "Thành công";
            return result;
        }

        private async Task<ReponderModel<string>> CreateContentWithTimeStamp(string input)
        {
            var result = new ReponderModel<string>();
            var promp = $@"Chia đoạn text này thành list với tối đa 8 chữ. sau đó tính start time và end time (milisecond) cùa từng câu với giọng Alloy: 
                            (
                                - Gồm các cột: 
                                    - Text
                                    - StartTime
                                    - EndTime
                            ) 
                             Bạn chỉ cần trả lời theo format này dữ liệu trả về dưới dạng là json (json bắt đầu bằng ```json kết thúc bằng ``` để tôi lấy được giá trị, chỉ cần trả về json không cần giải thích), Đây là nội dung đoạn văn: {input}";
            var resultContent = await _aIGeneration.TextGenerate(promp);
            result.IsSussess = true;
            result.Data = resultContent.Data;
            return result;
        }

        public async Task<ReponderModel<BookChapterModel>> GetBookChapterWithVoice(string id)
        {
            var result = new ReponderModel<BookChapterModel>();
            var filter = Builders<BookChapter>.Filter.Eq(c => c.Id, id);
            var bookChapter = await _mongoContext.BookChapters.Find(filter).FirstOrDefaultAsync();
            if (bookChapter == null)
            {
                result.Message = "Dữ liệu không tồn tại";
                return result;
            }

            var filterVoice = Builders<BookChapterVoice>.Filter.Eq(c => c.ChapterId, id);
            var bookChapterVoice = await _mongoContext.BookChapterVoices.Find(filterVoice).FirstOrDefaultAsync();
            if(bookChapterVoice == null)
            {
                result.Message = "Dữ liệu audio không tồn tại";
                return result;
            }

            //08:36 15 / 04 / 2025
            var data = new BookChapterModel
            {
                Id = id,
                FileName = bookChapterVoice != null ? bookChapterVoice.FileName : string.Empty,
                BookId = bookChapter.BookId,
                BookType = bookChapter.BookType,
                ChapterNumber = bookChapter.ChapterNumber,
                ChapterName = bookChapter.ChapterName,
                Content = bookChapter.Content,
                CreateBy = bookChapter.CreateBy,
                Price = bookChapter.Price,
                Summary = bookChapter.Summary,
                ModifyDate = bookChapter.ModifyDate.AddHours(7).ToString("HH:mm dd/MM/yyyy"),
                //WordNo = bookChapter.WordNo
                //ContentWithTime = bookChapterVoice != null ? bookChapterVoice.ContentWithTime : string.Empty,
            };
            if (!string.IsNullOrEmpty(bookChapterVoice.ContentWithTime))
            {
                var contentWithTimeList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SummaryTime>>(bookChapterVoice.ContentWithTime);
                data.ContentWithTime = contentWithTimeList;
            }
            result.Data = data;
            result.Message = "Thành công";
            result.IsSussess = true;
            return result;
        }

        public async Task<ReponderModel<BookModel>> SearchBook(string input)
        {
            var result = new ReponderModel<BookModel>();
            var key = _configuration["Meilisearch:Key"];
            var client = new MeilisearchClient("https://ireading.store/search/", key);
            var index = client.Index("books");

            //await index.UpdateSearchableAttributesAsync(new[]
            //    {
            //       "Name",
            //       "Author",
            //       "Categories"
            //    });
            var pattern = @"[@#*?""'\\/()\[\]{}]";
            if(Regex.IsMatch(input, pattern))
            {
                result.IsSussess = true;
                return result;
            }

            var result1 = await index.SearchAsync<BookIndexModel>(input, new SearchQuery
            {
                //Limit = 20
            });
            var response = result1.Hits;
            result.IsSussess = true;
            result.DataList = result1.Hits.Select(c => new BookModel
            {
                Name = c.Name,
                Id = c.Id,
                Poster = c.Poster,
                CreateBy = c.Author,
                Categories = c.Categories
            }).ToList();
            return result;
        }

        public async Task<ReponderModel<NoteUser>> GetListNote(string username,int bookId)
        {
            var result = new ReponderModel<NoteUser>();
            result.DataList = await _lBSDbContext.NoteUsers.Where(c => c.UserName == username && c.BookId == bookId).ToListAsync();
            result.IsSussess = true;
            return result;
        }

        public async Task<ReponderModel<string>> UpdateNoteUser(NoteUser note)
        {
            var result = new ReponderModel<string>();
            if (note == null)
            {
                result.Message = "Data không hợp lệ";
                return result;
            }
            var noteData = await _lBSDbContext.NoteUsers.FirstOrDefaultAsync(c => c.Id == note.Id);
            if(noteData == null)
            {
                note.CreateDate = DateTime.UtcNow;
                _lBSDbContext.NoteUsers.Add(note);
            }
            else
            {
                noteData.BookId = note.BookId;
                noteData.ChapterId = note.ChapterId;
                noteData.NoteContent = note.NoteContent;
                noteData.SelectedText = note.SelectedText;
                noteData.Start = note.Start;
                noteData.End = note.End;
                noteData.CreateDate = DateTime.UtcNow;
            }
            await _lBSDbContext.SaveChangesAsync();
            result.IsSussess = true;
            result.Message = "Cập nhật thành công";
            return result;
        }

        public async Task<ReponderModel<string>> DeleteNoteUser(int id)
        {
            var result = new ReponderModel<string>();
            var noteData = await _lBSDbContext.NoteUsers.FirstOrDefaultAsync(c => c.Id == id);
            if (noteData == null)
            {
                result.Message = "Data không hợp lệ";
                return result;
            }
            _lBSDbContext.NoteUsers.Remove(noteData);
            await _lBSDbContext.SaveChangesAsync();
            result.IsSussess = true;
            result.Message = "Xóa thành công";
            return result;
        }

        public async Task<ReponderModel<BookRatingModel>> GetTop10BookRating()
        {
            var result = new ReponderModel<BookRatingModel>();
            // get 10 book co lượt đánh giá cao nhất
            var books = await (from book in _lBSDbContext.Books
                               join comment in _lBSDbContext.Comments
                               on book.Id equals comment.BookId
                               where book.Status == BookStatus.Done 
                               || book.Status == BookStatus.Published 
                               || book.Status == BookStatus.Continue
                               group comment.Rating by new { book.Id, book.Name,book.Poster,book.Status,book.BookType,book.Price } into g
                               orderby g.Average() descending
                               select new BookRatingModel
                               {
                                   Id = g.Key.Id,
                                   Poster = g.Key.Poster,
                                   Name = g.Key.Name,
                                   BookType = g.Key.BookType,
                                   Status = g.Key.Status,
                                   Price = g.Key.Price,
                                   Rating = g.Average()
                               }).Take(10).ToListAsync();
            result.DataList = books;
            result.IsSussess = true;
            return result;
        }

        public async Task<ReponderModel<BookModel>> GetTop10NewBook()
        {
            var result = new ReponderModel<BookModel>();
            // get 10 book mới nhất
            var books = await _lBSDbContext.Books.Where(c => c.Status == BookStatus.Continue 
            || c.Status == BookStatus.Done 
            || c.Status == BookStatus.Published).OrderByDescending(c => c.CreateDate).Take(10).ToListAsync();

            result.DataList = books.Select(c => new BookModel
            {
                BookType = c.BookType,
                CreateBy = c.CreateBy,
                Name = c.Name,
                Id = c.Id,
                Poster = c.Poster,
                Price = c.Price,
                SubCategory = c.SubCategory,
                Status = c.Status
            }).ToList();
            result.IsSussess = true;
            return result;
        }

        public async Task<ReponderModel<BookModel>> GetTop10FavoriteBook()
        {
            var result = new ReponderModel<BookModel>();
            // get 10 book co lượt yêu thích cao nhất
            var books = await(from book in _lBSDbContext.Books
                              join userBook in _lBSDbContext.UserBooks
                              on book.Id equals userBook.BookId
                              where book.Status == BookStatus.Done
                              || book.Status == BookStatus.Published
                              || book.Status == BookStatus.Continue
                              group userBook.BookId by new { book.Id, book.Name, book.Poster } into g
                              orderby g.Count() descending
                              select new BookModel
                              {
                                  Id = g.Key.Id,
                                  Poster = g.Key.Poster,
                                  Name = g.Key.Name
                              }).Take(10).ToListAsync();
            result.DataList = books;
            result.IsSussess = true;
            return result;
        }

        public async Task<ReponderModel<string>> UpdateCommentUser(CommentUser comment)
        {
            var result = new ReponderModel<string>();
            if (comment == null)
            {
                result.Message = "Data không hợp lệ";
                return result;
            }
            var commentRow = await _lBSDbContext.CommentUsers.FirstOrDefaultAsync(c => c.Id == comment.Id);
            if (commentRow == null)
            {
                comment.ModifyDate = DateTime.UtcNow;
                _lBSDbContext.CommentUsers.Add(comment);
            }
            else
            {
                commentRow.Content = comment.Content;
                commentRow.ModifyDate = DateTime.UtcNow;
            }
            await _lBSDbContext.SaveChangesAsync();
            result.IsSussess = true;
            result.Message = "Cập nhật thành công";
            return result;
        }

        public async Task<ReponderModel<string>> GetListCommentByChapter(string chapterId)
        {
            //var result = new ReponderModel<string>();
            //var reponse = await _lBSDbContext.CommentUsers.Where(c => c.Chapter == chapterId).ToListAsync();
            //foreach (var item in reponse)
            //{
            //    var userComment
            //}
            throw new NotImplementedException();
        }

        public async Task<ReponderModel<bool>> CheckPaidWithBookChapter(string username,int bookId)
        {
            var result = new ReponderModel<bool>();

            var book = await _lBSDbContext.Books.FirstOrDefaultAsync(c => c.Id == bookId);
            if(book == null)
            {
                result.Message = "Không có dữ liệu sách";
                return result;
            }

            var filter = Builders<BookChapter>.Filter.And(
                Builders<BookChapter>.Filter.Where(p => p.BookId == bookId),
                Builders<BookChapter>.Filter.Where(p => p.CreateBy == username),
                Builders<BookChapter>.Filter.Where(p => p.Type != 3),
                Builders<BookChapter>.Filter.Where(p => p.BookType == BookType.Free || p.BookType == BookType.Payment)
            );

            var listBookChapter = await _mongoContext.BookChapters.Find(filter).ToListAsync();
            // toi thieu 10 chương va thuoc type PayChapter
            result.Data = listBookChapter.Count >= 10 && book .BookTypePrice == BookTypePrice.PayByChapter? true : false;

            result.IsSussess = true;
            return result;
        }

        public async Task<ReponderModel<BookHomePageModel>> GetBookHomePage()
        {
            var result = new ReponderModel<BookHomePageModel>();
            // top 10 Rating
            var result10Rating = await GetTop10BookRating();
            var item10Rating = new BookHomePageModel
            {
                CategoryId = -1,
                CategoryName = "Top 10 sách đánh giá cao nhất",
                Books = result10Rating.DataList.Select(c => new BookModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Poster = c.Poster,
                    BookType = c.BookType,
                    Status = c.Status,
                    Price = c.Price
                }).ToList()
            };
            result.DataList.Add(item10Rating);

            //top 10 new book
            var result10New = await GetTop10NewBook();
            var item10New = new BookHomePageModel
            {
                CategoryId = -1,
                CategoryName = "Top 10 sách mới nhất",
                Books = result10New.DataList.Select(c => new BookModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Poster = c.Poster,
                    BookType = c.BookType,
                    Status = c.Status,
                    Price = c.Price
                }).ToList()
            };
            result.DataList.Add(item10New);

            //top 10 favorite book
            var result10Favorite = await GetTop10FavoriteBook();
            var item10Favorite = new BookHomePageModel
            {
                CategoryId = -1,
                CategoryName = "Top 10 sách được yêu thích nhất",
                Books = result10Favorite.DataList.Select(c => new BookModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Poster = c.Poster,
                    BookType = c.BookType,
                    Status = c.Status,
                    Price = c.Price
                }).ToList()
            };
            result.DataList.Add(item10Favorite);

            //top 10 book by category nhieu view nhat
            var categories = await GetTop10CategoryView();
            foreach (var item in categories.DataList)
            {
                var resultCategory = await GetAllBookByCategory(item.Name);
                var itemCategory = new BookHomePageModel
                {
                    CategoryId = item.Id,
                    CategoryName = item.Name,
                    Books = resultCategory.DataList.Select(c => new BookModel
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Poster = c.Poster,
                        BookType = c.BookType,
                        Status = c.Status,
                        Price = c.Price
                    }).Take(10).ToList()
                };
                result.DataList.Add(itemCategory);
            }
            result.IsSussess = true;
            return result;
        }

        public async Task<ReponderModel<CategoryModel>> GetTop10CategoryView()
        {
            var result = new ReponderModel<CategoryModel>();
            // get 10 category co lượt xem cao nhất
            var categories = await (from book in _lBSDbContext.Books
                                    join bookCategory in _lBSDbContext.BookCategories
                                    on book.Id equals bookCategory.BookId
                                    join category in _lBSDbContext.Categories
                                    on bookCategory.CategoryId equals category.Id
                                    join bookView in _lBSDbContext.UserBookViews
                                    on book.Id equals bookView.BookId
                                    where book.Status == BookStatus.Done
                                    || book.Status == BookStatus.Published
                                    || book.Status == BookStatus.Continue
                                    group bookView.BookId by new { category.Id, category.Name } into g
                                    orderby g.Count() descending
                                    select new CategoryModel
                                    {
                                        Id = g.Key.Id,
                                        Name = g.Key.Name,
                                        ViewNo = g.Count()
                                    }).Take(10).ToListAsync();
            result.DataList = categories;
            result.IsSussess = true;
            return result;
        }

        public async Task<ReponderModel<string>> GetAnalysis(string input)
        {
            var prompt = $@"Bạn là công cụ phân tích nội dung. Hãy phân tích đoạn văn dưới đây giúp tôi (tối đa 200 từ): 
                           Đây là nội dung đoạn văn: {input}";
            var resultData = await _aIGeneration.TextGenerate(prompt);
            return resultData;
        }

        private string GetDayOfWeekStr(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return "CN";
                case DayOfWeek.Monday:
                    return "Th2";
                case DayOfWeek.Tuesday:
                    return "Th3";
                case DayOfWeek.Wednesday:
                    return "Th4";
                case DayOfWeek.Thursday:
                    return "Th5";
                case DayOfWeek.Friday:
                    return "Th6";
                case DayOfWeek.Saturday:
                    return "Th7";
                default:
                    return string.Empty;
            }
        }

        public async Task<ReponderModel<string>> CheckFinishBook(int bookId)
        {
            var result = new ReponderModel<string>();
            var book = await GetBook(bookId);
            if(book == null || book.Data == null)
            {
                result.Message = "Không có thông tin sách";
                return result;
            }
            var listBookChapter = await GetListBookChapter(bookId);
            if(!listBookChapter.IsSussess || listBookChapter.DataList.Count == 0)
            {
                result.Message = "Không tồn tại chương sách";
                return result;
            }

            // hoàn thành sách thanh toán theo chương
            if(book.Data.BookTypePrice == BookTypePrice.PayByChapter)
            {
                var bookChaptersPending = listBookChapter.DataList.Where(c => c.BookType != BookType.Free && c.BookType != BookType.Payment).ToList();
                if (bookChaptersPending.Count > 0)
                {
                    result.Message = "Tồn tại chương sách chưa xuất bản";
                    return result;
                }
            }
            else if(book.Data.BookTypePrice == BookTypePrice.PayByBook)
            {
                // hoàn thành sách thanh toán theo sách
                var bookChapterNotPending = listBookChapter.DataList.Where(c => c.BookType != BookType.PendingApproval).ToList();
                if (bookChapterNotPending.Count > 0)
                {
                    result.Message = "Tồn tại chương sách đã xuất bản hoặc hủy duyệt";
                    return result;
                }
            }

            result.Data = book.Data.Price.ToString();
            result.Message = "Đủ điều kiện để chuyển trạng thái hoàn thành";
            result.IsSussess = true;
            return result;
            //throw new NotImplementedException();
        }

        public async Task<ReponderModel<string>> UpdateFinishBook(int bookId, int price)
        {
            var result = new ReponderModel<string>();
            var book = await _lBSDbContext.Books.FirstOrDefaultAsync(c => c.Id == bookId);
            if (book == null)
            {
                result.Message = "Không có thông tin sách";
                return result;
            }
            if (book.BookTypePrice == BookTypePrice.PayByChapter)
            {
                if(price <= 0)
                {
                    result.Message = "Giá tiền không hợp lệ";
                    return result;
                }
                book.Price = price;
                book.Status = BookStatus.Done;
            }
            else if(book.BookTypePrice == BookTypePrice.PayByBook)
            {
                book.Price = price;
                book.Status = BookStatus.PendingApproval;
            }
            await _lBSDbContext.SaveChangesAsync();
            result.Message = "Cập nhật thành công";
            result.IsSussess = true;
            return result;
        }

        public async Task<ReponderModel<string>> HiddenChapterBook(string id)
        {
            var filter = Builders<BookChapter>.Filter.Eq(c => c.Id, id);
            var result = new ReponderModel<string>();

            var bookChapter = await _mongoContext.BookChapters.Find(filter).FirstOrDefaultAsync();
            if(bookChapter == null)
            {
                result.Message = "Không có dữ liệu chương";
                return result;
            }

            UpdateDefinition<BookChapter> update;
            if(bookChapter.BookType == BookType.Hidden)
            {
                update = Builders<BookChapter>.Update
                    .Set(c => c.BookType, BookType.PendingApproval);
            }
            else
            {
                update = Builders<BookChapter>.Update
                    .Set(c => c.BookType, BookType.Hidden);
            }
            await _mongoContext.BookChapters.UpdateOneAsync(filter, update);
            result.IsSussess = true;
            result.Message = "Cập nhật thành công";
            return result;
        }

        public async Task<ReponderModel<string>> BanBook(int bookId)
        {
            var result = new ReponderModel<string>();
            var book = await _lBSDbContext.Books.FirstOrDefaultAsync(c => c.Id == bookId);
            if(book == null)
            {
                result.Message = "Không có dữ liệu sách";
                return result;
            }

            book.Status = BookStatus.Pause;

            var filter = Builders<BookChapter>.Filter.Where(p => p.BookId == book.Id);


            var update = Builders<BookChapter>.Update
                .Set(c => c.BookType, BookType.Decline);

            await _mongoContext.BookChapters.UpdateManyAsync(filter, update);

            //var listChapterBook = _mongoContext.BookChapters.Find(c => c.BookId == bookId).tl

            await _lBSDbContext.SaveChangesAsync();
            result.IsSussess = true;
            result.Message = "Thành công";
            return result;
        }

        public async Task<ReponderModel<string>> UnBanBook(int bookId)
        {
            var result = new ReponderModel<string>();
            var book = await _lBSDbContext.Books.FirstOrDefaultAsync(c => c.Id == bookId);
            if (book == null)
            {
                result.Message = "Không có dữ liệu sách";
                return result;
            }

            book.Status = BookStatus.PendingApproval;
            await _lBSDbContext.SaveChangesAsync();
            result.IsSussess = true;
            result.Message = "Thành công";
            return result;
        }

        public async Task<ReponderModel<BookChapterVoiceModel>> GetChapterAudio(string chapterId)
        {
            var result = new ReponderModel<BookChapterVoiceModel>();
            var filter = Builders<BookChapter>.Filter.Eq(c => c.Id, chapterId);
            var bookChapter = await _mongoContext.BookChapters.Find(filter).FirstOrDefaultAsync();
            if (bookChapter == null)
            {
                result.Message = "Dữ liệu không tồn tại";
                return result;
            }
            if (string.IsNullOrEmpty(bookChapter.Summary))
            {
                result.Message = "Không có dữ liệu tóm tắt";
                return result;
            }
            try
            {
                var domain = "https://ireading.store";

                //local
                //domain = "https://localhost:7157";
                var bookChapterVoice = await _mongoContext.BookChapterVoices.Find(c => c.ChapterId == chapterId).FirstOrDefaultAsync();
                var audioFileName = $"{chapterId}.mp3";
                var audioFilePath = $"{domain}/api/Book/Audio/";
                if (bookChapterVoice == null)
                {
              
                    var audioResult = await GenerateTextToAudio(bookChapter.Summary, audioFileName);
                    if (!audioResult.IsSussess)
                    {
                        result.Message = "Lỗi tạo file âm thanh";
                        return result;
                    }

                    //var audioWithTime = await CreateContentWithTimeStamp(bookChapter.Summary);
                    var audioWithTimeData = await AudioTranscription(audioFileName);
                    if(!audioWithTimeData.IsSussess)
                    {
                        result.Message = audioWithTimeData.Message;
                        return result;
                    }

                    var audioWithTimeDataJson = Newtonsoft.Json.JsonConvert.SerializeObject(audioWithTimeData.DataList);
                    
                    // default Price = 1000
                    var resultChapterVoice = await InsertOrUpdateChapterVoice(chapterId, audioWithTimeDataJson,audioFileName);
                    if (!resultChapterVoice.IsSussess)
                    {
                        result.Message = "Lỗi tạo file âm thanh";
                        return result;
                    }
                    result.Data = new BookChapterVoiceModel
                    {
                        ChapterId = chapterId,
                        ContentWithTimes = audioWithTimeData.DataList,
                        FileUrl = audioFilePath + audioFileName,
                        ChapterName = bookChapter.ChapterName,
                        Summary = bookChapter.Summary,
                        Price = 1000,
                    };

                }
                else
                {
                    result.Data = new BookChapterVoiceModel
                    {
                        ChapterId = bookChapterVoice.ChapterId,
                        ContentWithTimes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SegmentModel>>(bookChapterVoice.ContentWithTime),
                        FileUrl = audioFilePath + bookChapterVoice.FileName,
                        ChapterName = bookChapter.ChapterName,
                        Summary = bookChapter.Summary,
                        Price = bookChapterVoice.Price
                    };
                }

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
            result.Message = "Thành công";
            result.IsSussess = true;
            return result;
        }

        public async Task<ReponderModel<string>> GenerateTextToAudio(string input)
        {
            var result = await _aIGeneration.TextGenerateToSpeech(input,"test.mp3");
            return result;
        }

        public async Task<ReponderModel<SegmentModel>> AudioTranscription(string input)
        {
            var result = await _aIGeneration.AudioTranscription(input);
            return result;
        }

        public async Task<ReponderModel<string>> UpdatePriceChapterVoice(BookChapterVoiceModel model)
        {
            var result = new ReponderModel<string>();
            var bookChapterVoice = await _mongoContext.BookChapterVoices.Find(c => c.ChapterId == model.ChapterId).FirstOrDefaultAsync();
            if(bookChapterVoice == null)
            {
                result.Message = "Không có dữ liệu âm thanh";
                return result;
            }
            if(model.Price < 0)
            {
                result.Message = "Giá không hợp lệ";
                return result;
            }
            var filter = Builders<BookChapterVoice>.Filter.Eq(c => c.ChapterId, model.ChapterId);
            var update = Builders<BookChapterVoice>.Update
                        .Set(c => c.Price, model.Price);
                        
            await _mongoContext.BookChapterVoices.UpdateOneAsync(filter, update);

            var filterBookChapter = Builders<BookChapter>.Filter.Eq(c => c.Id, model.ChapterId);
            var updateBookChapter = Builders<BookChapter>.Update
                        .Set(c => c.AudioUrl, "Audio");
            await _mongoContext.BookChapters.UpdateOneAsync(filterBookChapter, updateBookChapter);

            result.Message = "Cập nhật thành công";
            result.IsSussess = true;
            return result;
        }

        public async Task<ReponderModel<BookChapterModel>> GetListBookChapterByUserName(int bookId, string? username)
        {
            var result = new ReponderModel<BookChapterModel>();
            var filter = Builders<BookChapter>.Filter.And(
                Builders<BookChapter>.Filter.Where(p => p.BookId == bookId),
                Builders<BookChapter>.Filter.Where(p => p.BookType == BookType.Free || p.BookType == BookType.Payment)
                
            );

            var listBookChapter = await _mongoContext.BookChapters.Find(filter).ToListAsync();

            if (listBookChapter == null || listBookChapter.Count == 0)
            {
                result.Message = "Không có dữ liệu chương";
                return result;
            }
            if (string.IsNullOrEmpty(username))
            {
                foreach (var c in listBookChapter)
                {
                    var filterVoice = Builders<BookChapterVoice>.Filter.Eq(c => c.ChapterId, c.Id);
                    var bookChapterVoice = await _mongoContext.BookChapterVoices.Find(filterVoice).FirstOrDefaultAsync();
                    var bookChapterModel = new BookChapterModel
                    {
                        AudioUrl = c.AudioUrl,
                        Id = c.Id,
                        BookId = c.BookId,
                        ChapterName = c.ChapterName,
                        Content = c.Content,
                        BookType = c.BookType,
                        ChapterNumber = c.ChapterNumber,
                        CreateBy = c.CreateBy,
                        Price = c.Price,
                        Summary = c.Summary,
                        IsPaidChapter = false
                        //ModifyDate = c.ModifyDate
                    };

                    if (bookChapterVoice != null)
                    {
                        bookChapterModel.PriceVoice = bookChapterVoice.Price;
                        bookChapterModel.SegmentWithTimes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SegmentModel>>(bookChapterVoice.ContentWithTime);
                        bookChapterModel.FileName = bookChapterVoice.FileName;

                        bookChapterModel.IsPaidVoice = false;
                    }
                    result.DataList.Add(bookChapterModel);
                }
                result.IsSussess = true;
                return result;
            }

            var isExpireMemberShip = await CheckExpireMemberShip(username);
            var paidBook = await _lBSDbContext.UserTranscationBooks.FirstOrDefaultAsync(c => c.BookId == bookId && string.IsNullOrEmpty(c.ChapterId) && c.UserName == username);
            
            //mua full sách
            if(paidBook != null)
            {
                var paidChapters = await _lBSDbContext.UserTranscationBooks.Where(c => c.UserName == username && c.Type == TranscationBookType.Voice).ToListAsync();
                foreach (var c in listBookChapter)
                {
                    var filterVoice = Builders<BookChapterVoice>.Filter.Eq(c => c.ChapterId, c.Id);
                    var bookChapterVoice = await _mongoContext.BookChapterVoices.Find(filterVoice).FirstOrDefaultAsync();
                    //var bookChapterVoice = await _mongoContext.BookChapterVoices.Find(c => c.ChapterId == c.Id).FirstOrDefaultAsync();
                    var bookChapterModel = new BookChapterModel
                    {
                        AudioUrl = c.AudioUrl,
                        Id = c.Id,
                        BookId = c.BookId,
                        ChapterName = c.ChapterName,
                        Content = c.Content,
                        BookType = c.BookType,
                        ChapterNumber = c.ChapterNumber,
                        CreateBy = c.CreateBy,
                        Price = c.Price,
                        Summary = c.Summary,
                        IsPaidChapter = true
                        //ModifyDate = c.ModifyDate
                    };

                    if(bookChapterVoice != null)
                    {
                        bookChapterModel.PriceVoice = bookChapterVoice.Price;
                        bookChapterModel.SegmentWithTimes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SegmentModel>>(bookChapterVoice.ContentWithTime);
                        bookChapterModel.FileName = bookChapterVoice.FileName;

                        //mua sach noi
                        bookChapterModel.IsPaidVoice = paidChapters.FirstOrDefault(c => c.ChapterId == bookChapterVoice.ChapterId) != null || isExpireMemberShip ? true : false;
                    }
                    result.DataList.Add(bookChapterModel);
                }

            }
            // mua tung chuong
            else
            {
                var paidChapters = await _lBSDbContext.UserTranscationBooks.Where(c => c.UserName == username && c.BookId == bookId).ToListAsync();

                //listBookChapter = listBookChapter.Where(c => c.Id == "680f2304e802dc172bc88640").ToList();
                foreach (var c in listBookChapter)
                {
                    var filterVoice = Builders<BookChapterVoice>.Filter.Eq(c => c.ChapterId, c.Id);
                    var bookChapterVoice = await _mongoContext.BookChapterVoices.Find(filterVoice).FirstOrDefaultAsync();
                    var bookChapterModel = new BookChapterModel
                    {
                        AudioUrl = c.AudioUrl,
                        Id = c.Id,
                        BookId = c.BookId,
                        ChapterName = c.ChapterName,
                        Content = c.Content,
                        BookType = c.BookType,
                        ChapterNumber = c.ChapterNumber,
                        CreateBy = c.CreateBy,
                        Price = c.Price,
                        Summary = c.Summary,
                        IsPaidChapter = paidChapters.FirstOrDefault(x => x.ChapterId == c.Id && x.Type == TranscationBookType.Read) != null ? true : false,
                    };
                    if (bookChapterVoice != null)
                    {
                        bookChapterModel.PriceVoice = bookChapterVoice.Price;
                        bookChapterModel.SegmentWithTimes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SegmentModel>>(bookChapterVoice.ContentWithTime);
                        bookChapterModel.FileName = bookChapterVoice.FileName;
                        //mua sach noi
                        bookChapterModel.IsPaidVoice = paidChapters.FirstOrDefault(c => c.ChapterId == bookChapterVoice.ChapterId) != null || isExpireMemberShip ? true : false;
                    }
                    result.DataList.Add(bookChapterModel);
                }
            }

            result.IsSussess = true;
            return result;
        }

        public async Task<ReponderModel<string>> CheckReadingEnough(string username, int bookId)
        {
            var result = new ReponderModel<string>();
            var listChapter = await _lBSDbContext.UserBookViews.Where(c => c.CreateBy == username && c.BookId == bookId).Select(c => c.ChapterId).Distinct().ToListAsync();
            if(listChapter.Count >= 3) result.IsSussess = true;
            else result.IsSussess = false;
            return result;
        }

        private async Task<bool> CheckExpireMemberShip(string username)
        {
            var paid = await _lBSDbContext.UserTranscations.Where(c => c.UserName == username && c.Type == PaymentItemType.Membership && c.ExpireDate != null)
                .OrderByDescending(c => c.ExpireDate)
                .FirstOrDefaultAsync();
            if(paid == null || paid.ExpireDate < DateTime.UtcNow) return false;
            return true;
        }
    }
}
