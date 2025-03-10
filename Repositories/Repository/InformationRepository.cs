using BusinessObject.BaseModel;
using BusinessObject;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Reflection.Metadata;

namespace Repositories.Repository
{
    public class InformationRepository : IInformationRepository
    {
        private readonly LBSDbContext _lBSDbContext;
        private readonly LBSMongoDBContext _mongoContext;
        public InformationRepository(LBSDbContext lBSDbContext, LBSMongoDBContext mongoContext)
        {
            _lBSDbContext = lBSDbContext;
            _mongoContext = mongoContext;
        }
        public async Task<ReponderModel<BasicKnowledge>> BasicKnowledge(string search)
        {
            var result = new ReponderModel<BasicKnowledge>();
            var iquery = _lBSDbContext.BasicKnowledges.AsQueryable();
            if (!string.IsNullOrEmpty(search)) iquery = iquery.Where(c => c.Title.Contains(search));
            result.DataList = await iquery.ToListAsync();
            result.IsSussess = true;
            return result;
        }

        public async Task<ReponderModel<Conspectus>> ConspectusDetail(int id)
        {
            var result = new ReponderModel<Conspectus>();
            var data = await _lBSDbContext.Conspectuses.FirstOrDefaultAsync(c => c.Id == id);
            if (data == null)
            {
                result.Message = "Data không hợp lệ";
                return result;
            }
            result.Data = data;
            result.IsSussess = true;
            return result;
        }

        public async Task<ReponderModel<string>> CreateUserReport(UserReport userReport)
        {
            var result = new ReponderModel<string>();
            if (string.IsNullOrEmpty(userReport.Title))
            {
                result.Message = "Tiêu đề không được để trống";
                return result;
            }
            if (string.IsNullOrEmpty(userReport.Content))
            {
                result.Message = "Nội dung không được để trống";
                return result;
            }
            _lBSDbContext.UserReports.Add(userReport);
            await _lBSDbContext.SaveChangesAsync();
            result.IsSussess = true;
            result.Message = "Tạo thành công";
            return result;
        }

        public async Task<ReponderModel<string>> DeleteConspectus(int id)
        {
            var result = new ReponderModel<string>();
            var data = await _lBSDbContext.Conspectuses.FirstOrDefaultAsync(c => c.Id == id);
            if (data == null)
            {
                result.Message = "Data không hợp lệ";
                return result;
            }
            _lBSDbContext.Conspectuses.Remove(data);
            await _lBSDbContext.SaveChangesAsync();
            result.Message = "Xóa thành công";
            result.IsSussess = true;
            return result;
        }

        public async Task<ReponderModel<BasicKnowledge>> KnowledgeDetail(int id)
        {
            var result = new ReponderModel<BasicKnowledge>();
            var data = await _lBSDbContext.BasicKnowledges.FirstOrDefaultAsync(c => c.Id == id);
            if(data == null)
            {
                result.Message = "Data không hợp lệ";
                return result;
            }
            result.Data = data;
            return result;
        }

        public async Task<ReponderModel<Conspectus>> ListConspectus(string username)
        {
            var result = new ReponderModel<Conspectus>();
            result.DataList = await _lBSDbContext.Conspectuses.Where(c => c.CreateBy == username).OrderByDescending(c => c.ModifyDate).ToListAsync();
            result.IsSussess = true;
            return result;
        }

        public async Task<ReponderModel<Notification>> ListNotification()
        {
            var result = new ReponderModel<Notification>();
            result.DataList = await _lBSDbContext.Notifications.ToListAsync();
            result.IsSussess = true;
            return result;
        }

        public async Task<ReponderModel<UserReport>> ListUserReport(string username, UserReportType userType)
        {
            var result = new ReponderModel<UserReport>();
            if (userType == UserReportType.Author)
            {
                result.DataList = await _lBSDbContext.UserReports.Where(c => c.CreateBy == username && c.ReportType == userType).ToListAsync();
            }
            else if (userType == UserReportType.User) 
            {
                result.DataList = await _lBSDbContext.UserReports.Where(c => c.Author == username && c.ReportType == userType).ToListAsync();
            }
            result.IsSussess = true;
            return result;
        }

        public async Task<ReponderModel<Notification>> NotificationDetail(int id)
        {
            var result = new ReponderModel<Notification>();
            var data = await _lBSDbContext.Notifications.FirstOrDefaultAsync(c => c.Id == id);
            if(data == null)
            {
                result.Message = "Data không tồn tại";
                return result;
            }
            result.Data = data;
            result.IsSussess = true;
            return result;
        }

        public async Task<ReponderModel<string>> UpdateConspectus(Conspectus model)
        {
            var result = new ReponderModel<string>();

            if (string.IsNullOrEmpty(model.Name))
            {
                result.Message = "Tên không được để trống";
                return result;
            }

            if (string.IsNullOrEmpty(model.Content)) 
            {
                result.Message = "Nội dung không được để trống";
                return result;
            }
            var data = await _lBSDbContext.Conspectuses.FirstOrDefaultAsync(c => c.Id == model.Id);

            if (data == null)
            {
                model.ModifyDate = DateTime.Now;
                _lBSDbContext.Conspectuses.Add(model);
            }
            else
            {
                data.Name = model.Name;
                data.Content = model.Content;
                //data.BookId = model.BookId;
                data.CreateBy = model.CreateBy;
                data.UserId = model.UserId;
                data.ModifyDate = DateTime.Now;
            }
            try
            {
                await _lBSDbContext.SaveChangesAsync();
                result.Message = "Cập nhật thành công";
                result.IsSussess = true;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
