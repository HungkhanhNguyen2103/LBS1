﻿using BusinessObject;
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
        Task<ReponderModel<string>> UpdateBook(BookModel book);
        Task<ReponderModel<BookModel>> GetBook(int id);
        Task<ReponderModel<string>> CreateBook(BookModel bookModel);
        Task<ReponderModel<BookViewModel>> GetAllBookByUser(string userName);
        Task<ReponderModel<BookViewModel>> GetAllBookByCategory(string category);
        Task<ReponderModel<string>> CreateBookChapter(BookChapter bookChapter);
        Task<ReponderModel<string>> UpdateBookChapter(BookChapter bookChapter);
        Task<ReponderModel<BookChapter>> GetBookChapter(string id);
        Task<ReponderModel<BookChapterModel>> GetBookChapterWithVoice(string id);
        Task<ReponderModel<BookChapter>> GetListBookChapter(int bookId);
        Task<ReponderModel<string>> DeleteChapterBook(string id);
        Task<ReponderModel<string>> DeleteBook(int id);
        Task<ReponderModel<string>> GenerateSummary(string input);
        Task<ReponderModel<string>> GeneratePoster(string input,string summary);
        Task<ReponderModel<string>> GenerateTextToAudio(string input);
        Task<ReponderModel<string>> GenerateTextToImage(string input);
        Task<ReponderModel<DraftModel>> GetDrafts(string userName);
        Task<ReponderModel<BookChapterApproveModel>> ApproveBook(int bookId);
        Task<ReponderModel<string>> QuicklyApproveChapterContent(string input);
        Task<ReponderModel<string>> UpdateApproveBook(int bookId);
        Task<ReponderModel<string>> UpdateApproveChapterBook(int bookId, string chapterId);
        Task<ReponderModel<string>> DeclineChapterBook(int id, string chapterId);
        Task<ReponderModel<string>> UpdateBookChapterView(UserBookView model);
        Task<ReponderModel<StatisticsChapterBook>> StatisticsChapterBook(int bookId);
        Task<ReponderModel<StatisticsChapterBook>> StatisticsBook(string username);
        Task<ReponderModel<CommentModel>> GetCommentByBook(int bookId);
        Task<ReponderModel<string>> UpdateComment(Comment comment);
        Task<ReponderModel<int>> CreateViewBook(UserBookViewModel model);
        Task<ReponderModel<int>> GetViewNo(int bookId,BookTypeStatus type);
        Task<ReponderModel<UserMinuteModel>> GetListMinuteViewByUser(string userName);
        Task<ReponderModel<string>> AddOrRemoveFavouriteBook(string userName, int bookId);
        Task<ReponderModel<UserBook>> ListFavouriteBook(string userName);
        Task<ReponderModel<BookModel>> SearchBook(string input);
        Task<ReponderModel<NoteUser>> GetListNote(string username,string chapterId);
        Task<ReponderModel<string>> UpdateNoteUser(NoteUser note);
        Task<ReponderModel<string>> DeleteNoteUser(int id);
        Task<ReponderModel<BookRatingModel>> GetTop10BookRating();
        Task<ReponderModel<BookModel>> GetTop10NewBook();
        Task<ReponderModel<BookModel>> GetTop10FavoriteBook();

    }
}
