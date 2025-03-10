using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessObject;
using BusinessObject.BaseModel;
using LBSWeb.Service.Book;
using LBSWeb.Service.Information;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace LBSWeb.Controllers
{
    [Route("Admin")]
    public class AdminController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IInformationService _informationService;
        private readonly INotyfService _notyf;

        public AdminController(IBookService bookService,IInformationService informationService, INotyfService notyf) 
        {
            _bookService = bookService;
            _informationService = informationService;
            _notyf = notyf;
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Author},{Role.Manager}")]
        [Route("")]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole(Role.Author))
            {
                return RedirectToAction("Notifications");
            }

            var result = await _bookService.ShortReport();
            return View(result.Data);
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Author},{Role.Manager}")]
        [Route("Books")]
        public async Task<IActionResult> Books()
        {
            var userName = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var res = await _bookService.GetAllBookByUser(userName);
            ViewBag.Books = res.DataList;
            return View();
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Author}")]
        [Route("BasicKnowledge")]
        public IActionResult BasicKnowledge()
        {
            return View();
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Author}")]
        [Route("GetListKnowledge")]
        public async Task<IActionResult> GetListKnowledge(string search = "")
        {
            var res = await _informationService.BasicKnowledge(search);
            return Json(res.DataList);
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Author}")]
        [Route("UpdateConspectus")]
        [HttpPost]
        public async Task<IActionResult> UpdateConspectus(Conspectus model)
        {
            model.CreateBy = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            model.UserId = User.FindFirst(ClaimTypes.PrimarySid).Value;
            var result = await _informationService.UpdateConspectus(model);
            if (result.IsSussess)
            {
                _notyf.Success(result.Message);
                return RedirectToAction("ListConspectus");
            }
            else
            {
                _notyf.Error(result.Message);
                return View(model);
            }
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Author}")]
        [Route("CreateConspectus")]
        public IActionResult CreateConspectus()
        {
            return View();
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Author}")]
        [Route("ConspectusDetail/{id}")]
        public async Task<IActionResult> ConspectusDetail(int id)
        {
            var res = await _informationService.ConspectusDetail(id);
            return View(res.Data);
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Author}")]
        [Route("DeleteConspectus/{id}")]
        public async Task<IActionResult> DeleteConspectus(int id)
        {
            var res = await _informationService.DeleteConspectus(id);
            return Json(res);
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Author},{Role.Manager}")]
        [Route("UserReport")]
        public async Task<IActionResult> UserReport()
        {
            return View();
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Author}")]
        [Route("ListConspectus")]
        public async Task<IActionResult> ListConspectus()
        {
            var userName = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var res = await _informationService.ListConspectus(userName);
            ViewBag.Conspectuses = res.DataList;
            return View();
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Author}")]
        [Route("Notifications")]
        public async Task<IActionResult> Notifications()
        {
            var res = await _informationService.ListNotification();
            return View(res.DataList);
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Author}")]
        [Route("NotifiDetail/{id}")]
        public async Task<IActionResult> NotifiDetail(int id)
        {
            var res = await _informationService.NotificationDetail(id);
            return View(res.Data);
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Author}")]
        [Route("KnowledgeDetail/{id}")]
        public async Task<IActionResult> KnowledgeDetail(int id)
        {
            var res = await _informationService.KnowledgeDetail(id);
            return View(res.Data);
        }

        [Authorize(Roles = $"{Role.Author}")]
        [HttpPost]
        [Route("GenerateSummary")]
        public async Task<IActionResult> GenerateSummary(string input)
        {
            //Response.ContentType = "text/event-stream";
            //Response.Headers. = "text/event-stream";
            //Response.Headers.Add("Content-Type", "text/event-stream");
            //Response.Headers.Add("Cache-Control", "no-cache");
            //Response.Headers.Add("Connection", "keep-alive");
            var res = await _bookService.GenerateSummary(input);

            //var messages = res.Data.Split(" ").ToList();
            //foreach (var item in messages)
            //{
            //    await Response.Body.WriteAsync(Encoding.UTF8.GetBytes(item));
            //    await Response.Body.FlushAsync();
            //    await Task.Delay(300);
            //}

            return Json(res);
        }


        [Authorize(Roles = $"{Role.Admin},{Role.Manager}")]
        [Route("ListCategories")]
        public async Task<IActionResult> ListCategories()
        {
            var result = await _bookService.GetCategories();
            ViewBag.Categories = result.DataList;
            return View();
        }

        [Authorize(Roles = $"{Role.Author}")]
        [Route("CreateBook")]
        public async Task<IActionResult> CreateBook()
        {
            var result = await _bookService.GetCategories();
            ViewBag.Categories = result.DataList;
            return View();
        }

        [Authorize(Roles = $"{Role.Author}")]
        [Route("CreateBook")]
        [HttpPost]
        public async Task<IActionResult> CreateBook(BookModel bookModel)
        {
            bookModel.CreateBy = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            bookModel.UserId = User.FindFirst(ClaimTypes.PrimarySid).Value;
            var result = await _bookService.CreateBook(bookModel);
            ViewBag.Categories = result.DataList;
            if (result.IsSussess) 
            { 
                _notyf.Success(result.Message);
                return RedirectToAction("Books");
            }
            else
            {
                _notyf.Error(result.Message);
                return View(bookModel);
            }

        }

        [Authorize(Roles = $"{Role.Author}")]
        [Route("UpdateBook/{id}")]
        public async Task<IActionResult> UpdateBook(int id)
        {
            var result = await _bookService.GetCategories();
            ViewBag.Categories = result.DataList;
            var resultBook = await _bookService.GetBook(id);
            return View(resultBook.Data);
        }

        [Authorize(Roles = $"{Role.Author}")]
        [Route("UpdateBook/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateBook(Book bookModel)
        {
            //bookModel.Id = id;
            var result = await _bookService.UpdateBook(bookModel);
            if (result.IsSussess)
            {
                _notyf.Success(result.Message);
                return RedirectToAction("Books");
            }
            else
            {
                _notyf.Error(result.Message);
                return View(bookModel);
            }

        }

        [Authorize(Roles = $"{Role.Author}")]
        [Route("Drafts")]
        public async Task<IActionResult> Drafts()
        {
            var userName = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result = await _bookService.GetDrafts(userName);
            ViewBag.Drafts = result.DataList;
            return View();
        }

        [Authorize(Roles = $"{Role.Author}")]
        [Route("{id}/CreateChapterBook")]
        public async Task<IActionResult> CreateChapterBook(int id,string returnUrl = "")
        {
            ViewBag.BookId = id;         
            var result = await _bookService.GetBook(id);
            var resultChapterBook = await _bookService.GetListBookChapter(id);

            var startChapterId = resultChapterBook.DataList.Count + 1;

            ViewBag.StartChapterId = startChapterId;
            ViewBag.ReturnUrl = returnUrl;

            ViewBag.BookName = result.Data.Name;
            return View(new BookChapter { BookId = id, ChaperId = startChapterId });
        }

        [Authorize(Roles = $"{Role.Author}")]
        [Route("DeleteChapterBook/{chapterId}")]
        public async Task<IActionResult> DeleteChapterBook(string chapterId)
        {
            var result = await _bookService.DeleteChapterBook(chapterId);
            //if (result.IsSussess) _notyf.Success(result.Message);
            return Json(result);
        }

        [Authorize(Roles = $"{Role.Author}")]
        [Route("{id}/UpdateChapterBook/{chapterId}")]
        public async Task<IActionResult> UpdateChapterBook(int id,string chapterId, string returnUrl)
        {
            ViewBag.BookId = id;
            ViewBag.ReturnUrl = returnUrl;
            var result = await _bookService.GetBook(id);
            var resultChapterBook = await _bookService.GetBookChapter(chapterId);
            ViewBag.BookName = result.Data.Name;
            return View(resultChapterBook.Data);
        }

        [HttpPost]
        [Authorize(Roles = $"{Role.Author}")]
        [Route("UpdateChapterBook")]
        public async Task<IActionResult> UpdateChapterBook(BookChapter bookChapter)
        {
            var result = await _bookService.UpdateBookChapter(bookChapter);
            if (result.IsSussess)
            {
                _notyf.Success(result.Message);
                return RedirectToAction("ChapterBooks");
            }
            else
            {
                _notyf.Error(result.Message);
                return View(bookChapter);
            }
        }


        [HttpPost]
        [Authorize(Roles = $"{Role.Author}")]
        [Route("GeneratePoster")]
        public async Task<IActionResult> GeneratePoster(string input)
        {
            var result = await _bookService.GeneratePoster(input);
            return Json(result);
        }

        [Authorize(Roles = $"{Role.Author}")]
        [Route("{bookId}/ChapterBooks")]
        public async Task<IActionResult> ChapterBooks(int bookId)
        {
            ViewBag.BookId = bookId;
            var result = await _bookService.GetListBookChapter(bookId);
            ViewBag.ChapterBooks = result.DataList;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = $"{Role.Author}")]
        [Route("Admin/CreateChapterBook")]
        public async Task<IActionResult> CreateChapterBook(BookChapter bookChapter)
        {
            bookChapter.CreateBy = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            bookChapter.UserId = User.FindFirst(ClaimTypes.PrimarySid).Value;

            var result = await _bookService.CreateBookChapter(bookChapter);
            if (result.IsSussess)
            {
                _notyf.Success(result.Message);
                return RedirectToAction("Books");
            }
            else
            {
                _notyf.Error(result.Message);
                return View(bookChapter);
            }
            
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Manager}")]
        [Route("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _bookService.DeleteCategory(id);
            return Json(result.Message);
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Manager}")]
        [HttpPost]
        [Route("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(Category model)
        {
            var result = await _bookService.UpdateCategory(model);
            if (result.IsSussess) _notyf.Success(result.Message);
            else _notyf.Error(result.Message);
            return RedirectToAction("ListCategories");
        }
    }
}
