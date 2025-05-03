using BusinessObject.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public interface IAccountRepository
    {
        Task<ReponderModel<string>> Register(AccountModel account);
        Task<ReponderModel<AccountModel>> GetListAccount(string role);
        Task<ReponderModel<string>> Login(AccountModel account);
        Task<ReponderModel<AccountViewModel>> GetAll(string role);
        Task<ReponderModel<string>> ToggleLockUser(string username,bool lockAccount);
        Task<ReponderModel<string>> GrantAccessRole(string username, int grant);
        Task<ReponderModel<string>> ForgotPassword(string email);
        Task<ReponderModel<string>> ChangePassword(AccountModel accountModel);
        Task<ReponderModel<string>> ConfirmEmail(string? token);
        Task<ReponderModel<string>> ReConfirmEmail(string? username);

        Task<ReponderModel<AccountModel>> GetInformation(string username);
        Task<ReponderModel<string>> UpdateInformation(AccountModel account);
        Task<ReponderModel<string>> LoginWithGoogle(string email,string fullname, int registerType);
        Task<ReponderModel<ReportModel>> ShortReport();
        Task<List<string>> GetRolesByUserName(string userName);
        Task<ReponderModel<bool>> CheckConfirmEmail(string userName);
        Task<ReponderModel<string>> UpdateBankAccount(BankModel bank);
        Task<ReponderModel<BankModel>> GetBankAccount(string userId);

    }
}
