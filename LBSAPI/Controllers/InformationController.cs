using BusinessObject;
using BusinessObject.BaseModel;
using Microsoft.AspNetCore.Mvc;
using Repositories.IRepository;

namespace LBSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationController
    {
        private readonly IInformationRepository _informationRepository;
        public InformationController(IInformationRepository informationRepository)
        {
            _informationRepository = informationRepository;
        }

        [Route("BasicKnowledge")]
        [HttpPost]
        public async Task<ReponderModel<BasicKnowledge>> BasicKnowledge(RequestModel model)
        {
            var result = await _informationRepository.BasicKnowledge(model.Data);
            return result;
        }

        [Route("ListNotification")]
        [HttpGet]
        public async Task<ReponderModel<Notification>> ListNotification()
        {
            var result = await _informationRepository.ListNotification();
            return result;
        }

        [Route("NotificationDetail")]
        [HttpGet]
        public async Task<ReponderModel<Notification>> NotificationDetail(int id)
        {
            var result = await _informationRepository.NotificationDetail(id);
            return result;
        }

        [Route("ConspectusDetail")]
        [HttpGet]
        public async Task<ReponderModel<Conspectus>> ConspectusDetail(int id)
        {
            var result = await _informationRepository.ConspectusDetail(id);
            return result;
        }

        [Route("ListConspectus")]
        [HttpGet]
        public async Task<ReponderModel<Conspectus>> ListConspectus(string username)
        {
            var result = await _informationRepository.ListConspectus(username);
            return result;
        }

        [Route("DeleteConspectus")]
        [HttpGet]
        public async Task<ReponderModel<string>> DeleteConspectus(int id)
        {
            var result = await _informationRepository.DeleteConspectus(id);
            return result;
        }

        [Route("UpdateConspectus")]
        [HttpPost]
        public async Task<ReponderModel<string>> UpdateConspectus(Conspectus model)
        {
            var result = await _informationRepository.UpdateConspectus(model);
            return result;
        }

        [Route("KnowledgeDetail")]
        [HttpGet]
        public async Task<ReponderModel<BasicKnowledge>> KnowledgeDetail(int id)
        {
            var result = await _informationRepository.KnowledgeDetail(id);
            return result;
        }

        [Route("ListUserReport")]
        [HttpGet]
        public async Task<ReponderModel<UserReport>> ListUserReport(string username, UserReportType userReport)
        {
            var result = await _informationRepository.ListUserReport(username,userReport);
            return result;
        }

        [Route("CreateUserReport")]
        [HttpPost]
        public async Task<ReponderModel<string>> CreateUserReport(UserReport userReport)
        {
            var result = await _informationRepository.CreateUserReport(userReport);
            return result;
        }
    }
}
