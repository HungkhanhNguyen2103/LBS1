using BusinessObject;
using BusinessObject.BaseModel;
using LBSWeb.API;
using LBSWeb.Common;
using Newtonsoft.Json.Linq;
using System.Data;
using static OpenAI.ObjectModels.StaticValues.AssistantsStatics.MessageStatics;

namespace LBSWeb.Services.Account
{
    public class AccountService : IAccountService
    {
        public static WebAPICaller _api;
        //private IHttpClientFactory _factory;
        private readonly IHttpContextAccessor _context;
        public AccountService(WebAPICaller api, IHttpContextAccessor context)
        {
            _api = api;
            //_factory = factory;
            _context = context;
        }

        public async Task<ReponderModel<string>> Register(AccountModel model)
        {
            var res = new ReponderModel<string>();
            if(model == null)
            {
				res.Message = "Thông tin không hợp lệ!";
                return res;
			}
            if(model.Password != model.PasswordConfirm)
            {
                res.Message = "Mật khẩu nhập lại không khớp!";
                return res;
            }
            try
            {
                model.RegisterType = 1;
                string url = PathUrl.ACCOUNT_REGISTER;
                res = await _api.Post<ReponderModel<string>>(url, model);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;

        }

        public async Task<ReponderModel<string>> Login(AccountModel model)
        {
            var res = new ReponderModel<string>();
            if (model == null)
            {
                res.Message = "Thông tin không hợp lệ!";
                return res;
            }
            try
            {
                model.RegisterType = 1;
                string url = PathUrl.ACCOUNT_LOGIN;
                res = await _api.Post<ReponderModel<string>>(url, model);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;

        }

        public async Task<ReponderModel<AccountViewModel>> GetAll(string role)
        {
            var res = new ReponderModel<AccountViewModel>();
            try
            {
                string url = PathUrl.ACCOUNT_GETALL;
                var param = new Dictionary<string, string>();
                param.Add("role", role);
                res = await _api.Get<ReponderModel<AccountViewModel>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> ConfirmEmail(string token)
        {
            var res = new ReponderModel<string>();
            try
            {
                var emailConfirm = new EmailConfirm
                {
                    Token = token
                };
                string url = PathUrl.ACCOUNT_CONFIRMEMAIL;
                res = await _api.Post<ReponderModel<string>>(url, emailConfirm);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<AccountModel>> GetInformation(string username)
        {
            var res = new ReponderModel<AccountModel>();
            try
            {
                string url = PathUrl.ACCOUNT_GET_INFO;
                var param = new Dictionary<string, string>();
                param.Add("username", username);
                res = await _api.Get<ReponderModel<AccountModel>>(url,param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> UpdateInformation(AccountModel account)
        {
            var res = new ReponderModel<string>();
            try
            {
                account.RegisterType = 1;
                string url = PathUrl.ACCOUNT_UPDATE_INFO;
                res = await _api.Post<ReponderModel<string>>(url, account);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> ToggleLockUser(string username, bool lockAccount)
        {
            var res = new ReponderModel<string>();
            try
            {
                string url = PathUrl.ACCOUNT_TOGGLE_LOCK_USER;
                var param = new Dictionary<string, string>();
                param.Add("username", username);
                param.Add("lockAccount", lockAccount.ToString());
                res = await _api.Get<ReponderModel<string>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> GrantAccessRole(AccountModel model)
        {
            var res = new ReponderModel<string>();
            try
            {
                model.RegisterType = 1;
                string url = PathUrl.ACCOUNT_ACCESS_ROLE;
                res = await _api.Post<ReponderModel<string>>(url, model);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> ForgotPassword(AccountModel model)
        {
            var res = new ReponderModel<string>();
            try
            {
                model.RegisterType = 1;
                string url = PathUrl.ACCOUNT_FORGOT_PASSWORD;
                res = await _api.Post<ReponderModel<string>>(url, model);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> ChangePassword(AccountModel accountModel)
        {
            var res = new ReponderModel<string>();
            if (accountModel == null)
            {
                res.Message = "Thông tin không hợp lệ!";
                return res;
            }
            try
            {
                accountModel.RegisterType = 1;
                string url = PathUrl.ACCOUNT_CHANGE_PASSWORD;
                res = await _api.Post<ReponderModel<string>>(url, accountModel);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> ReConfirmEmail(string username)
        {
            var res = new ReponderModel<string>();
            try
            {
                var model = new AccountModel
                {
                    UserName = username
                };
                string url = PathUrl.ACCOUNT_RE_CONFIRM_EMAIL;
                res = await _api.Post<ReponderModel<string>>(url, model);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> LoginWithGoogle(string email, string fullname)
        {
            var res = new ReponderModel<string>();
            var model = new AccountModel
            {
                Email = email,
                FullName = fullname,
                RegisterType = 1
            };
            if (model == null)
            {
                res.Message = "Thông tin không hợp lệ!";
                return res;
            }
            try
            {
                string url = PathUrl.ACCOUNT_LOGIN_WITH_GOOGLE;
                res = await _api.Post<ReponderModel<string>>(url, model);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<AccountModel>> GetListAccount(string role)
        {
            var res = new ReponderModel<AccountModel>();
            try
            {
                string url = PathUrl.ACCOUNT_GET_LIST;
                var param = new Dictionary<string, string>();
                param.Add("role", role);
                res = await _api.Get<ReponderModel<AccountModel>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> UpdateBankAccount(BankModel model)
        {
            var res = new ReponderModel<string>();
            if (model == null)
            {
                res.Message = "Thông tin không hợp lệ!";
                return res;
            }
            try
            {
                string url = PathUrl.ACCOUNT_UPDATE_BANK;
                res = await _api.Post<ReponderModel<string>>(url, model);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<BankModel>> GetBankAccount(string userId)
        {
            var res = new ReponderModel<BankModel>();
            try
            {
                string url = PathUrl.ACCOUNT_GET_BANK;
                var param = new Dictionary<string, string>();
                param.Add("userId", userId);
                res = await _api.Get<ReponderModel<BankModel>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }
    }
}
