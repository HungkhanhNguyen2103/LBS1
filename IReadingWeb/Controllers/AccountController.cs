using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessObject;
using BusinessObject.BaseModel;
using LBSWeb.Services.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Repositories;
using System.Security.Claims;

namespace LBSWeb.Controllers
{
	public class AccountController : Controller
	{
        private readonly IConfiguration _configuration;
        private readonly IAccountService _accountService;
		private readonly INotyfService _notyf;
		public AccountController(IAccountService accountService, INotyfService notyf,IConfiguration configuration) 
        {
            _accountService = accountService;
			_notyf = notyf;
            _configuration = configuration;
        }

        [HttpPost]
		public async Task<IActionResult> Register(AccountModel account)
		{
            var res = await _accountService.Register(account);
			if(!res.IsSussess) _notyf.Error(res.Message);
			else
			{
                var claims = TokenUtil.ValidateToken(res.Data, _configuration["Tokens:Key"], _configuration["Tokens:Issuer"]);
                if (claims != null)
                {
                    //var isConfirmEmail = claims.FindFirst(ClaimTypes.Email).Value;
                    //if (isConfirmEmail == "False")
                    //{
                    //    return Redirect("/Account/EmailReConfirm");
                    //}
                    HttpContext.Response.Cookies.Append("token", res.Data, new CookieOptions { MaxAge = TimeSpan.FromDays(365 * 2) });
                    var claimsIdentity = new ClaimsIdentity(
                        claims.Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));
                    //return Redirect("/Admin");
                }
                return Redirect("/Account/EmailReConfirm");
                //HttpContext.Response.Cookies.Append("confirming", true.ToString());
                //return RedirectToAction("EmailConfirmSender");
            }
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangeAccount(AccountModel accountModel)
        {
            accountModel.UserName = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result = await _accountService.ChangePassword(accountModel);
            if (result.IsSussess)
            {
                _notyf.Success(result.Message);
                return RedirectToAction("Logout");
            }
            _notyf.Error(result.Message);
            return View();
        }

        [Authorize]
        public IActionResult ChangeAccount()
        {
            return View();
        }


        [Authorize]
        //[IgnoreAntiforgeryToken]
        public async Task<IActionResult> LoginWithGoogle()
        {
            var userClaims = User.Claims;
            var email = User.FindFirst(ClaimTypes.Email).Value;
            var fullname = User.FindFirst(ClaimTypes.Name).Value;
            var result = await _accountService.LoginWithGoogle(email, fullname);
            if (!result.IsSussess)
            {
                _notyf.Error(result.Message);
                return Redirect("/");
            }
            var claims = TokenUtil.ValidateToken(result.Data, _configuration["Tokens:Key"], _configuration["Tokens:Issuer"]);
            if (claims != null)
            {
                HttpContext.Response.Cookies.Append("token", result.Data, new CookieOptions { MaxAge = TimeSpan.FromDays(365 * 2) });
                var claimsIdentity = new ClaimsIdentity(
                    claims.Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));
                var isConfirmEmail = claims.FindFirst(ClaimTypes.Email).Value;
                if (isConfirmEmail == "False")
                {
                    return Redirect("/Account/EmailReConfirm");
                }
                return Redirect("/Admin/Index");

            }
            return Redirect("/Account/AccessDenied");
        }

        [Authorize]
        public async Task<IActionResult> AccountInformation()
        {
            var userName = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result = await _accountService.GetInformation(userName);
            if(!result.IsSussess) _notyf.Error(result.Message);
            return View(result.Data);
        }

        [Authorize]
        public async Task<IActionResult> BankInformation()
        {
            //var userName = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var result = await _accountService.GetInformation(userName);
            //if (!result.IsSussess) _notyf.Error(result.Message);
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdateInformation(AccountModel account)
        {
            var userName = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            account.UserName = userName;
            var result = await _accountService.UpdateInformation(account);
            if (!result.IsSussess)
            {
                _notyf.Error(result.Message);
                return RedirectToAction("AccountInformation");
            }
            _notyf.Success(result.Message);
            HttpContext.Response.Cookies.Append("token", result.Data, new CookieOptions { MaxAge = TimeSpan.FromMinutes(45) });
            return RedirectToAction("VerifyToken");
        }

        [AllowAnonymous]
        public async Task<IActionResult> ConfirmSuccess(string token)
        {
            var result = await _accountService.ConfirmEmail(token);
            if(!result.IsSussess)
            {
                _notyf.Error(result.Message);
                return Redirect("/");
            }
            var claims = TokenUtil.ValidateToken(token, _configuration["Tokens:Key"], _configuration["Tokens:Issuer"]);
            if (claims != null)
            {
                HttpContext.Response.Cookies.Append("token", token, new CookieOptions { MaxAge = TimeSpan.FromDays(365 * 2) });
                var claimsIdentity = new ClaimsIdentity(
                    claims.Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));
            }
            return View();
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [Authorize]
        public IActionResult EmailConfirm()
        {
            return View();
        }

        //[Authorize]
        public IActionResult EmailConfirmSender()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> EmailReConfirm()
        {
            //var userClaims = User.Claims;
            var userName = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var userName = User.FindFirst(ClaimTypes.Name).Value;
            var result = await _accountService.ReConfirmEmail(userName);
            if (!result.IsSussess)
            {
                _notyf.Error(result.Message);
            }
            //else _notyf.Error(result.Message);
            return RedirectToAction("EmailConfirmSender");
        }

        public IActionResult Register()
		{
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/Admin/Index");
            }
            return View();
		}

        public IActionResult ForgotPassword()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/Admin/Index");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(AccountModel model)
        {
            var res = await _accountService.ForgotPassword(model);
            if (!res.IsSussess) _notyf.Error(res.Message);
            else
            {
                return RedirectToAction("ForgotPasswordConfirm");
            }
            return View();
        }

        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirm()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/Admin/Index");
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(AccountModel account)
        {
            var res = await _accountService.Login(account);

            if (!res.IsSussess) _notyf.Error(res.Message);
            else
            {
                var claims = TokenUtil.ValidateToken(res.Data, _configuration["Tokens:Key"], _configuration["Tokens:Issuer"]);
                if (claims != null)
                {
                    HttpContext.Response.Cookies.Append("token", res.Data, new CookieOptions { MaxAge = TimeSpan.FromDays(365 * 2) });
                    var claimsIdentity = new ClaimsIdentity(
                        claims.Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));
                    var isConfirmEmail = claims.FindFirst(ClaimTypes.Email).Value;
                    if (isConfirmEmail == "False")
                    {
                        return Redirect("/Account/EmailReConfirm");
                    }

                    //return Redirect("/Admin");
                    
                }
                return Redirect("/Admin/Index");
            }
            return View(account);
        }

        public IActionResult Login(string ReturnUrl = "/")
		{
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/Admin/Index");
            }
			return View(new AccountModel { ReturnUrl = ReturnUrl});
		}

        [AllowAnonymous]
        public async Task<IActionResult> VerifyToken()
        {
            var token = HttpContext.Request.Cookies["token"];
            var claims = TokenUtil.ValidateToken(token, _configuration["Tokens:Key"], _configuration["Tokens:Issuer"]);
            if (claims != null)
            {
                var claimsIdentity = new ClaimsIdentity(
                    claims.Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));
                if (claims.IsInRole("Admin")) return Redirect("/Admin");
                //return Redirect("/");
            }
            return Redirect("/Admin/Index");
        }

        [AllowAnonymous]
        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("token");
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
