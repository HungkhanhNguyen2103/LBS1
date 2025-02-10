using BusinessObject;
using BusinessObject.BaseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LBSWeb.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles = $"{Role.Admin}")]
        public IActionResult Index()
        {
            //if (User.IsInRole("Staff"))
            //{
            //    return RedirectToAction("ListPost");
            //}
            var result = new ReportModel();
            return View(result);
        }
    }
}
