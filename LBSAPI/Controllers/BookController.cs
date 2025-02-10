using BusinessObject.BaseModel;
using Microsoft.AspNetCore.Mvc;
using Repositories.IRepository;

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
    }
}
