using BusinessObject;
using BusinessObject.BaseModel;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.IRepository;
using System;
using System.Net;
using System.Text;

namespace LBSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository) 
        { 
            _bookRepository = bookRepository;
        }

        [Route("GetAllBookImages")]
        [HttpGet]
        public async Task<bool> GetAllBookImages()
        {
            //await _bookRepository.GetBookImages();
            await _bookRepository.AudioTranscription("4f215c61-15c7-463d-b235-377715584567.mp3");
            return true;
        }

        [Route("GetChapterAudio")]
        [HttpGet]
        public async Task<ReponderModel<BookChapterVoiceModel>> GetChapterAudio(string chapterId)
        {
            var result = await _bookRepository.GetChapterAudio(chapterId);
            return result;
        }

        [Route("UpdatePriceChapterVoice")]
        [HttpPost]
        public async Task<ReponderModel<string>> UpdatePriceChapterVoice(BookChapterVoiceModel model)
        {
            var result = await _bookRepository.UpdatePriceChapterVoice(model);
            return result;
        }

        [Route("GetCommentByBook")]
        [HttpGet]
        public async Task<ReponderModel<CommentModel>> GetCommentByBook(int bookId)
        {
            var result = await _bookRepository.GetCommentByBook(bookId);
            return result;
        }

        [Route("UpdateComment")]
        [HttpPost]
        public async Task<ReponderModel<string>> UpdateComment(Comment comment)
        {
            var result = await _bookRepository.UpdateComment(comment);
            return result;
        }

        [Route("BanBook")]
        [HttpGet]
        public async Task<ReponderModel<string>> BanBook(int id)
        {
            var result = await _bookRepository.BanBook(id);
            return result;
        }

        [Route("UnBanBook")]
        [HttpGet]
        public async Task<ReponderModel<string>> UnBanBook(int id)
        {
            var result = await _bookRepository.UnBanBook(id);
            return result;
        }

        [Route("DeleteBook")]
        [HttpGet]
        public async Task<ReponderModel<string>> DeleteBook(int id)
        {
            var result = await _bookRepository.DeleteBook(id);
            return result;
        }

        [Route("ApproveBook")]
        [HttpGet]
        public async Task<ReponderModel<BookChapterApproveModel>> ApproveBook(int id)
        {
            var result = await _bookRepository.ApproveBook(id);
            return result;
        }

        [Route("UpdateApproveChapterBook")]
        [HttpGet]
        public async Task<ReponderModel<string>> UpdateApproveChapterBook(int bookId, string chapterId)
        {
            var result = await _bookRepository.UpdateApproveChapterBook(bookId, chapterId);
            return result;
        }

        [Route("CheckReadingEnough")]
        [HttpGet]
        public async Task<ReponderModel<string>> CheckReadingEnough(string username, int bookId)
        {
            var result = await _bookRepository.CheckReadingEnough(username, bookId);
            return result;
        }

        [Route("GetListBookChapterByUserName")]
        [HttpGet]
        public async Task<ReponderModel<BookChapterModel>> GetListBookChapterByUserName(int bookId, string? username)
        {
            var result = await _bookRepository.GetListBookChapterByUserName(bookId, username);
            return result;
        }


        [Route("Audio/{fileName}")]
        [HttpGet, HttpHead]
        public IActionResult GetAudio(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Resource", fileName);
            //filePath = Path.Combine(Directory.GetCurrentDirectory(), "bin", "Debug", "net8.0", "Resource", fileName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File không tồn tại");
            }

            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            var fileInfo = new FileInfo(filePath);
            var lastModified = fileInfo.LastWriteTimeUtc.ToString("R"); 

            Response.Headers["Accept-Ranges"] = "bytes";
            Response.Headers["Last-Modified"] = lastModified;
            Response.Headers["Cache-Control"] = "public,max-age=1209600";
            Response.Headers["Expires"] = DateTime.UtcNow.AddYears(100).ToString("R");

            return File(stream, "audio/mpeg", enableRangeProcessing: true);
        }

        [Route("DeclineChapterBook")]
        [HttpGet]
        public async Task<ReponderModel<string>> DeclineChapterBook(int bookId, string chapterId)
        {
            var result = await _bookRepository.DeclineChapterBook(bookId, chapterId);
            return result;
        }

        [Route("GetBookChapterWithVoice")]
        [HttpGet]
        public async Task<ReponderModel<BookChapterModel>> GetBookChapterWithVoice(string chapterId)
        {
            var result = await _bookRepository.GetBookChapterWithVoice(chapterId);
            return result;
        }

        [Route("SearchBook")]
        [HttpGet]
        public async Task<ReponderModel<BookModel>> SearchBook(string input)
        {
            var result = await _bookRepository.SearchBook(input);
            return result;
        }


        [Route("UpdateApproveBook")]
        [HttpGet]
        public async Task<ReponderModel<string>> UpdateApproveBook(int id, string chapterIds)
        {
            var result = await _bookRepository.UpdateApproveBook(id, chapterIds);
            return result;
        }

        [Route("UpdateBookChapterView")]
        [HttpPost]
        public async Task<ReponderModel<string>> UpdateBookChapterView(UserBookView model)
        {
            var result = await _bookRepository.UpdateBookChapterView(model);
            return result;
        }

        [Route("StatisticsChapterBook")]
        [HttpGet]
        public async Task<ReponderModel<StatisticsChapterBook>> StatisticsChapterBook(int bookId)
        {
            var result = await _bookRepository.StatisticsChapterBook(bookId);
            return result;
        }

        [Route("StatisticsBook")]
        [HttpGet]
        public async Task<ReponderModel<StatisticsChapterBook>> StatisticsBook(string username)
        {
            var result = await _bookRepository.StatisticsBook(username);
            return result;
        }

        [Route("GetCategories")]
        [HttpGet]
        public async Task<ReponderModel<Category>> GetCategories()
        {
            var result = await _bookRepository.GetCategories();
            return result;
        }

        [Route("UpdateCategory")]
        [HttpPost]
        public async Task<ReponderModel<string>> UpdateCategory(Category model)
        {
            var result = await _bookRepository.UpdateCategory(model);
            return result;
        }

        [Route("CreateBook")]
        [HttpPost]
        public async Task<ReponderModel<string>> CreateBook(BookModel bookModel)
        {
            var result = await _bookRepository.CreateBook(bookModel);
            return result;
        }

        [Route("GetAnalysis")]
        [HttpGet]
        public async Task<ReponderModel<string>> GetAnalysis(string input)
        {
            var result = await _bookRepository.GetAnalysis(input);
            return result;
        }

        [Route("CheckFinishBook")]
        [HttpGet]
        public async Task<ReponderModel<string>> CheckFinishBook(int bookId)
        {
            var result = await _bookRepository.CheckFinishBook(bookId);
            return result;
        }

        [Route("UpdateFinishBook")]
        [HttpGet]
        public async Task<ReponderModel<string>> UpdateFinishBook(int bookId, int price)
        {
            var result = await _bookRepository.UpdateFinishBook(bookId,price);
            return result;
        }

        [Route("HiddenChapterBook")]
        [HttpGet]
        public async Task<ReponderModel<string>> HiddenChapterBook(string id)
        {
            var result = await _bookRepository.HiddenChapterBook(id);
            return result;
        }

        [Route("GetBookHomePage")]
        [HttpGet]
        public async Task<ReponderModel<BookHomePageModel>> GetBookHomePage()
        {
            var result = await _bookRepository.GetBookHomePage();
            return result;
        }

        [Route("GetTop10CategoryView")]
        [HttpGet]
        public async Task<ReponderModel<CategoryModel>> GetTop10CategoryView()
        {
            var result = await _bookRepository.GetTop10CategoryView();
            return result;
        }

        [Route("CheckPaidWithBookChapter")]
        [HttpGet]
        public async Task<ReponderModel<bool>> CheckPaidWithBookChapter(string username, int bookId)
        {
            var result = await _bookRepository.CheckPaidWithBookChapter(username, bookId);
            return result;
        }

        [Route("GetListNote")]
        [HttpGet]
        public async Task<ReponderModel<NoteUser>> GetListNote(string username, int bookId)
        {
            var result = await _bookRepository.GetListNote(username, bookId);
            return result;
        }

        [Route("GetTop10BookRating")]
        [HttpGet]
        public async Task<ReponderModel<BookRatingModel>> GetTop10BookRating()
        {
            var result = await _bookRepository.GetTop10BookRating();
            return result;
        }

        [Route("GetTop10NewBook")]
        [HttpGet]
        public async Task<ReponderModel<BookModel>> GetTop10NewBook()
        {
            var result = await _bookRepository.GetTop10NewBook();
            return result;
        }

        [Route("UpdateNoteUser")]
        [HttpPost]
        public async Task<ReponderModel<string>> UpdateNoteUser(NoteUser note)
        {
            var result = await _bookRepository.UpdateNoteUser(note);
            return result;
        }

        [Route("DeleteNoteUser")]
        [HttpGet]
        public async Task<ReponderModel<string>> DeleteNoteUser(int id)
        {
            var result = await _bookRepository.DeleteNoteUser(id);
            return result;
        }

        [Route("UpdateBook")]
        [HttpPost]
        public async Task<ReponderModel<string>> UpdateBook(BookModel bookModel)
        {
            var result = await _bookRepository.UpdateBook(bookModel);
            return result;
        }

        [Route("GetAllBookByCategory")]
        [HttpGet]
        public async Task<ReponderModel<BookViewModel>> GetAllBookByCategory(string category)
        {
            var result = await _bookRepository.GetAllBookByCategory(category);
            return result;
        }

        [Route("QuicklyApproveChapterContent")]
        [HttpPost]
        public async Task<ReponderModel<string>> QuicklyApproveChapterContent(RequestModel model)
        {
            var result = await _bookRepository.QuicklyApproveChapterContent(model.Data);
            return result;
        }

        [Route("CreateBookChapter")]
        [HttpPost]
        public async Task<ReponderModel<string>> CreateBookChapter(BookChapter bookChapter)
        {
            var result = await _bookRepository.CreateBookChapter(bookChapter);
            return result;
        }

        [Route("GetBookChapter")]
        [HttpGet]
        public async Task<ReponderModel<BookChapter>> GetBookChapter(string id)
        {
            var result = await _bookRepository.GetBookChapter(id);
            return result;
        }

        [Route("UpdateBookChapter")]
        [HttpPost]
        public async Task<ReponderModel<string>> UpdateBookChapter(BookChapter bookChapter)
        {
            var result = await _bookRepository.UpdateBookChapter(bookChapter);
            return result;
        }


        [Route("GetListBookChapter")]
        [HttpGet]
        public async Task<ReponderModel<BookChapter>> GetListBookChapter(int bookId)
        {
            var result = await _bookRepository.GetListBookChapter(bookId);
            return result;
        }

        [Route("CreateViewBook")]
        [HttpPost]
        public async Task<ReponderModel<int>> CreateViewBook(UserBookViewModel userBookView)
        {
            var result = await _bookRepository.CreateViewBook(userBookView);
            return result;
        }

        [Route("GetViewNo")]
        [HttpGet]
        public async Task<ReponderModel<int>> GetViewNo(int bookId, int chapterType)
        {
            var chapterTypeEnum = (BookTypeStatus)chapterType;
            var result = await _bookRepository.GetViewNo(bookId, chapterTypeEnum);
            return result;
        }

        [Route("DeleteChapterBook")]
        [HttpGet]
        public async Task<ReponderModel<string>> DeleteChapterBook(string id)
        {
            var result = await _bookRepository.DeleteChapterBook(id);
            return result;
        }

        [Route("AddOrRemoveFavouriteBook")]
        [HttpGet]
        public async Task<ReponderModel<string>> AddOrRemoveFavouriteBook(string userName,int bookId)
        {
            var result = await _bookRepository.AddOrRemoveFavouriteBook(userName,bookId);
            return result;
        }

        [Route("GetTop10FavoriteBook")]
        [HttpGet]
        public async Task<ReponderModel<BookModel>> GetTop10FavoriteBook()
        {
            var result = await _bookRepository.GetTop10FavoriteBook();
            return result;
        }

        [Route("ListFavouriteBook")]
        [HttpGet]
        public async Task<ReponderModel<UserBook>> ListFavouriteBook(string userName)
        {
            var result = await _bookRepository.ListFavouriteBook(userName);
            return result;
        }

        [Route("GetListMinuteViewByUser")]
        [HttpGet]
        public async Task<ReponderModel<UserMinuteModel>> GetListMinuteViewByUser(string userName)
        {
            var result = await _bookRepository.GetListMinuteViewByUser(userName);
            return result;
        }

        [Route("GetDrafts")]
        [HttpGet]
        public async Task<ReponderModel<DraftModel>> GetDrafts(string userName)
        {
            var result = await _bookRepository.GetDrafts(userName);
            return result;
        }
  

        [Route("GetBook")]
        [HttpGet]
        public async Task<ReponderModel<BookModel>> GetBook(int id)
        {
            var result = await _bookRepository.GetBook(id);
            return result;
        }

        [Route("GetAllBookByUser")]
        [HttpGet]
        public async Task<ReponderModel<BookViewModel>> GetAllBookByUser(string userName)
        {
            var result = await _bookRepository.GetAllBookByUser(userName);
            return result;
        }


        [Route("GenerateSummary")]
        [HttpPost]
        public async Task<ReponderModel<string>> GenerateSummary(RequestModel model)
        {
            var result = await _bookRepository.GenerateSummary(model.Data);
            return result;
        }


        [Route("GeneratePoster")]
        [HttpPost]
        public async Task<ReponderModel<string>> GeneratePoster(RequestModel model)
        {
            var result = await _bookRepository.GeneratePoster(model.Data,model.OptionData);
            return result;
        }

        [Route("GenerateTextToAudio")]
        [HttpPost]
        public async Task<ReponderModel<string>> GenerateTextToAudio(RequestModel model)
        {
            var result = await _bookRepository.GenerateTextToAudio(model.Data);
            return result;
        }

        [Route("GenerateTextToImage")]
        [HttpPost]
        public async Task<ReponderModel<string>> GenerateTextToImage(RequestModel model)
        {
            var result = await _bookRepository.GenerateTextToImage(model.Data);
            return result;
        }


        [Route("DeleteCategory")]
        [HttpGet]
        public async Task<ReponderModel<string>> DeleteCategory(int id)
        {
            var result = await _bookRepository.DeleteCategory(id);
            return result;
        }
    }
}
