using BusinessObject;
using BusinessObject.BaseModel;
using LBSWeb.API;
using LBSWeb.Common;
using Microsoft.IdentityModel.Tokens;
using System.Net;

namespace LBSWeb.Service.Book
{
    public class BookService : IBookService
    {
        public static WebAPICaller _api;
        public BookService(WebAPICaller api) 
        { 
            _api = api;
        }

        public async Task<ReponderModel<string>> UpdateCategory(Category model)
        {
            var res = new ReponderModel<string>();
            if (model == null)
            {
                res.Message = "Thông tin không hợp lệ!";
                return res;
            }
            try
            {
                string url = PathUrl.CATEGORY_UPDATE;
                res = await _api.Post<ReponderModel<string>>(url, model);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public void GetBookImages()
        {
            throw new NotImplementedException();
        }

        public async Task<ReponderModel<Category>> GetCategories()
        {
            var res = new ReponderModel<Category>();
            try
            {
                string url = PathUrl.CATEGORY_GET_ALL;
                res = await _api.Get<ReponderModel<Category>>(url);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> DeleteCategory(int id)
        {
            var res = new ReponderModel<string>();
            try
            {
                string url = PathUrl.CATEGORY_DELETE;
                var param = new Dictionary<string, string>();
                param.Add("id", id.ToString());
                res = await _api.Get<ReponderModel<string>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> CreateBook(BookModel model)
        {
            var res = new ReponderModel<string>();
            if (model == null)
            {
                res.Message = "Thông tin không hợp lệ!";
                return res;
            }
            try
            {
                string url = PathUrl.BOOK_CREATE;
                res = await _api.Post<ReponderModel<string>>(url, model);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> UpdateBook(BookModel model)
        {
            var res = new ReponderModel<string>();
            if (model == null)
            {
                res.Message = "Thông tin không hợp lệ!";
                return res;
            }
            try
            {
                string url = PathUrl.BOOK_UPDATE;
                res = await _api.Post<ReponderModel<string>>(url, model);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<BookViewModel>> GetAllBookByUser(string userName)
        {
            var res = new ReponderModel<BookViewModel>();
            try
            {
                string url = PathUrl.BOOK_GET_BY_USER;
                var param = new Dictionary<string, string>();
                param.Add("userName", userName);
                res = await _api.Get<ReponderModel<BookViewModel>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> CreateBookChapter(BookChapter model)
        {
            var res = new ReponderModel<string>();
            if (model == null)
            {
                res.Message = "Thông tin không hợp lệ!";
                return res;
            }
            try
            {
                string url = PathUrl.BOOK_CREATE_CHAPTER;
                res = await _api.Post<ReponderModel<string>>(url, model);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<BookModel>> GetBook(int id)
        {
            var res = new ReponderModel<BookModel>();
            try
            {
                string url = PathUrl.BOOK_GET;
                var param = new Dictionary<string, string>();
                param.Add("id", id.ToString());
                res = await _api.Get<ReponderModel<BookModel>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<BookChapter>> GetListBookChapter(int bookId)
        {
            var res = new ReponderModel<BookChapter>();
            try
            {
                string url = PathUrl.BOOK_GET_CHAPTER;
                var param = new Dictionary<string, string>();
                param.Add("bookId", bookId.ToString());
                res = await _api.Get<ReponderModel<BookChapter>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> GenerateSummary(string input)
        {
            var model = new RequestModel
            {
                Data = input
            };
            var res = new ReponderModel<string>();
            if (string.IsNullOrEmpty(input))
            {
                res.Message = "Cần nhập nội dung chương";
                return res;
            }
            try
            {
                string url = PathUrl.BOOK_GENERATE_SUMMARY_CHAPTER;
                res = await _api.Post<ReponderModel<string>>(url, model);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> GeneratePoster(string input, string summary)
        {
            var res = new ReponderModel<string>();
            if (string.IsNullOrEmpty(input) && string.IsNullOrEmpty(summary))
            {
                res.Message = "Cần nhập tên truyện hoặc giới thiệu";
                return res;
            }
            var model = new RequestModel
            {
                Data = string.IsNullOrEmpty(input) ? " " : input,
                OptionData = string.IsNullOrEmpty(summary) ? " " : summary
            };

            try
            {
                string url = PathUrl.BOOK_GENERATE_POSTER_CHAPTER;
                res = await _api.Post<ReponderModel<string>>(url, model);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<BookChapter>> GetBookChapter(string id)
        {
            var res = new ReponderModel<BookChapter>();
            try
            {
                string url = PathUrl.BOOK_GET_BOOK_CHAPTER;
                var param = new Dictionary<string, string>();
                param.Add("id", id);
                res = await _api.Get<ReponderModel<BookChapter>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> UpdateBookChapter(BookChapter model)
        {
            var res = new ReponderModel<string>();
            if (model == null)
            {
                res.Message = "Thông tin không hợp lệ!";
                return res;
            }
            try
            {
                string url = PathUrl.BOOK_UPDATE_CHAPTER;
                res = await _api.Post<ReponderModel<string>>(url, model);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<ReportModel>> ShortReport()
        {
            var res = new ReponderModel<ReportModel>();
            try
            {
                string url = PathUrl.REPORT_SHORT;
                res = await _api.Get<ReponderModel<ReportModel>>(url);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> DeleteChapterBook(string id)
        {
            var res = new ReponderModel<string>();
            try
            {
                string url = PathUrl.BOOK_DELETE_CHAPTER;
                var param = new Dictionary<string, string>();
                param.Add("id", id.ToString());
                res = await _api.Get<ReponderModel<string>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<DraftModel>> GetDrafts(string userName)
        {
            var res = new ReponderModel<DraftModel>();
            try
            {
                string url = PathUrl.BOOK_GET_DRAFT;
                var param = new Dictionary<string, string>();
                param.Add("userName", userName);
                res = await _api.Get<ReponderModel<DraftModel>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<BookChapterApproveModel>> ApproveBook(int bookId)
        {
            var res = new ReponderModel<BookChapterApproveModel>();
            try
            {
                string url = PathUrl.BOOK_APPROVE;
                var param = new Dictionary<string, string>();
                param.Add("id", bookId.ToString());
                res = await _api.Get<ReponderModel<BookChapterApproveModel>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> UpdateApproveBook(int bookId, string chapterIds)
        {
            var res = new ReponderModel<string>();
            try
            {
                string url = PathUrl.BOOK_UPDATE_APPROVE;
                var param = new Dictionary<string, string>();
                param.Add("id", bookId.ToString());
                param.Add("chapterIds", chapterIds);
                res = await _api.Get<ReponderModel<string>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<StatisticsChapterBook>> StatisticsChapterBook(int bookId)
        {
            var res = new ReponderModel<StatisticsChapterBook>();
            try
            {
                string url = PathUrl.BOOK_GET_STATIS_CHAPTER_BOOK;
                var param = new Dictionary<string, string>();
                param.Add("bookId", bookId.ToString());
                res = await _api.Get<ReponderModel<StatisticsChapterBook>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<StatisticsChapterBook>> StatisticsBook(string username)
        {
            var res = new ReponderModel<StatisticsChapterBook>();
            try
            {
                string url = PathUrl.BOOK_GET_STATIS_BOOK;
                var param = new Dictionary<string, string>();
                param.Add("username", username);
                res = await _api.Get<ReponderModel<StatisticsChapterBook>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> QuicklyApproveChapterContent(RequestModel model)
        {
            var res = new ReponderModel<string>();
            if (model == null)
            {
                res.Message = "Dữ liệu không hợp lệ";
                return res;
            }

            try
            {
                string url = PathUrl.BOOK_QUICKLY_APPROVE_CHAPTER_CONTENT;
                res = await _api.Post<ReponderModel<string>>(url, model);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> DeleteBook(int id)
        {
            var res = new ReponderModel<string>();
            try
            {
                string url = PathUrl.BOOK_DELETE;
                var param = new Dictionary<string, string>();
                param.Add("id", id.ToString());
                res = await _api.Get<ReponderModel<string>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> UpdateApproveChapterBook(int bookId, string chapterId)
        {
            var res = new ReponderModel<string>();
            try
            {
                string url = PathUrl.BOOK_UPDATE_APPROVE_CHAPTER;
                var param = new Dictionary<string, string>();
                param.Add("bookId", bookId.ToString());
                param.Add("chapterId", chapterId);
                res = await _api.Get<ReponderModel<string>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> DeclineChapterBook(int id, string chapterId)
        {
            var res = new ReponderModel<string>();
            try
            {
                string url = PathUrl.BOOK_DECLINE_CHAPTER;
                var param = new Dictionary<string, string>();
                param.Add("bookId", id.ToString());
                param.Add("chapterId", chapterId);
                res = await _api.Get<ReponderModel<string>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<bool>> CheckPaidWithBookChapter(string username, int bookId)
        {
            var res = new ReponderModel<bool>();
            try
            {
                string url = PathUrl.BOOK_PAID_CHAPTER;
                var param = new Dictionary<string, string>();
                param.Add("bookId", bookId.ToString());
                param.Add("username", username);
                res = await _api.Get<ReponderModel<bool>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> CheckFinishBook(int bookId)
        {
            var res = new ReponderModel<string>();
            try
            {
                string url = PathUrl.BOOK_CHECK_FINISH;
                var param = new Dictionary<string, string>();
                param.Add("bookId", bookId.ToString());
                res = await _api.Get<ReponderModel<string>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> UpdateFinishBook(int bookId, int price)
        {
            var res = new ReponderModel<string>();
            try
            {
                string url = PathUrl.BOOK_UPDATE_FINISH;
                var param = new Dictionary<string, string>();
                param.Add("bookId", bookId.ToString());
                param.Add("price", price.ToString());
                res = await _api.Get<ReponderModel<string>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> HiddenChapterBook(string id)
        {
            var res = new ReponderModel<string>();
            try
            {
                string url = PathUrl.BOOK_HIDDEN_CHAPTER;
                var param = new Dictionary<string, string>();
                param.Add("id", id);
                res = await _api.Get<ReponderModel<string>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> BanBook(int bookId)
        {
            var res = new ReponderModel<string>();
            try
            {
                string url = PathUrl.BOOK_BAN;
                var param = new Dictionary<string, string>();
                param.Add("id", bookId.ToString());
                res = await _api.Get<ReponderModel<string>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> UnBanBook(int bookId)
        {
            var res = new ReponderModel<string>();
            try
            {
                string url = PathUrl.BOOK_UN_BAN;
                var param = new Dictionary<string, string>();
                param.Add("id", bookId.ToString());
                res = await _api.Get<ReponderModel<string>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<BookChapterVoiceModel>> GetChapterAudio(string chapterId)
        {
            var res = new ReponderModel<BookChapterVoiceModel>();
            try
            {
                string url = PathUrl.BOOK_GET_CHAPTER_AUDIO;
                var param = new Dictionary<string, string>();
                param.Add("chapterId", chapterId);
                res = await _api.Get<ReponderModel<BookChapterVoiceModel>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> UpdatePriceChapterVoice(BookChapterVoiceModel model)
        {
            var res = new ReponderModel<string>();
            try
            {
                string url = PathUrl.BOOK_UPDATE_PRICE_CHAPTER_AUDIO;
                res = await _api.Post<ReponderModel<string>>(url, model);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }
    }
}
