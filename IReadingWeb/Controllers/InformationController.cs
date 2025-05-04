using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessObject;
using LBSWeb.Service.Information;
using LBSWeb.Services.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IReadingWeb.Controllers
{
    [Route("Information")]
    public class InformationController : Controller
    {
        private readonly IInformationService _informationService;
        private readonly IAccountService _accountService;
        private readonly INotyfService _notyf;
        public InformationController(IAccountService accountService,IInformationService informationService,INotyfService notyf)
        {
            _accountService = accountService;
            _informationService = informationService;
            _notyf = notyf;
        }

        [Authorize(Roles = $"{Role.Admin}")]
        [Route("ListAccount")]
        public async Task<IActionResult> ListAccount(string role = "Author")
        {
            var result = await _accountService.GetListAccount(role);
            ViewBag.ListAccount = result.DataList;
            ViewBag.Role = role;
            return View();
        }

        [Authorize(Roles = $"{Role.Admin}")]
        [Route("BanAccount")]

        public async Task<IActionResult> BanAccount(string username)
        {
            var result = await _accountService.ToggleLockUser(username,true);
            return Json(result);
        }

        [Authorize(Roles = $"{Role.Admin}")]
        [Route("UnBanAccount")]

        public async Task<IActionResult> UnBanAccount(string username)
        {
            var result = await _accountService.ToggleLockUser(username, false);
            return Json(result);
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Author}")]
        [Route("GetListKnowledge")]
        public async Task<IActionResult> GetListKnowledge(string search = "")
        {
            var res = await _informationService.BasicKnowledge(search);
            return Json(res.DataList);
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Author}")]
        [Route("CreateConspectus")]
        [HttpPost]
        public async Task<IActionResult> CreateConspectus(Conspectus model)
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
        [Route("BasicKnowledge")]
        public IActionResult BasicKnowledge()
        {
            return View();
        }


        [Authorize(Roles = $"{Role.Admin},{Role.Author}")]
        [Route("CreateConspectus")]
        public IActionResult CreateConspectus()
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
        [Route("ConspectusDetail/{id}")]
        public async Task<IActionResult> ConspectusDetail(int id)
        {
            var res = await _informationService.ConspectusDetail(id);
            return View(res.Data);
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Author}")]
        [Route("ConspectusDetail/{id}")]
        [HttpPost]
        public async Task<IActionResult> ConspectusDetail(Conspectus model)
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
            if (User.IsInRole("Author"))
            {
                if (type == 1) userType = UserReportType.Author;
                else if (type == 0) userType = UserReportType.User;
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
            return Redirect("/Information/UserReport/1");
        }

        [Authorize(Roles = $"{Role.Manager},{Role.Author},{Role.Admin}")]
        [Route("CreateUserReportComment/{type}")]
        [HttpPost]
        public async Task<IActionResult> CreateUserReportComment(int type, UserReportComment model)
        {
            model.CreateBy = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            model.UserId = User.FindFirst(ClaimTypes.PrimarySid).Value;
            var result = await _informationService.CreateUserReportComment(model);
            return Json(result);
        }

        [Authorize(Roles = $"{Role.Manager},{Role.Author},{Role.Admin}")]
        [Route("GetListUserReportComment")]
        [HttpGet]
        public async Task<IActionResult> GetListUserReportComment(int userReportId)
        {
            var result = await _informationService.GetListUserReportComment(userReportId);
            return Json(result.DataList);
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Author},{Role.Manager}")]
        [Route("UserReportDetail/{id}")]
        public async Task<IActionResult> UserReportDetail(int id)
        {
            var result = await _informationService.UserReport(id);
            return Json(result);
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

        [Authorize(Roles = $"{Role.Manager},{Role.Admin}")]
        [Route("Notificate/{id}")]
        public async Task<IActionResult> Notificate(int id)
        {
            var res = await _informationService.NotificationDetail(id);
            return Json(res.Data);
        }


        [Authorize(Roles = $"{Role.Admin},{Role.Author}")]
        [Route("KnowledgeDetail/{id}")]
        public async Task<IActionResult> KnowledgeDetail(int id)
        {
            var res = await _informationService.KnowledgeDetail(id);
            return View(res.Data);
        }

        [Authorize(Roles = $"{Role.Manager},{Role.Admin}")]
        [Route("Knowledge/{id}")]
        public async Task<IActionResult> Knowledge(int id)
        {
            var res = await _informationService.KnowledgeDetail(id);
            return Json(res.Data);
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Manager}")]
        [Route("ListNotifications")]
        public async Task<IActionResult> ListNotifications()
        {
            var result = await _informationService.ListNotification();
            ViewBag.Notifications = result.DataList;
            return View();
        }

        [Authorize(Roles = $"{Role.Manager},{Role.Admin}")]
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
        [Authorize(Roles = $"{Role.Manager},{Role.Admin}")]
        [Route("UpdateBasicKnowledge")]
        public async Task<IActionResult> UpdateBasicKnowledge(BasicKnowledge model)
        {
            var result = await _informationService.UpdateBasicKnowledge(model);
            if (result.IsSussess)
            {
                _notyf.Success(result.Message);
                return Redirect($"/Information/ListBasicKnowledge?category={model.Category}");
            }
            else
            {
                _notyf.Error(result.Message);
                return View(model);
            }

        }

        [Authorize(Roles = $"{Role.Manager},{Role.Admin}")]
        [Route("DeleteBasicKnowledge")]
        public async Task<IActionResult> DeleteBasicKnowledge(int id)
        {
            var result = await _informationService.DeleteBasicKnowledge(id);
            return Json(result);
        }


        [Authorize(Roles = $"{Role.Manager},{Role.Author},{Role.Admin}")]
        [Route("SendMessage")]
        [HttpPost]
        public async Task<IActionResult> SendMessage(Messenger messenger)
        {
            messenger.CreateBy = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result = await _informationService.SendMessage(messenger);
            return View(result);
        }

        [Authorize(Roles = $"{Role.Manager},{Role.Admin}")]
        [Route("ListChat")]
        public async Task<IActionResult> ListChat()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result = await _informationService.GetRoomByManager(username, "-1");
            ViewBag.FirstRoom = result.DataList.First().RoomName;
            ViewBag.FirstAuthorFullName = result.DataList.First().AuthorFullName;
            return View(result.DataList);
        }

        [Authorize(Roles = $"{Role.Manager},{Role.Admin}")]
        [Route("GetListMessage")]
        public async Task<IActionResult> GetListMessage(string roomName)
        {
            var result = await _informationService.GetListMessageByRoom(roomName);
            return Json(result.Data);
        }

        [Authorize(Roles = $"{Role.Manager},{Role.Author},{Role.Admin}")]
        [Route("Statistics")]
        public async Task<IActionResult> Statistics()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result = await _informationService.StatisticBook(username);
            ViewBag.Statistics = result.DataList;
            ViewBag.SumRevenue = result.DataList.Sum(c => c.Revenue);
            return View();
        }


        [Authorize(Roles = $"{Role.Author},{Role.Admin}")]
        [Route("GetRoomChat")]
        public async Task<IActionResult> GetRoomChat()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result = await _informationService.GetRoomByAuthor(username, "-1");
            return Json(result.Data);
        }
    }
}
