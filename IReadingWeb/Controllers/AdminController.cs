using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessObject;
using BusinessObject.BaseModel;
using IReadingWeb.Service.Payment;
using LBSWeb.Service.Book;
using LBSWeb.Service.Information;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Newtonsoft.Json;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace LBSWeb.Controllers
{
    [Route("Admin")]
    public class AdminController : Controller
    {
        private readonly IBookService _bookService;
        //private readonly IInformationService _informationService;
        //private readonly IPaymentService _paymentService;
        private readonly INotyfService _notyf;

        public AdminController(IBookService bookService,
            //IInformationService informationService, 
            INotyfService notyf,
            IPaymentService paymentService) 
        {
            _bookService = bookService;
            //_informationService = informationService;
            _notyf = notyf;

        }

        [Authorize(Roles = $"{Role.Admin},{Role.Author},{Role.Manager}")]
        [Route("")]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole(Role.Author))
            {
                return Redirect("/Information/Notifications");
            }

            var result = await _bookService.ShortReport();
            return View(result.Data);
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Author},{Role.Manager}")]
        [Route("Books")]
        public async Task<IActionResult> Books(int bookType = 5)
        {
            var userName = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var res = await _bookService.GetAllBookByUser(userName);
            if(User.IsInRole("Manager") || User.IsInRole("Admin"))
            {
                if (bookType < 0 || bookType > 5)
                {
                    return Redirect("/Account/AccessDenied");
                }
                ViewBag.BookType = bookType;
                var bookStatus = (BookStatus)bookType;
                res.DataList = res.DataList.Where(c => c.Status == bookStatus).ToList();
            }
            ViewBag.Books = res.DataList;
            return View();
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Author}")]
        [Route("HiddenChapterBook")]
        [HttpGet]
        public async Task<IActionResult> HiddenChapterBook(string id)
        {
            var res = await _bookService.HiddenChapterBook(id);
            return Json(res);
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Manager}")]
        [Route("BanBook")]
        [HttpGet]
        public async Task<IActionResult> BanBook(int id)
        {
            var res = await _bookService.BanBook(id);
            return Json(res);
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Manager}")]
        [Route("UnBanBook")]
        [HttpGet]
        public async Task<IActionResult> UnBanBook(int id)
        {
            var res = await _bookService.UnBanBook(id);
            return Json(res);
        }



        [Authorize(Roles = $"{Role.Manager},{Role.Author},{Role.Admin}")]
        [Route("StatisticsChapterBook/{bookId}")]
        [HttpGet]
        public async Task<IActionResult> StatisticsChapterBook(int bookId)
        {
            var result = await _bookService.StatisticsChapterBook(bookId);
            return Json(result.Data);
        }

        [Authorize(Roles = $"{Role.Manager},{Role.Author},{Role.Admin}")]
        [Route("Statistics")]
        [HttpGet]
        public IActionResult Statistics()
        {
            return View();
        }

        [Authorize(Roles = $"{Role.Manager},{Role.Author},{Role.Admin}")]
        [Route("StatisticsBook")]
        [HttpGet]
        public async Task<IActionResult> StatisticsBook()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result = await _bookService.StatisticsBook(username);
            return Json(result.Data);
        }

        [Authorize(Roles = $"{Role.Author},{Role.Admin}")]
        [Route("CheckFinishBook")]
        [HttpGet]
        public async Task<IActionResult> CheckFinishBook(int bookId)
        {
            var result = await _bookService.CheckFinishBook(bookId);
            return Json(result);
        }

        [Authorize(Roles = $"{Role.Author},{Role.Admin}")]
        [Route("UpdateFinishBook")]
        [HttpGet]
        public async Task<IActionResult> UpdateFinishBook(int bookId,int price)
        {
            var result = await _bookService.UpdateFinishBook(bookId, price);
            return Json(result);
        }

        [Authorize(Roles = $"{Role.Author},{Role.Admin}")]
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


        [Authorize(Roles = $"{Role.Admin},{Role.Manager},{Role.Admin}")]
        [Route("ListCategories")]
        public async Task<IActionResult> ListCategories()
        {
            var result = await _bookService.GetCategories();
            ViewBag.Categories = result.DataList;
            return View();
        }


        [Authorize(Roles = $"{Role.Author},{Role.Admin}")]
        [Route("CreateBook")]
        public async Task<IActionResult> CreateBook()
        {
            var result = await _bookService.GetCategories();
            ViewBag.Categories = result.DataList;
            return View();
        }

        [Authorize(Roles = $"{Role.Manager},{Role.Admin}")]
        [Route("ApproveBook/{id}")]
        public IActionResult ApproveBook(int id)
        {
            //var result = await _bookService.ApproveBook(id);
            //ViewBag.AppoveSupport = result.DataList;
            ViewBag.BookId = id;
            return View();
        }

        [Authorize(Roles = $"{Role.Manager},{Role.Admin}")]
        [Route("GetListApproveBook/{id}")]
        public async Task<IActionResult> GetListApproveBook(int id)
        {
            var result = await _bookService.ApproveBook(id);
            //ViewBag.AppoveSupport = result.DataList;
            //ViewBag.BookId = id;
            return Json(result);
        }

        [Authorize(Roles = $"{Role.Manager},{Role.Admin}")]
        [Route("UpdateApproveBook/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateApproveBook(int id, string chapterIds)
        {
            var result = await _bookService.UpdateApproveBook(id, chapterIds);
            return Json(result);
        }

        [Authorize(Roles = $"{Role.Manager},{Role.Admin}")]
        [Route("{bookId}/ChapterBookAudio/{chapterId}")]
        //[HttpGet]
        public IActionResult ChapterBookAudio(int bookId, string chapterId)
        {
            ViewBag.BookId = bookId;
            ViewBag.ChapterId = chapterId;
            return View(new BookChapterVoiceModel { });
        }

        [Authorize(Roles = $"{Role.Manager},{Role.Admin}")]
        [Route("GetChapterBookAudio")]
        //[HttpGet]
        public async Task<IActionResult> GetChapterBookAudio(string chapterId)
        {
            //ViewBag.BookId = bookId;
            var result = await _bookService.GetChapterAudio(chapterId);
            return Json(result.Data);
        }

        [Authorize(Roles = $"{Role.Manager},{Role.Admin}")]
        [HttpPost]
        [Route("{bookId}/ChapterBookAudio/{chapterId}")]
        public async Task<IActionResult> ChapterBookAudio(int bookId, string chapterId,BookChapterVoiceModel model)
        {
            model.ChapterId = chapterId;
            var result = await _bookService.UpdatePriceChapterVoice(model);
            if (result.IsSussess)
            {
                _notyf.Success(result.Message);
                return Redirect($"/Admin/{bookId}/ChapterBooks");
            }
            else
            {
                _notyf.Error(result.Message);
                var resultData = await _bookService.GetChapterAudio(chapterId);
                resultData.Data.Price = model.Price;
                return View(resultData.Data);
            }

        }

        [Authorize(Roles = $"{Role.Author},{Role.Admin}")]
        [Route("CreateBook")]
        [HttpPost]
        public async Task<IActionResult> CreateBook(BookModel bookModel)
        {
            bookModel.CreateBy = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            bookModel.UserId = User.FindFirst(ClaimTypes.PrimarySid).Value;
            var result = await _bookService.CreateBook(bookModel);
            if (result.IsSussess) 
            { 
                _notyf.Success(result.Message);
                return RedirectToAction("Books");
            }
            else
            {
                var result1 = await _bookService.GetCategories();
                ViewBag.Categories = result1.DataList;
                _notyf.Error(result.Message);
                return View(bookModel);
            }

        }

        [Authorize(Roles = $"{Role.Author},{Role.Manager},{Role.Admin}")]
        [Route("UpdateBook/{id}")]
        public async Task<IActionResult> UpdateBook(int id)
        {
            var result = await _bookService.GetCategories();
            ViewBag.Categories = result.DataList;
            var resultBook = await _bookService.GetBook(id);
            return View(resultBook.Data);
        }

        [Authorize(Roles = $"{Role.Author},{Role.Manager},{Role.Admin}")]
        [Route("QuicklyApproveChapterContent")]
        [HttpPost]
        public async Task<IActionResult> QuicklyApproveChapterContent(RequestModel model)
        {
            var result = await _bookService.QuicklyApproveChapterContent(model);
            return Json(result.Data);
        }

        [Authorize(Roles = $"{Role.Author},{Role.Admin}")]
        [Route("UpdateBook/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateBook(BookModel bookModel)
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
                var result1 = await _bookService.GetCategories();
                ViewBag.Categories = result1.DataList;
                _notyf.Error(result.Message);
                return View(bookModel);
            }

        }

        [Authorize(Roles = $"{Role.Author},{Role.Admin}")]
        [Route("DeleteBook")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _bookService.DeleteBook(id);
            return Json(result);
        }

        [Authorize(Roles = $"{Role.Author},{Role.Admin}")]
        [Route("Drafts")]
        public async Task<IActionResult> Drafts()
        {
            var userName = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result = await _bookService.GetDrafts(userName);
            ViewBag.Drafts = result.DataList;
            return View();
        }

        [Authorize(Roles = $"{Role.Author},{Role.Admin}")]
        [Route("{id}/CreateChapterBook")]
        public async Task<IActionResult> CreateChapterBook(int id,string returnUrl = "")
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.BookId = id;         
            var result = await _bookService.GetBook(id);
            var resultChapterBook = await _bookService.GetListBookChapter(id);

            var startChapterId = resultChapterBook.DataList.Count + 1;

            var resultPaid = await _bookService.CheckPaidWithBookChapter(username, id);
            ViewBag.PaidChapter = resultPaid.Data;
            ViewBag.StartChapterId = startChapterId;
            ViewBag.ReturnUrl = returnUrl;

            ViewBag.BookName = result.IsSussess ? result.Data.Name : string.Empty;
            return View(new BookChapter { BookId = id, ChapterNumber = startChapterId });
        }

        [Authorize(Roles = $"{Role.Author},{Role.Admin}")]
        [Route("DeleteChapterBook/{chapterId}")]
        public async Task<IActionResult> DeleteChapterBook(string chapterId)
        {
            var result = await _bookService.DeleteChapterBook(chapterId);
            //if (result.IsSussess) _notyf.Success(result.Message);
            return Json(result);
        }

        [Authorize(Roles = $"{Role.Author},{Role.Manager},{Role.Admin}")]
        [Route("{id}/UpdateChapterBook/{chapterId}")]
        public async Task<IActionResult> UpdateChapterBook(int id,string chapterId, string returnUrl)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.BookId = id;
            ViewBag.ReturnUrl = returnUrl;
            var result = await _bookService.GetBook(id);
            var resultChapterBook = await _bookService.GetBookChapter(chapterId);
            var resultPaid = await _bookService.CheckPaidWithBookChapter(username, id);
            ViewBag.PaidChapter = resultPaid.Data;
            ViewBag.BookName = "";
            if (result.IsSussess) ViewBag.BookName = result.Data.Name;
            ViewBag.ChapterId = chapterId;
            return View(resultChapterBook.Data);
        }

        [HttpGet]
        [Authorize(Roles = $"{Role.Manager},{Role.Admin}")]
        [Route("UpdateApproveChapterBook/{id}")]
        public async Task<IActionResult> UpdateApproveChapterBook(int id,string chapterId)
        {
            var result = await _bookService.UpdateApproveChapterBook(id,chapterId);
            return Json(result);
        }

        [HttpGet]
        [Authorize(Roles = $"{Role.Manager},{Role.Admin}")]
        [Route("DeclineChapterBook/{id}")]
        public async Task<IActionResult> DeclineChapterBook(int id, string chapterId)
        {
            var result = await _bookService.DeclineChapterBook(id, chapterId);
            return Json(result);
        }

        [Authorize(Roles = $"{Role.Author},{Role.Manager},{Role.Admin}")]
        [Route("ContractAuthor/{bookId}/{chapterId}")]
        public async Task<IActionResult> ContractAuthor(int bookId,string chapterId,string returnUrl = "")
        {
            ViewBag.BookId = bookId;
            var result = await _bookService.GetBook(bookId);
            var resultChapterBook = await _bookService.GetBookChapter(chapterId);
            ViewBag.BookName = result.Data.Name;
            ViewBag.ChapterId = chapterId;
            //Admin/ApproveBook/1070
            ViewBag.ReturnUrl = returnUrl;
            return View(resultChapterBook.Data);
        }

        [HttpPost]
        [Authorize(Roles = $"{Role.Author},{Role.Admin}")]
        [Route("UpdateChapterBook")]
        public async Task<IActionResult> UpdateChapterBook(BookChapter bookChapter)
        {
            var result = await _bookService.UpdateBookChapter(bookChapter);
            if (result.IsSussess)
            {
                _notyf.Success(result.Message);
                return Redirect($"/Admin/{bookChapter.BookId}/ChapterBooks");
            }
            else
            {
                _notyf.Error(result.Message);
                return View(bookChapter);
            }
        }


        [HttpPost]
        [Authorize(Roles = $"{Role.Author},{Role.Admin}")]
        [Route("GeneratePoster")]
        public async Task<IActionResult> GeneratePoster(string input,string summary)
        {
            var result = await _bookService.GeneratePoster(input, summary);
            return Json(result);
        }

        [Authorize(Roles = $"{Role.Author},{Role.Manager},{Role.Admin}")]
        [Route("{bookId}/ChapterBooks")]
        public async Task<IActionResult> ChapterBooks(int bookId)
        {
            ViewBag.BookId = bookId;
            var book = await _bookService.GetBook(bookId);
            var item = book.Data;
            ViewBag.ButtonAddChapter = item.Status == BookStatus.Done || (item.BookTypePrice == BookTypePrice.PayByBook && item.Status == BookStatus.PendingApproval) ? "disabled" : "";
            ViewBag.ButtonFinish = item.BookTypePrice == BookTypePrice.PayByChapter || item.Status == BookStatus.Done || (item.BookTypePrice == BookTypePrice.PayByBook && item.Status == BookStatus.PendingApproval) ? "disabled" : "";
            var result = await _bookService.GetListBookChapter(bookId);
            ViewBag.ChapterBooks = result.DataList;
            ViewBag.HiddenOrRemoveChapter = item.Status == BookStatus.PendingPublication || item.Status == BookStatus.PendingApproval ? true : false;
            return View();
        }

        //[Authorize(Roles = $"{Role.Author},{Role.Manager}")]
        //[AllowAnonymous]


        [Authorize(Roles = $"{Role.Admin},{Role.Manager}")]
        [Route("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _bookService.DeleteCategory(id);
            return Json(result);
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



        [HttpPost]
        [Authorize(Roles = $"{Role.Author},{Role.Admin}")]
        [Route("{id}/CreateChapterBook")]
        public async Task<IActionResult> CreateChapterBook(BookChapter bookChapter, string returnUrl = "")
        {
            bookChapter.CreateBy = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            bookChapter.UserId = User.FindFirst(ClaimTypes.PrimarySid).Value;

            var result = await _bookService.CreateBookChapter(bookChapter);
            if (result.IsSussess)
            {
                _notyf.Success(result.Message);
                return Redirect($"/Admin/{bookChapter.BookId}/ChapterBooks");
            }
            else
            {
                //ViewBag.ReturnUrl = returnUrl;
                _notyf.Error(result.Message);
                return View(bookChapter);
            }

        }
    }
}
