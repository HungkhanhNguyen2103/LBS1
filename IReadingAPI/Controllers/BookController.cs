using BusinessObject;
using BusinessObject.BaseModel;
using Microsoft.AspNetCore.Mvc;
using OpenAI.Chat;
using Repositories;
using Repositories.IRepository;
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
            await _bookRepository.GetBookImages();
            return true;
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

        [Route("Audio/{fileName}")]
        [HttpGet, HttpHead]
        public IActionResult GetAudio(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Resource", fileName);

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
        public async Task<ReponderModel<string>> UpdateApproveBook(int id)
        {
            var result = await _bookRepository.UpdateApproveBook(id);
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

        [Route("AddFavouriteBook")]
        [HttpGet]
        public async Task<ReponderModel<string>> AddFavouriteBook(string userName,int bookId)
        {
            var result = await _bookRepository.AddFavouriteBook(userName,bookId);
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
