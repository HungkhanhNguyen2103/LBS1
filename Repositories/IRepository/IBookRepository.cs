using BusinessObject;
using BusinessObject.BaseModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IBookRepository
    {
        Task GetBookImages();
        Task<ReponderModel<Category>> GetCategories();
        Task<ReponderModel<string>> UpdateCategory(Category model);
        Task<ReponderModel<string>> DeleteCategory(int id);
        Task<ReponderModel<string>> UpdateBook(Book book);
        Task<ReponderModel<Book>> GetBook(int id);
        Task<ReponderModel<string>> CreateBook(BookModel bookModel);
        Task<ReponderModel<BookViewModel>> GetAllBookByUser(string userName);
        Task<ReponderModel<string>> CreateBookChapter(BookChapter bookChapter);
        Task<ReponderModel<string>> UpdateBookChapter(BookChapter bookChapter);
        Task<ReponderModel<BookChapter>> GetBookChapter(string id);
        Task<ReponderModel<BookChapter>> GetListBookChapter(int bookId);
        Task<ReponderModel<string>> DeleteChapterBook(string id);
        Task<ReponderModel<string>> GenerateSummary(string input);
        Task<ReponderModel<string>> GeneratePoster(string input,string summary);
        Task<ReponderModel<string>> GenerateTextToAudio(string input);
        Task<ReponderModel<string>> GenerateTextToImage(string input);
        Task<ReponderModel<DraftModel>> GetDrafts(string userName);
        Task<ReponderModel<string>> ApproveBook(int bookId);
        Task<ReponderModel<string>> UpdateApproveBook(int bookId);
        Task<ReponderModel<string>> UpdateBookChapterView(UserBookView model);
        Task<ReponderModel<StatisticsChapterBook>> StatisticsChapterBook(int bookId);
        Task<ReponderModel<StatisticsChapterBook>> StatisticsBook(string username);
    }
}
