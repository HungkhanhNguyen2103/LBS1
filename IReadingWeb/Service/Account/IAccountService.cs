using BusinessObject.BaseModel;

namespace LBSWeb.Services.Account
{
    public interface IAccountService
    {
        Task<ReponderModel<string>> Register(AccountModel model);
        Task<ReponderModel<string>> Login(AccountModel model);
        Task<ReponderModel<AccountViewModel>> GetAll(string role);
        Task<ReponderModel<string>> GrantAccessRole(AccountModel model);
        Task<ReponderModel<string>> ForgotPassword(AccountModel model);
        Task<ReponderModel<string>> ChangePassword(AccountModel accountModel);
        Task<ReponderModel<string>> ReConfirmEmail(string username);
        Task<ReponderModel<string>> ToggleLockUser(string username, bool lockAccount);
        Task<ReponderModel<string>> ConfirmEmail(string token);
        Task<ReponderModel<AccountModel>> GetInformation(string username);
        Task<ReponderModel<string>> UpdateInformation(AccountModel account);
        Task<ReponderModel<string>> LoginWithGoogle(string email,string fullname);
        Task<ReponderModel<AccountModel>> GetListAccount(string role);
        Task<ReponderModel<string>> UpdateBankAccount(BankModel bank);
        Task<ReponderModel<BankModel>> GetBankAccount(string userId);
    }
}
