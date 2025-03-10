using BusinessObject;
using BusinessObject.BaseModel;
using Microsoft.AspNetCore.Mvc;
using OpenAI.Chat;
using Repositories;
using Repositories.IRepository;
using System.Text;

namespace LBSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController
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
        public async Task<ReponderModel<string>> UpdateBook(Book bookModel)
        {
            var result = await _bookRepository.UpdateBook(bookModel);
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

        [Route("DeleteChapterBook")]
        [HttpGet]
        public async Task<ReponderModel<string>> DeleteChapterBook(string id)
        {
            var result = await _bookRepository.DeleteChapterBook(id);
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
        public async Task<ReponderModel<Book>> GetBook(int id)
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
            var result = await _bookRepository.GeneratePoster(model.Data);
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
