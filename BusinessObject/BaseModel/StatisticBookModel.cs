using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.BaseModel
{
    public class StatisticBookModel
    {
        public string UserName { get; set; }
        public string Status { get; set; }
        public string Author { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Poster { get; set; }
        public int TotalChapter { get; set; }
        public int ViewReadNo { get; set; }
        public int ViewListenNo { get; set; }
        public int RatingNo { get; set; }
        public int SumRating { get; set; }
        public double Rating { get; set; }
        public int FavouriteNo { get; set; }
        public int Revenue { get; set; }
    }
}
