using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessObject;
using BusinessObject.BaseModel;
using LBSWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Repositories;
using System.Diagnostics;
using System.Security.Claims;

namespace LBSWeb.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly INotyfService _notyf;
        private readonly IConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger, INotyfService notyf, IConfiguration configuration)
		{
			_logger = logger;
			_notyf = notyf;
			_configuration = configuration;
		}


        public async Task<IActionResult> Index()
		{
            return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
