namespace LBSWeb.Common
{
    public class PathUrl
    {
        //Account
        public static string ACCOUNT_REGISTER = "api/Account/Register";
        public static string ACCOUNT_LOGIN = "api/Account/Login";
        public static string ACCOUNT_GETALL = "api/Account/GetAll";
        public static string ACCOUNT_GET_INFO = "api/Account/Information";
        public static string ACCOUNT_UPDATE_INFO = "api/Account/UpdateInformation";
        public static string ACCOUNT_CONFIRMEMAIL = "api/Account/ConfirmEmail";
        public static string ACCOUNT_TOGGLE_LOCK_USER = "api/Account/ToggleLockUser";
        public static string ACCOUNT_ACCESS_ROLE = "api/Account/GrantAccessRole";
        public static string ACCOUNT_FORGOT_PASSWORD = "api/Account/ForgotPassword";
        public static string ACCOUNT_CHANGE_PASSWORD = "api/Account/ChangePassword";
        public static string ACCOUNT_RE_CONFIRM_EMAIL = "api/Account/ReConfirmEmail";
        public static string ACCOUNT_LOGIN_WITH_GOOGLE = "api/Account/LoginWithGoogle";
        public static string ACCOUNT_GET_LIST = "api/Account/GetListAccount";
        public static string ACCOUNT_UPDATE_BANK = "api/Account/UpdateBankAccount";
        public static string ACCOUNT_GET_BANK = "api/Account/GetBankAccount";

        //Book
        public static string CATEGORY_GET_ALL = "api/Book/GetCategories";
        public static string CATEGORY_UPDATE = "api/Book/UpdateCategory";
        public static string CATEGORY_DELETE = "api/Book/DeleteCategory";
        public static string BOOK_DELETE_CHAPTER = "api/Book/DeleteChapterBook";
        public static string BOOK_GET = "api/Book/GetBook";
        public static string BOOK_DELETE = "api/Book/DeleteBook";
        public static string BOOK_APPROVE = "api/Book/ApproveBook";
        public static string BOOK_UPDATE_APPROVE = "api/Book/UpdateApproveBook";
        public static string BOOK_UPDATE_APPROVE_CHAPTER = "api/Book/UpdateApproveChapterBook";
        public static string BOOK_DECLINE_CHAPTER = "api/Book/DeclineChapterBook";
        public static string BOOK_CREATE = "api/Book/CreateBook";
        public static string BOOK_UPDATE = "api/Book/UpdateBook";
        public static string BOOK_UPDATE_CHAPTER = "api/Book/UpdateBookChapter";
        public static string BOOK_GET_BY_USER = "api/Book/GetAllBookByUser";
        public static string BOOK_CREATE_CHAPTER = "api/Book/CreateBookChapter";
        public static string BOOK_PAID_CHAPTER = "api/Book/CheckPaidWithBookChapter";
        public static string BOOK_CHECK_FINISH = "api/Book/CheckFinishBook";
        public static string BOOK_UPDATE_FINISH = "api/Book/UpdateFinishBook";
        public static string BOOK_HIDDEN_CHAPTER = "api/Book/HiddenChapterBook";
        public static string BOOK_BAN = "api/Book/BanBook";
        public static string BOOK_UN_BAN = "api/Book/UnBanBook";
        public static string BOOK_GET_CHAPTER = "api/Book/GetListBookChapter";
        public static string BOOK_GET_CHAPTER_AUDIO = "api/Book/GetChapterAudio";
        public static string BOOK_UPDATE_PRICE_CHAPTER_AUDIO = "api/Book/UpdatePriceChapterVoice";
        public static string BOOK_GET_BOOK_CHAPTER = "api/Book/GetBookChapter";
        public static string BOOK_GENERATE_SUMMARY_CHAPTER = "api/Book/GenerateSummary";
        public static string BOOK_GENERATE_POSTER_CHAPTER = "api/Book/GeneratePoster";
        public static string BOOK_QUICKLY_APPROVE_CHAPTER_CONTENT = "api/Book/QuicklyApproveChapterContent";
        public static string BOOK_GET_DRAFT = "api/Book/GetDrafts";
        public static string BOOK_GET_STATIS_CHAPTER_BOOK = "api/Book/StatisticsChapterBook";
        public static string BOOK_GET_STATIS_BOOK = "api/Book/StatisticsBook";

        //Report
        public static string REPORT_SHORT = "api/Account/ShortReport";

        //Information
        public static string INFO_LIST_BASICKNOWLEDGE = "api/Information/BasicKnowledge";
        public static string INFO_UPDATE_BASICKNOWLEDGE = "api/Information/UpdateBasicKnowledge";
        public static string INFO_DELETE_BASICKNOWLEDGE = "api/Information/DeleteBasicKnowledge";
        public static string INFO_DETAIL_BASICKNOWLEDGE = "api/Information/KnowledgeDetail";
        public static string INFO_LIST_NOTIFICATION = "api/Information/ListNotification";
        public static string INFO_DETAIL_NOTIFICATION = "api/Information/NotificationDetail";
        public static string INFO_UPDATE_NOTIFICATION = "api/Information/UpdateNotification";
        public static string INFO_DELETE_NOTIFICATION = "api/Information/DeleteNotification";
        public static string INFO_LIST_CONSPECTUS = "api/Information/ListConspectus";
        public static string INFO_UPDATE_CONSPECTUS = "api/Information/UpdateConspectus";
        public static string INFO_DETAIL_CONSPECTUS = "api/Information/ConspectusDetail";
        public static string INFO_DELETE_CONSPECTUS = "api/Information/DeleteConspectus";
        public static string INFO_LIST_USERREPORT = "api/Information/ListUserReport";
        public static string INFO_GET_ROOM_AUTHOR = "api/Information/GetRoomByAuthor";
        public static string INFO_GET_ROOM_MANAGER = "api/Information/GetRoomByManager";
        public static string INFO_CREATE_USERREPORT = "api/Information/CreateUserReport";
        public static string INFO_SEND_MESSAGE = "api/Information/SendMessage";
        public static string INFO_DETAIL_USERREPORT = "api/Information/UserReport";
        public static string INFO_STATISTIC_BOOK = "api/Information/StatisticBook";
        public static string INFO_CLOSE_USERREPORT = "api/Information/CloseUserReport";
        public static string INFO_OPEN_USERREPORT = "api/Information/OpenUserReport";
        public static string INFO_GET_LISTMESSAGE = "api/Information/GetListMessageByRoom";

        //UserReportComment
        public static string INFO_ALL_COMMENT_USERREPORT = "api/Information/GetListUserReportComment";
        public static string INFO_CREATE_COMMENT_USERREPORT = "api/Information/CreateUserReportComment";

        //Payment
        public static string PAYMENT_SUCCESS = "api/Payment/PaymentSuccess";
        //public static string INFO_ALL_COMMENT_USERREPORT = "api/Information/GetListUserReportComment";
        //public static string INFO_ALL_COMMENT_USERREPORT = "api/Information/GetListUserReportComment";
        //public static string INFO_ALL_COMMENT_USERREPORT = "api/Information/GetListUserReportComment";
    }

}
