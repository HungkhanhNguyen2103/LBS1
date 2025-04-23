using BusinessObject.BaseModel;
using BusinessObject;

namespace LBSWeb.Service.Book
{
    public interface IBookService
    {
        void GetBookImages();
        Task<ReponderModel<Category>> GetCategories();
        Task<ReponderModel<string>> UpdateCategory(Category model);
        Task<ReponderModel<string>> DeleteCategory(int id);
        Task<ReponderModel<string>> CreateBook(BookModel bookModel);
        Task<ReponderModel<string>> UpdateBook(BookModel bookModel);
        Task<ReponderModel<string>> DeleteBook(int id);
        Task<ReponderModel<string>> QuicklyApproveChapterContent(RequestModel model);
        Task<ReponderModel<BookModel>> GetBook(int id);
        Task<ReponderModel<BookViewModel>> GetAllBookByUser(string userName);
        Task<ReponderModel<string>> HiddenChapterBook(string id);
        Task<ReponderModel<string>> BanBook(int bookId);
        Task<ReponderModel<string>> UnBanBook(int bookId);
        Task<ReponderModel<string>> CreateBookChapter(BookChapter bookChapter);
        Task<ReponderModel<BookChapter>> GetBookChapter(string id);
        Task<ReponderModel<string>> UpdateBookChapter(BookChapter bookChapter);
        Task<ReponderModel<BookChapter>> GetListBookChapter(int bookId);
        Task<ReponderModel<string>> GenerateSummary(string input);
        Task<ReponderModel<string>> GeneratePoster(string input,string summary);
        Task<ReponderModel<ReportModel>> ShortReport();
        Task<ReponderModel<string>> DeleteChapterBook(string id);
        Task<ReponderModel<DraftModel>> GetDrafts(string userName);
        Task<ReponderModel<BookChapterApproveModel>> ApproveBook(int bookId);
        Task<ReponderModel<string>> UpdateApproveBook(int bookId,string chapterIds);
        Task<ReponderModel<string>> UpdateApproveChapterBook(int bookId, string chapterId);
        Task<ReponderModel<string>> DeclineChapterBook(int id, string chapterId);
        Task<ReponderModel<StatisticsChapterBook>> StatisticsChapterBook(int bookId);
        Task<ReponderModel<StatisticsChapterBook>> StatisticsBook(string username);
        Task<ReponderModel<bool>> CheckPaidWithBookChapter(string username, int bookId);
        Task<ReponderModel<string>> CheckFinishBook(int bookId);
        Task<ReponderModel<string>> UpdateFinishBook(int bookId, int price);
        Task<ReponderModel<BookChapterVoiceModel>> GetChapterAudio(string chapterId);
        Task<ReponderModel<string>> UpdatePriceChapterVoice(BookChapterVoiceModel model);
    }
}
