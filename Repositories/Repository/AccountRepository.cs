using BusinessObject;
using BusinessObject.BaseModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<Account> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly LBSDbContext LBSDbContext;
		private readonly IConfiguration _configuration;
        private EmailSender _emailSender;
        public AccountRepository(LBSDbContext lbSDbContext,
            UserManager<Account> userManager, 
            RoleManager<IdentityRole> roleManager,
			IConfiguration configuration,
            EmailSender emailSender
            )
        {
            LBSDbContext = lbSDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
			_configuration = configuration;
            _emailSender = emailSender;
        }

        public async Task<ReponderModel<string>> ConfirmEmail(string? token)
        {
            var response = new ReponderModel<string>();
            var key = _configuration["Tokens:Key"];
            var issuer = _configuration["Tokens:Issuer"];
            if (string.IsNullOrEmpty(token)) {
                response.Message = "Xác thực không hợp lệ";
                return response;
            }
            var claims = TokenUtil.ValidateToken(token, key, issuer);
            if (claims == null) {
                response.Message = "Xác thực không hợp lệ";
                return response;
            }
            var curUser = claims.FindFirst(ClaimTypes.NameIdentifier);
            if(curUser == null)
            {
                response.Message = "Xác thực không hợp lệ";
                return response;
            }
            var user = await _userManager.FindByNameAsync(curUser.Value);
            if (user == null)
            {
                response.Message = "Tài khoản không tồn tại";
                return response;
            }
            user.EmailConfirmed = true;
            await _userManager.UpdateAsync(user);

            response.Message = "Xác thực thành công";
            response.IsSussess = true;
            //response.Data = token;
            return response;
        }

        public async Task<ReponderModel<AccountViewModel>> GetAll(string role)
        {
            var response = new ReponderModel<AccountViewModel>();
            string sql = $@"select acc.* from AspNetUserRoles as ur 
                inner join AspNetRoles as rs on ur.RoleId = rs.Id
                inner join Account as acc on ur.UserId = acc.Id
                where rs.Name = '{role}'";
            var result = await LBSDbContext.Users.FromSqlRaw<Account>(sql).ToListAsync();
            response.DataList = result.Select(c => new AccountViewModel
            {
                Email = c.Email,
                FullName = c.FullName,
                UserName = c.UserName,
                PhoneNumber = c.PhoneNumber,
                AccountActive = c.AccountActive,
                Status = !c.AccountActive ? "Đang khóa" : c.EmailConfirmed ? "Đang hoạt động" : !c.EmailConfirmed ? "Chưa xác thực" : "Không hoạt động",
            }).ToList();
            response.IsSussess = true;
            return response;
        }

        public async Task<ReponderModel<AccountModel>> GetInformation(string username)
        {
            var response = new ReponderModel<AccountModel>();
            var user = await _userManager.FindByNameAsync(username);
            if (user == null) {
                response.Message = "Tài khoản không tồn tại";
                return response;
            }
            var userInfo = new AccountModel
            {
                UserName = username,
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
            response.IsSussess = true;
            response.Data = userInfo;
            response.Message = "Lấy dữ liệu thành công";
            return response;
        }

        public async Task<ReponderModel<string>> ToggleLockUser(string username,bool lockAccount)
        {
            var responder = new ReponderModel<string>();
            var userExist = await _userManager.FindByNameAsync(username);
            if (userExist == null)
            {
                responder.Message = "Tài khoản không tồn tại";
                return responder;
            }
            userExist.AccountActive = !lockAccount;
            await LBSDbContext.SaveChangesAsync();
            responder.IsSussess = true;
            responder.Message = lockAccount ? "Khóa thành công" : "Mở khóa thành công";
            return responder;
        }

        public async Task<ReponderModel<string>> Login(AccountModel account)
        {
            var responder = new ReponderModel<string>();
            var userExists = await _userManager.FindByNameAsync(account.UserName);
            if (userExists == null)
            {
                responder.Message = "Tài khoản không tồn tại";
                return responder;
            }
            var isCheck = await _userManager.CheckPasswordAsync(userExists, account.Password);
            if (!isCheck)
            {
                responder.Message = "Mật khẩu không chính xác";
                return responder;
            }

            if (!userExists.AccountActive)
            {
                responder.Message = "Tài khoản đang bị khóa. Vui lòng báo với admin";
                return responder;
            }
            var roles = await _userManager.GetRolesAsync(userExists);
            responder.Message = "Đăng nhập thành công";
            responder.IsSussess = true;
            responder.Data = await EncodeSha256(userExists, string.Join(", ", roles),userExists.EmailConfirmed,userExists.ResetPassword);
            return responder;
        }

        public async Task<ReponderModel<string>> Register(AccountModel account)
        {
            var responder = new ReponderModel<string>();

            var userExists = await _userManager.FindByNameAsync(account.UserName);
            if (userExists != null)
            {
                responder.Message = "Tài khoản đã tồn tại";
                return responder;
            }

            var emailExist = await _userManager.FindByEmailAsync(account.Email);
            if (emailExist != null)
            {
                responder.Message = "Email đã được sử dụng";
                return responder;
            }

            if (!account.PhoneNumber.StartsWith("0"))
            {
                responder.Message = "Số điện thoại phải bắt đầu từ số 0";
                return responder;
            }

            if (!long.TryParse(account.PhoneNumber,out long phoneNumber) || account.PhoneNumber.Length != 10)
            {
                responder.Message = "Số điện thoại không đúng định dạng (10 chữ số)";
                return responder;
            }

            var user = new Account
            {
                Email = account.Email,
                UserName = account.UserName,
                Address = account.Address,
                FullName = account.FullName,
                PhoneNumber = account.PhoneNumber,
                AccountActive = true,
                SocialAccount = false,
                ResetPassword = 0,
            };
            var result = await _userManager.CreateAsync(user, account.Password);
            if (!result.Succeeded)
            {
                //if (result.Errors.Count() != 0) responder.Message = result.Errors.First().Description;
                if (result.Errors.Count() != 0) responder.Message = "Mật khẩu phải chứa số, chữ thường,chữ hoa và kí tự đặc biệt";
                else responder.Message = "Tài khoản tạo không thành công";
                return responder;
            }
            try
            {
				await _userManager.AddToRoleAsync(user, Role.User);
                responder.Data = await EncodeSha256(user, Role.User,true,user.ResetPassword);


                //Send Email 
                var template = await LBSDbContext.TemplateEmails.FirstOrDefaultAsync(c => c.Name == "EmailConfirm");
                if(template == null)
                {
                    responder.Message = "Không có dữ liệu giao diện";
                    return responder;
                }
                var webPageUrl = Environment.GetEnvironmentVariable("WEBPAGE_URL");
                template.Body = !string.IsNullOrEmpty(template.Body) ? template.Body.Replace("$${EmailConfirmLink}", webPageUrl + "/Account/ConfirmSuccess?token=" + responder.Data) : string.Empty;
                var emailModel = new EmailModel
                {
                    Body = template.Body,
                    Subject = template.Subject,
                    To = new List<string>() { account.Email }
                };
                var rs = await _emailSender.SendEmailAsync(emailModel);
                if (!rs)
                {
                    responder.Message = "Lỗi gửi mail";
                    return responder;
                }
                responder.Message = "Tạo tài khoản thành công";
                responder.IsSussess = true;
                return responder;
            }
            catch (Exception ex)
            {
                responder.Message = ex.Message;

			}
			return responder;
		}
        
        public async Task<ReponderModel<string>> UpdateInformation(AccountModel account)
        {
            var responder = new ReponderModel<string>();
            if (account == null)
            {
                responder.Message = "Data không hợp lệ";
                return responder;
            }
            if (!long.TryParse(account.PhoneNumber, out long phoneNumber))
            {
                responder.Message = "Số điện thoại không đúng định dạng";
                return responder;
            }
            var userExist = await _userManager.FindByNameAsync(account.UserName);
            if (userExist == null)
            {
                responder.Message = "Tài khoản không tồn tại";
                return responder;
            }
            userExist.PhoneNumber = account.PhoneNumber;
            userExist.FullName = account.FullName;
            await _userManager.UpdateAsync(userExist);

            responder.IsSussess = true;
            responder.Message = "Cập nhật thành công";
            var roles = await _userManager.GetRolesAsync(userExist);
            responder.Data = await EncodeSha256(userExist, string.Join(", ", roles), userExist.EmailConfirmed);
            return responder;
        }

        private async Task<string> EncodeSha256(Account user, string role,bool emailConfirm = true,int resetPassword = 0)
		{
			string token = string.Empty;
			var key = _configuration["Tokens:Key"];
			var issuer = _configuration["Tokens:Issuer"];
			var expires = _configuration["Tokens:Expires"];

		
			var arr = expires.Split('*');
			double seconds = 1;
			foreach (var item in arr)
			{
				seconds *= Int32.Parse(item.ToString());
			}

			List<Claim> claims = new List<Claim>();
			claims.Add(new Claim(ClaimTypes.NameIdentifier, user.UserName));
			claims.Add(new Claim(ClaimTypes.Role, role == null ? "" : role));
			claims.Add(new Claim(ClaimTypes.Name, user.FullName));
			claims.Add(new Claim("EmailConfirm", emailConfirm.ToString()));
			claims.Add(new Claim("ResetPassword", resetPassword.ToString()));
			claims.Add(new Claim(ClaimTypes.Email, user.Email));
			claims.Add(new Claim(ClaimTypes.MobilePhone, !string.IsNullOrEmpty(user.PhoneNumber) ? user.PhoneNumber : string.Empty));

			token = TokenUtil.EncodeSha256(claims, key, issuer, seconds);

			return await Task.FromResult(token);
		}

        public async Task<ReponderModel<string>> GrantAccessRole(string username,int grade)
        {
            var responder = new ReponderModel<string>();
            var userExist = await _userManager.FindByNameAsync(username);
            if (userExist == null)
            {
                responder.Message = "Tài khoản không tồn tại";
                return responder;
            }
            if(grade == 1)
            {
                await _userManager.AddToRoleAsync(userExist, Role.Staff);
                await _userManager.RemoveFromRoleAsync(userExist, Role.User);
            }
            else
            {
                await _userManager.AddToRoleAsync(userExist, Role.User);
                await _userManager.RemoveFromRoleAsync(userExist, Role.Staff);
            }

            responder.IsSussess = true;
            responder.Message = "Thành công";
            return responder;
        }

        public async Task<ReponderModel<string>> ForgotPassword(string email)
        {
            var responder = new ReponderModel<string>();
            var userExist = await _userManager.FindByEmailAsync(email);
            if (userExist == null)
            {
                responder.Message = "Email không tồn tại";
                return responder;
            }
            //Send Email 
            var template = await LBSDbContext.TemplateEmails.FirstOrDefaultAsync(c => c.Name == "ForgotPassword");
            if (template == null)
            {
                responder.Message = "Không có dữ liệu giao diện";
                return responder;
            }
            var webPageUrl = Environment.GetEnvironmentVariable("WEBPAGE_URL");
            var newPassword = CreateRandomPassword(10);
            var body = !string.IsNullOrEmpty(template.Body) ? template.Body.Replace("$${NewPassWord}", newPassword) : string.Empty;
            var emailModel = new EmailModel
            {
                Body = body,
                Subject = template.Subject,
                To = new List<string>() { email }
            };

            userExist.ResetPassword = 1;

            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(userExist);
            var passwordChangeResult = await _userManager.ResetPasswordAsync(userExist, resetToken, newPassword);
            if (!passwordChangeResult.Succeeded)
            {
                if (passwordChangeResult.Errors.Count() != 0) responder.Message = passwordChangeResult.Errors.First().Description;
                else responder.Message = "Lỗi máy chủ";
                return responder;
            }
            var rs = await _emailSender.SendEmailAsync(emailModel);
            if (!rs)
            {
                responder.Message = "Lỗi gửi mail";
                return responder;
            }
            await _userManager.UpdateAsync(userExist);
            responder.IsSussess = true;
            return responder;
        }

        private string CreateRandomPassword(int length = 15)
        {
            string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lower = "abcdefghijklmnopqrstuvwxyz";
            string character = "!-_*+&$";
            string number = "0123456789";
            Random _rnd = new Random();
            string[] keys = new string[] { upper, lower, character, number };
            var chars = new char[length];
            for (int i = 0; i < keys.Length; i++)
            {
                var key = keys[i];
                chars[i] = key[_rnd.Next(key.Length)];
            }

            for (int i = keys.Length; i < length; i++)
            {
                var indexKeys = _rnd.Next(keys.Length);
                var key = keys[indexKeys];
                chars[i] = key[_rnd.Next(key.Length)];
            }

            return new string(chars.OrderBy(x => Guid.NewGuid()).ToArray());

            //string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            //Random random = new Random();

            //char[] chars = new char[length];
            //for (int i = 0; i < length; i++)
            //{
            //    chars[i] = validChars[random.Next(0, validChars.Length)];
            //}
            //return new string(chars);
        }

        public async Task<ReponderModel<string>> ChangePassword(AccountModel accountModel)
        {
            var responder = new ReponderModel<string>();
            if (accountModel == null || 
                string.IsNullOrEmpty(accountModel.UserName)
                || string.IsNullOrEmpty(accountModel.OldPassword)
                || string.IsNullOrEmpty(accountModel.Password)
                || string.IsNullOrEmpty(accountModel.PasswordConfirm))
            {
                responder.Message = "Dữ liệu không hợp lệ";
                return responder;
            }
            var userExist = await _userManager.FindByNameAsync(accountModel.UserName);
            if (userExist == null)
            {
                responder.Message = "Tài khoản không tồn tại";
                return responder;
            }
            var checkPassword = await _userManager.CheckPasswordAsync(userExist, accountModel.OldPassword);
            if (!checkPassword)
            {
                responder.Message = "Mật khẩu cũ không chính xác";
                return responder;
            }
            if(accountModel.Password != accountModel.PasswordConfirm)
            {
                responder.Message = "Mật khẩu mới không khớp";
                return responder;
            }
            if (accountModel.Password == accountModel.OldPassword)
            {
                responder.Message = "Mật khẩu mới đã được sử dụng trước đó";
                return responder;
            }
            var result = await _userManager.ChangePasswordAsync(userExist, accountModel.OldPassword, accountModel.Password);
            if (!result.Succeeded)
            {
                //if (result.Errors.Count() != 0) responder.Message = result.Errors.First().Description;
                if (result.Errors.Count() != 0) responder.Message = "Mật khẩu phải chứa số, chữ thường,chữ hoa và kí tự đặc biệt";
                else responder.Message = "Tài khoản tạo không thành công";
                return responder;
            }
            userExist.ResetPassword = 0;
            await _userManager.UpdateAsync(userExist);
            responder.Message = "Thay đổi thành công";
            responder.IsSussess = true;
            return responder;
        }

        public async Task<ReponderModel<string>> ReConfirmEmail(string username)
        {
            var responder = new ReponderModel<string>();
            var userExist = await _userManager.FindByNameAsync(username);
            if (userExist == null)
            {
                responder.Message = "Tài khoản không tồn tại";
                return responder;
            }
            var roles = await _userManager.GetRolesAsync(userExist);
            var token = await EncodeSha256(userExist, string.Join(", ", roles), true, userExist.ResetPassword);
            //Send Email 
            var template = await LBSDbContext.TemplateEmails.FirstOrDefaultAsync(c => c.Name == "EmailConfirm");
            if (template == null)
            {
                responder.Message = "Không có dữ liệu giao diện";
                return responder;
            }
            var webPageUrl = Environment.GetEnvironmentVariable("WEBPAGE_URL");
            template.Body = !string.IsNullOrEmpty(template.Body) ? template.Body.Replace("$${EmailConfirmLink}", webPageUrl + "/Account/ConfirmSuccess?token=" + token) : string.Empty;
            var emailModel = new EmailModel
            {
                Body = template.Body,
                Subject = template.Subject,
                To = new List<string>() { userExist.Email }
            };
            var rs = await _emailSender.SendEmailAsync(emailModel);
            if (!rs)
            {
                responder.Message = "Lỗi gửi mail";
                return responder;
            }
            responder.Message = "Gửi email thành công";
            //responder.Data = token;
            responder.IsSussess = true;
            return responder;
        }

        public async Task<ReponderModel<string>> LoginWithGoogle(string email,string fullname)
        {
            var responder = new ReponderModel<string>();
            var userExist = await _userManager.FindByEmailAsync(email);
            if (userExist == null) 
            {
                var user = new Account
                {
                    Email = email,
                    UserName = email,
                    FullName = fullname,
                    AccountActive = true,
                    SocialAccount = true,
                    EmailConfirmed = false,
                    ResetPassword = 0
                };
                var pw = CreateRandomPassword();
                var result = await _userManager.CreateAsync(user, pw);
                try
                {
                    await _userManager.AddToRoleAsync(user, Role.User);
                    responder.Data = await EncodeSha256(user, Role.User, true, user.ResetPassword);


                    //Send Email 
                    var template = await LBSDbContext.TemplateEmails.FirstOrDefaultAsync(c => c.Name == "EmailConfirm");
                    if (template == null)
                    {
                        responder.Message = "Không có dữ liệu giao diện";
                        return responder;
                    }
                    var webPageUrl = Environment.GetEnvironmentVariable("WEBPAGE_URL");
                    template.Body = !string.IsNullOrEmpty(template.Body) ? template.Body.Replace("$${EmailConfirmLink}", webPageUrl + "/Account/ConfirmSuccess?token=" + responder.Data) : string.Empty;
                    var emailModel = new EmailModel
                    {
                        Body = template.Body,
                        Subject = template.Subject,
                        To = new List<string>() { email }
                    };
                    var rs = await _emailSender.SendEmailAsync(emailModel);
                    if (!rs)
                    {
                        responder.Message = "Lỗi gửi mail";
                        return responder;
                    }
                    responder.Message = "Đăng nhập thành công";
                    responder.IsSussess = true;
                    return responder;
                }
                catch (Exception ex)
                {
                    responder.Message = ex.Message;
                    return responder;
                }
            }

            if (!userExist.AccountActive)
            {
                responder.Message = "Tài khoản đang bị khóa. Vui lòng báo với admin";
                return responder;
            }
            var roles = await _userManager.GetRolesAsync(userExist);
            responder.Message = "Đăng nhập thành công";
            responder.IsSussess = true;
            responder.Data = await EncodeSha256(userExist, string.Join(", ", roles), userExist.EmailConfirmed, userExist.ResetPassword);

            return responder;
        }
    }


}
