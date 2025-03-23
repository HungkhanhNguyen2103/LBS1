using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessObject;
using BusinessObject.BaseModel;
using LBSWeb.Service.Book;
using LBSWeb.Service.Information;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
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
        public async Task<IActionResult> Books(int bookType = 5)
        {
            var userName = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var res = await _bookService.GetAllBookByUser(userName);
            if(User.IsInRole("Manager")){
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

        [Authorize(Roles = $"{Role.Admin},{Role.Author},{Role.Manager}")]
        [Route("CloseUserReport/{id}")]
        public async Task<IActionResult> CloseUserReport(int id)
        {
            var res = await _informationService.CloseUserReport(id);
            return Json(res);
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Author},{Role.Manager}")]
        [Route("OpenUserReport/{id}")]
        public async Task<IActionResult> OpenUserReport(int id)
        {
            var res = await _informationService.OpenUserReport(id);
            return Json(res);
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Author}")]
        [Route("DeleteConspectus/{id}")]
        public async Task<IActionResult> DeleteConspectus(int id)
        {
            var res = await _informationService.DeleteConspectus(id);
            return Json(res);
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Author},{Role.Manager}")]
        [Route("UserReport/{type}")]
        public async Task<IActionResult> UserReport(int type, int status = 1)
        {
            ViewBag.Status = status;
            var userName = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (status < 0 || status > 1 || type < 0 || type > 1)
            {
                return Redirect("/Account/AccessDenied");
            }

            var statusEnum = (UserReportStatus)status;

            var userType = UserReportType.Author;
            if(User.IsInRole("Author"))
            {
                if(type == 1) userType = UserReportType.Author;
                else if(type == 0) userType = UserReportType.User;
            }
            else if (User.IsInRole("Manager"))
            {
                userType = UserReportType.Author;
            }
            var result = await _informationService.ListUserReport(userName, userType);
            var dataList = result.DataList.Where(c => c.UserReportStatus == statusEnum).ToList();
            ViewBag.ReportType = type;
            ViewBag.ListUserReport = dataList;
            ViewBag.FirstId = dataList.FirstOrDefault() != null ? dataList.First().Id : 0;
            return View();
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Author}")]
        [Route("CreateUserReport")]
        [HttpPost]
        public async Task<IActionResult> CreateUserReport(UserReport model)
        {
            model.CreateBy = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            model.UserId = User.FindFirst(ClaimTypes.PrimarySid).Value;
            model.ReportType = UserReportType.Author;
            var result = await _informationService.CreateUserReport(model);
            if (result.IsSussess) _notyf.Success(result.Message);
            else _notyf.Error(result.Message);
            return Redirect("/Admin/UserReport/1");
        }

        [Authorize(Roles = $"{Role.Manager},{Role.Author}")]
        [Route("StatisticsChapterBook/{bookId}")]
        [HttpGet]
        public async Task<IActionResult> StatisticsChapterBook(int bookId)
        {
            var result = await _bookService.StatisticsChapterBook(bookId);
            return Json(result.Data);
        }

        [Authorize(Roles = $"{Role.Manager},{Role.Author}")]
        [Route("Statistics")]
        [HttpGet]
        public IActionResult Statistics()
        {
            return View();
        }

        [Authorize(Roles = $"{Role.Manager},{Role.Author}")]
        [Route("StatisticsBook")]
        [HttpGet]
        public async Task<IActionResult> StatisticsBook()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result = await _bookService.StatisticsBook(username);
            return Json(result.Data);
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Author},{Role.Manager}")]
        [Route("UserReportDetail/{id}")]
        public async Task<IActionResult> UserReportDetail(int id)
        {
            var result = await _informationService.UserReport(id);
            return Json(result);
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

        [Authorize(Roles = $"{Role.Admin},{Role.Manager}")]
        [HttpPost]
        [Route("UpdateNotification")]
        public async Task<IActionResult> UpdateNotification(BusinessObject.Notification model)
        {
            var result = await _informationService.UpdateNotification(model);
            if (result.IsSussess) _notyf.Success(result.Message);
            else _notyf.Error(result.Message);
            return RedirectToAction("ListNotifications");
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Manager}")]
        [Route("DeleteNotification")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            var result = await _informationService.DeleteNotification(id);
            return Json(result.Message);
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

        [Authorize(Roles = $"{Role.Admin},{Role.Manager}")]
        [Route("ListNotifications")]
        public async Task<IActionResult> ListNotifications()
        {
            var result = await _informationService.ListNotification();
            ViewBag.Notifications = result.DataList;
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

        [Authorize(Roles = $"{Role.Manager}")]
        [Route("ApproveBook/{id}")]
        public async Task<IActionResult> ApproveBook(int id)
        {
            var result = await _bookService.ApproveBook(id);
            ViewBag.AppoveSupport = result.DataList;
            ViewBag.BookId = id;
            return View();
        }

        [Authorize(Roles = $"{Role.Manager}")]
        [Route("UpdateApproveBook/{id}")]
        public async Task<IActionResult> UpdateApproveBook(int id)
        {
            var result = await _bookService.UpdateApproveBook(id);
            return Json(result);
        }

        [Authorize(Roles = $"{Role.Author}")]
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

        [Authorize(Roles = $"{Role.Author},{Role.Manager}")]
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
            ViewBag.ChapterId = chapterId;
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
                return Redirect($"/Admin/{bookChapter.BookId}/ChapterBooks");
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
        public async Task<IActionResult> GeneratePoster(string input,string summary)
        {
            var result = await _bookService.GeneratePoster(input, summary);
            return Json(result);
        }

        [Authorize(Roles = $"{Role.Author},{Role.Manager}")]
        [Route("{bookId}/ChapterBooks")]
        public async Task<IActionResult> ChapterBooks(int bookId)
        {
            ViewBag.BookId = bookId;
            var result = await _bookService.GetListBookChapter(bookId);
            ViewBag.ChapterBooks = result.DataList;
            return View();
        }

        [Authorize(Roles = $"{Role.Manager}")]
        [Route("ListBasicKnowledge")]
        public async Task<IActionResult> ListBasicKnowledge(int category = 0)
        {
            if (category > 4 || category < 0)
            {
                category = 0;
                //return Redirect("/Admin/ListBasicKnowledge");
            }
            var knowledge = (CategoryKnowledgeType)category;
            var res = await _informationService.BasicKnowledge("");
            ViewBag.ListBasicKnowledge = res.DataList.Where(c => c.Category == knowledge);
            ViewBag.Category = category;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = $"{Role.Manager}")]
        [Route("UpdateBasicKnowledge")]
        public async Task<IActionResult> UpdateBasicKnowledge(BasicKnowledge model)
        {
            var result = await _informationService.UpdateBasicKnowledge(model);
            if (result.IsSussess)
            {
                _notyf.Success(result.Message);
                return RedirectToAction("ListBasicKnowledge");
            }
            else
            {
                _notyf.Error(result.Message);
                return View(model);
            }

        }

        [Authorize(Roles = $"{Role.Manager}")]
        [Route("DeleteBasicKnowledge")]
        public async Task<IActionResult> DeleteBasicKnowledge(int id)
        {
            var result = await _informationService.DeleteBasicKnowledge(id);
            return Json(result);
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
                return Redirect($"/Admin/{bookChapter.BookId}/ChapterBooks");
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
